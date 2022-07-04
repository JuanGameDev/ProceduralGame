
using UnityEngine;

public class Jump : MonoBehaviour
{
    [Header("Dependencias")]
    public Transform overlapPoint;
    [Header("Configuracion")]
    public LayerMask ground;
    public float jumpForce;
    public float coyoteDuration;
    //Variables locales
    private Animator animator;
    private Rigidbody2D rb;
    private EffectsBrain effects_cs;
    [HideInInspector]public bool inGround , jumpEnable;
    private float timer;
    private int jumpCount;
    private void Start()
    {
        //Obtener dependencias locales
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        effects_cs = GetComponent<EffectsBrain>();
    }
    private void Update()
    {
        //Comprobar si tocamos el suelo
        inGround = Physics2D.OverlapCircle(overlapPoint.position , 0.1f , ground);

        //Evaluamos situacion para salto

        if (inGround)//Se permite el salto pues se toca el suelo
        {
            //Estando en el suelo se reinician las condiciones
            jumpEnable = true;
            timer = 0f;
            jumpCount = 0;
        }
        //Permitimos salto en el aire si ahun en coyote
        else
        {
            if (jumpCount < 1)//Se comprueba solo durante el primer salto
            {
                timer += Time.deltaTime;
                if (timer > coyoteDuration)//Superamos el coyote , no saltamos
                {
                    jumpEnable = false;
                }
                //Salto en tiempo de coyote
                else jumpEnable = true;
            }
            //No saltara si ya hemos saltado
            else jumpEnable = false;
        }

        //Comprobamos el input
        if (Input.GetKeyDown(KeyCode.Space) && jumpEnable) JumpNow();
        //Aplicamos la animacion
        animator.SetBool("inGround", inGround);
    }       
    private void JumpNow()
    {
        //Activamos el efecto de humo
        effects_cs.Jump();
        //Aplicamos lafuerza
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.AddForce(Vector2.up * jumpForce , ForceMode2D.Impulse);
        //Contamos el salto
        jumpCount++;
    }
}
