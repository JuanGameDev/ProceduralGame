
using UnityEngine;

public class movement : MonoBehaviour
{
    [Header("Dependencias")]
    public Animator animator;
    public BoxCollider2D hurtColl;
    [Header("Configuracion")]
    public float speed;
    public float dashForce;
    public Vector2 pushForce;
    //Variables locales
    private Rigidbody2D rb;
    private float direction;
    [HideInInspector]public bool controled = true;
    void Start()
    {
        //Obtener dependendencias locales
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        //Obtener input
        direction = Input.GetAxisRaw("Horizontal");


        //======ZONA DEL DASH=========

        //Obtener input para dashear
        if (Input.GetKeyDown(KeyCode.LeftShift) && animator.GetBool("move") && animator.GetBool("inGround") &&
            !Current("player_atack") && !Current("player_magic") && !Current("player_dash")) 
            animator.SetTrigger("dash");
        //Solo mientras estamos en dash , desactivamos el hurt para aser inmunes
        hurtColl.enabled = !Current("player_dash");
        //Como medida auxilira al cambio de animacion y que no se que de en uncontroled move usamos :
        if (!Current("player_damage")
            && !Current("player_dash")) ControledMovement();
    }
    private void FixedUpdate()
    {
        //Aplicar el movimiento

        //Movimiento controlado se rige por el imput
        if (controled)
        {
            float mov = direction * (speed * Time.fixedDeltaTime);
            rb.velocity = new Vector2(mov, rb.velocity.y);
        }
    }
    public void ControledMovement() 
    {
        //Activa el buleano que nos permite movernos
        controled = true;
    }
    public void UnControledMovement()//Se usa para empujar al personaje al ser golpeado
    {
        //Desactiva el movimento controlado , se usa en la duracion de animacion del push damage
        controled = false;
        rb.velocity = Vector2.zero;
        //Aplicamos el empuje en la direccion contraria
        rb.AddForce(new Vector2(transform.localScale.x * -1, 1) * pushForce, ForceMode2D.Impulse);
    }
    public void UnControledMovementDashing()//Se usa para empujar al personaje en su dash
    {
        //Desactiva el movimento controlado , se usa en la duracion de animacion del push damage
        controled = false;
        rb.velocity = Vector2.zero;
        //Aplicamos el empuje del dash
        rb.AddForce(new Vector2(transform.localScale.x, 0) * dashForce, ForceMode2D.Impulse);
    }
    private bool Current(string animationName) => animator.GetCurrentAnimatorStateInfo(0).IsName(animationName);
}
