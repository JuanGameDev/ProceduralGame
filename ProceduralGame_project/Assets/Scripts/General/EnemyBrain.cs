using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class EnemyBrain : MonoBehaviour
{
    [Header("Configuracion")]
    public float healthPoints;
    public Color hitColor;
    [Header("Slider")]
    public Slider HP_slider;
    public float sliderDuration;
    private GameObject sliderObj;
    [Header("Eventos")]
    public UnityEvent AlVidaCero;
    public UnityEvent AlRecibirDaño;
    public UnityEvent AlLlamarDeAnimacion;
    //private
    private SpriteRenderer renderer;
    private Color startColor;
    private float startHealth;
    private void Start()
    {
        //Obtenemos referencias locasles
        renderer = GetComponent<SpriteRenderer>();
        //Si el renderer no esta en el padre debe estar en el primer hijo para obtenerlo
        if (renderer == null) renderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
        //Valores iniciales
        startColor = renderer.color;
        startHealth = healthPoints;


        //Indicamos la vida en el slider
        if (HP_slider != null)
        {
            sliderObj = HP_slider.gameObject;
            HP_slider.maxValue = HP_slider.value = healthPoints;
            sliderObj.SetActive(false);
        }
    }
    public void SendDamage(int damage)
    {
        //Recibimos daño del exterior
        //Si el daño es menor a cero o cero invokamos eventos de muerte
        if (healthPoints - damage <= 0)
        {
            //LLamamos al evento si morimos
            if (AlVidaCero != null && healthPoints != 0) AlVidaCero.Invoke();
            healthPoints = 0;
        }
        //Si el daño es mayor a cero solo restamos vida
        else healthPoints -= damage;
        //LLamamos al evento de daño
        if(AlRecibirDaño != null)AlRecibirDaño.Invoke();
        //Tintamos un mometo al recibir daño
        StopAllCoroutines();
        StartCoroutine(Tintar());


        //Zona de Interaccion con el Slider
        if(HP_slider != null)
        {
            //LLamamos a corrutina
            StopCoroutine(SliderView(0)); StartCoroutine(SliderView(damage));
        }
    }
    private IEnumerator Tintar()
    {
        //Aplicamos color por un breve momento
        renderer.color = hitColor;
        yield return new WaitForSecondsRealtime(0.3f);
        renderer.color = startColor;
    }
    public void EventCall()
    {
        //Este evento se podra llamar por medio de nuestra animacion
        if (AlLlamarDeAnimacion != null) AlLlamarDeAnimacion.Invoke();
    }
    private void OnDisable()
    {
        //Debido a que los enemigos son reutilizados , se mantienen los valores
        //por lo tanto al activarlos de nuevo deben emepzar con los valores iniciales
        healthPoints = startHealth;
        HP_slider.value = HP_slider.maxValue;
        sliderObj.SetActive(false);

    }
    IEnumerator SliderView(int damage)//Aqui se mostrara el slider al ser golpeado
    {
        //Mostramos el slider
        sliderObj.SetActive(true);
        //Reducimos la vida al slider
        HP_slider.value -= damage;
        //Esperamos
        yield return new WaitForSecondsRealtime(sliderDuration);
        //Desactivamos
        sliderObj.SetActive(false);
    }
}
