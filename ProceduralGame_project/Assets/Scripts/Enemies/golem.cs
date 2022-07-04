using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class golem : MonoBehaviour
{
    [Header("configuracion")]
    public float detectionRange;
    public float atackA_range;
    public float atackB_range;
    public float moveSpeed;
    public float sleepTime;
    //referencias globales
    private Transform player;
    //referencias locales
    private Rigidbody2D rb;
    private Animator animator;
    //variables locales
    private bool moveEnable;
    private bool guardFirst = true , guardSecond = true;
    private int rnd;
    private float count;
    void Start()
    {
        //Obtener referencias globales 
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        //Obtener referencias locales
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        //Comprobamos si el jugador esta en nuestro rango
        if (Distance() < detectionRange)
        {
            //Tenemos un cooldown luego de cada ataque
            count += Time.deltaTime;
            if (count > sleepTime)
            {
                //Creamos un random y permitimos el movimiento, solo una vez
                if (guardFirst)
                {
                    rnd = new System.Random().Next(1, 3); guardFirst = false;
                    //
                    moveEnable = true;
                }
                //Usamos el random para definir que ataque usaremos

                //Tipo de ataque A
                if (rnd == 1 && Distance() < atackA_range)
                {
                    if (guardSecond)//Animacion correspondiente solo una vez
                    {
                        moveEnable = false;
                        animator.SetTrigger("atack_a");
                        guardSecond = false;
                    }
                }
                //Tipo de ataque B
                else if (rnd == 2 && Distance() < atackB_range)
                {
                    if (guardSecond)//Animacion correspondiente solo una vez
                    {
                        moveEnable = false;
                        animator.SetTrigger("atack_b");
                        guardSecond = false;
                    }
                }
            }
        }
        else moveEnable = false;
        //Actualizamos animacion
        animator.SetBool("move", moveEnable);
        //Actualizacion de escala
        transform.localScale = new Vector2(Direction() , 1);
    }
    public void AtackEnd()//Se llama desde la aniamcion para indicar que el ataque termino
    {
        guardFirst = true;
        guardSecond = true;
        count = 0f;
    }
    private void FixedUpdate()
    {
        if (moveEnable)
        {
            //Asignamos movimiento no escalar
            float move = moveSpeed * Time.fixedDeltaTime;
            //Aplicamos el movimiento
            rb.velocity = new Vector2(move * Direction(), rb.velocity.y);
        }
        else rb.velocity = new Vector2(0, rb.velocity.y);
    }
    private float Distance() => Vector2.Distance(player.position , transform.position);//Nos devuelve la distancia del jugador y nostros
    private int Direction()
    {
        //Direccion hacia el jugador es adelante
        if (player.position.x > transform.position.x) return 1;
        //Direccion hacia  el jugador es atras
        else return -1;
    }
    public void Death()
    {

        guardFirst = false;
        guardSecond = false;
        count = 0f;
        animator.SetTrigger("death");
    }
    public void ResetValues()
    {
        guardFirst = true;
        guardSecond = true;
        count = 0f;
    }
}
