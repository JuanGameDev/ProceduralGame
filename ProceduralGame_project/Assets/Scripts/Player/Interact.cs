
using UnityEngine;

public class Interact : MonoBehaviour
{
    [Header("Dependencias")]
    public Rigidbody2D rb;
    public GameObject iconInteract;
    public GameObject StatsUI , ShopUI;
    //Variabes privada
    private bool inInteract;
    private string focusUI;
    private void Update()
    {
        //Si estamos en un area de interaccion y pulsamos , activamos
        if(inInteract && Input.GetKeyDown(KeyCode.E))
        {
            switch (focusUI)
            {
                //Activamos segun el tipo de interaccion al que ingrresamos
                case "stats":StatsUI.SetActive(true);break;
                case "shop": ShopUI.SetActive(true); break;
                default:
                    break;
            }
        }
        //Si nos movemos desactivamos la UI correspondiente
        if(rb.velocity.x > 1 || rb.velocity.x < -1)
        {
            switch (focusUI)
            {
                //Activamos segun el tipo de interaccion al que ingrresamos
                case "stats": StatsUI.SetActive(false); break;
                case "shop": ShopUI.SetActive(false); break;
                default:
                    break;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Si entramos a un area de interaccion
        if(collision.transform.tag == "Interact")
        {
            //Activamos icono e indicamos propiedad
            if(iconInteract != null)iconInteract.SetActive(true);
            inInteract = true;
            //Comprobamos que tipo de interaccion corresponde
            if (collision.transform.name == "Idolo") focusUI = "stats";
            else if (collision.transform.name == "Shop") focusUI = "shop";
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //Si salimos de un area de interaccion
        if(collision.transform.tag == "Interact")
        {
            //Desactivamos icono e indicamos propiedad
            if (iconInteract != null)iconInteract.SetActive(false);
            inInteract = false;
        }
    }
}
