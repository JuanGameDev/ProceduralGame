
using UnityEngine;

public class caracol : MonoBehaviour
{
    [Header("Configuracion")]
    public Vector2 distanceMove;
    public float speed;
    [Header("Dependencias")]
    public GameObject damageColl;
    //Variables locales
    private Rigidbody2D rb;
    private Animator anim;
    private Vector2 distanceStatic;
    private int direccion;
    private bool g = true;
    private Vector2 startPos;
    private void Start()
    {
        //Obtener referencias locales
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        //Asignamos la posicion incial
        startPos = transform.localPosition;
    }
    private void Update()
    {
        //Direccion derecha
        if (transform.position.x < distanceStatic.y && g) direccion = 1;
        else g = false;
        //Direccion izquierda
        if (transform.position.x > distanceStatic.x && !g) direccion = -1;
        else g = true;

        //Aplicamos la escala
        if (direccion == 1) transform.localScale = new Vector2(-1 , 1);
        else transform.localScale = new Vector2(1, 1);
    }
    private void FixedUpdate()
    {
        //Aplicamos el movimiento
        float move = direccion * (speed * Time.fixedDeltaTime);
        //Nos movemos si no estamos en animacion de muerte
        if(!GetCurrent())rb.velocity = new Vector2(direccion , rb.velocity.y);
        else rb.velocity = rb.velocity = new Vector2(0, rb.velocity.y);
    }
    public void DamageApply()
    {
        //Animamos la muerte del caracol , desactivamos nuestro daño
        anim.SetTrigger("animar");
    }
    private bool GetCurrent() => anim.GetCurrentAnimatorStateInfo(0).IsName("caracol_death");
    private void UnabledMe() { gameObject.SetActive(false); }
    public void ResetValues()
    {
        //Este mensaje resinicia la configuracion Inicial , se llama desde el tile

        //Asignar nuevamente los limites
        distanceStatic = new Vector2(transform.position.x - distanceMove.x
            , transform.position.x + distanceMove.y);
        //Ativamos el daño nuevamente
        damageColl.SetActive(true);
    }
}
