using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crab : MonoBehaviour
{
    [Header("Configuracion")]
    public float speed;
    public float detectionRange;
    public float atackdRange;


    //Dependencias locales
    private Transform player;
    private Rigidbody2D rb;
    //Variables privadas
    private bool enableMove;
    private Animator animator;
    void Start()
    {
        //Obtener referencias globales
        player = GameObject.FindWithTag("Player").transform;
        //Obtener referencias locales
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        //Comporbamos si el jugador esta en nuestro rango para movernos hacia el
        if (Distance(transform.position, player.position) < detectionRange)
        {
            enableMove = true;
        }
        else enableMove = false;
        //Comprobamos si el jugador esta en nuestro ragno para atacarlo
        if (Distance(transform.position, player.position) < atackdRange)
        {
            animator.SetBool("atack", true);
        }
        else animator.SetBool("atack", false);
        //Actualizamos la escala
        transform.localScale = new Vector2(Direction(), 1);
        //Animacion de movimiento
        animator.SetBool("move", enableMove);
    }
    private void FixedUpdate()
    {
        //Nos movemos si
        if (enableMove && !Getstate())
        {
            float move = (speed * Time.fixedDeltaTime) * Direction();
            rb.velocity = new Vector2(move, rb.velocity.y);
        }
    }
    private float Distance(Vector2 one, Vector2 two) => Vector2.Distance(one, two);
    private int Direction()
    {
        //Devuelve la direccion en formato unitario (1,-1)
        if (player.position.x > transform.position.x)
        {
            return 1;
        }
        return -1;
    }
    private bool Getstate() => animator.GetCurrentAnimatorStateInfo(0).IsName("crab_atack") ||
        animator.GetCurrentAnimatorStateInfo(0).IsName("crab_death");
    public void CrabDeath()
    {
        //Llamamaos a la animacion de muerte
        animator.SetTrigger("death");
    }
    public void UnalbedMe()
    {
        //Nos desactivamos
        gameObject.SetActive(false);
    }
}
