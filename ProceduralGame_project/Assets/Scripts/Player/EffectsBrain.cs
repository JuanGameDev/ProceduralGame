
using UnityEngine;

public class EffectsBrain : MonoBehaviour
{
    [Header("Dependencias")]
    public GameObject jumpSmoke;
    public GameObject walkSmoke;
    public GameObject hitSmoke;
    //Variables locales
    private Vector2 jumpPos;
    private SpriteRenderer walkRender;
    private Jump jump_cs;
    private void Start()
    {
        //Obtener posiciones iniciales
        jumpPos = jumpSmoke.transform.localPosition;
        //Obtener referencias
        walkRender = hitSmoke.GetComponent<SpriteRenderer>();
        jump_cs = GetComponent<Jump>();
    }
    public void Jump()
    {
        //Efecto de humo de salto
        jumpSmoke.SetActive(false);
        jumpSmoke.transform.SetParent(this.transform);
        jumpSmoke.transform.localPosition = jumpPos;
        jumpSmoke.SetActive(true);
        jumpSmoke.transform.SetParent(null);
    }
    public void Hit(Vector2 pos)
    {
        //Effecto de humo de golpe
        hitSmoke.SetActive(false);
        hitSmoke.transform.SetParent(null);
        hitSmoke.transform.position = pos;
        hitSmoke.SetActive(true);
    }
    public void Walk()
    {
        //Se activa por medio de la animacion player_walk , solo si tocamos el suelo

        walkRender.enabled = true;
        walkSmoke.SetActive(false); walkSmoke.SetActive(true);
    }
    private void Update()
    {
        walkSmoke.SetActive(jump_cs.jumpEnable);
    }
}
