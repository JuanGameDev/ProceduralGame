using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim : MonoBehaviour
{
    //Variables locales
    private Rigidbody2D rb;
    private Animator animator;
    private movement movement_cs;
    private void Start()
    {
        //Obtener dependencias locales
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        movement_cs = GetComponent<movement>();
    }
    private void Update()
    {
        //Actualizamos la animaciones

        //movimiento                                            
        animator.SetBool("move",rb.velocity != Vector2.zero);
        //escalamos si el movimento es controlado
        if (rb.velocity.x > 1 && movement_cs.controled) transform.localScale = new Vector2(1, 1);
        else if (rb.velocity.x < -1 && movement_cs.controled) transform.localScale = new Vector2(-1,1);
        //velocidad
        animator.SetInteger("vertical",(int)rb.velocity.y);
    }
}
