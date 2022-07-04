using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class healing : MonoBehaviour
{
    [Header("Dependences")]
    public GameObject particle;
    public Slider manaSlider;
    [Header("Configuration")]
    public float downSpeed;
    //referencias locales
    private Animator animator;
    //variables privadas
    private bool healingEnable;
    private void Start()
    {
        //Obtener referencias locales
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        //Comprobamos si pulsamos para animar la espada levantada
        if (Input.GetMouseButton(1))
        {
            animator.SetBool("healing", true);
            //Curaremos y gastaremos mana si se permite
            if (healingEnable)
            {

            }
        }
        else
        {
            animator.SetBool("healing", false);
        }
    }
}
