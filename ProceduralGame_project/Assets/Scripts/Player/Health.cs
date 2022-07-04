using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [Header("Dependencias")]
    public Slider healthSlider;
    [Header("Configuracion")]
    public int healthPoints;
    public float healthDownSpeed;
    //public float forcePush;
    //Variables Locales
    private Rigidbody2D rb;
    private Animator animator;
    private void Start()
    {
        //Obtenermos referencias locales
        rb = transform.parent.GetComponent<Rigidbody2D>();
        animator = transform.parent.parent.GetComponent<Animator>();
        //Aplicamos configuracion inicial de la vida
        healthSlider.maxValue = healthSlider.value = healthPoints;
    }
    public void SendDamage(int damage , int direction)
    {
        //LLamamos para reducir la vida proceduralmente
        StopAllCoroutines();StartCoroutine(LifeDown(damage));

        //LLamamos a enviar daño y direcion
        DamageAnim(direction);
    }
    public void DamageAnim(int direction)
    {
        //Asignamos de que direccion viene el daño para mirar hacia ella
        transform.parent.parent.localScale = new Vector2(direction, 1);
        //Animamos el daño
        animator.SetTrigger("damage");
    }
    private IEnumerator LifeDown(int damage)
    {
        //Aqui bajaremos la vida proceduralmente
        float lifeObjetive = healthSlider.value - damage;
        while (healthSlider.value > lifeObjetive)
        {
            healthSlider.value -= healthDownSpeed;
            yield return null;
        }
    }
}
