
using UnityEngine;

public class coinActive : MonoBehaviour
{
    //Este script solo tiene una funcion , el collider que permite ser cogido por
    //el jugador se activara luego de un rebote ,esto es un efecto nada mas

    public GameObject activeThis;
    private Transform startParent;
    private bool firstTime = true;
    private bool downFall = true;
    private void OnDisable()
    {
        if (firstTime)
        {
            //Obtenermos el padre inicial
            startParent = transform.parent;
            firstTime = false;
        }
        //Volvemos a inicializar estos parametros
        activeThis.SetActive(false);
        downFall = true;
    }
    private void LateUpdate()
    {
        //Si la moneda esta en caida infinita lo recolocamos y desactivamos
        if (transform.position.y < 0 && downFall)
        {
            SetInPartent();
            downFall = false;
            gameObject.SetActive(false);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Activamos la capacidad de ser cogidos solo al chocar con el ground
        if(collision.gameObject.layer == LayerMask.NameToLayer("Ground"))activeThis.SetActive(true);
    }
    public void SetInPartent()
    {
        //Este emtodo recoloca en su padre a la moneda al ser coleccionada
        transform.SetParent(startParent);
        transform.localPosition = Vector2.zero;
    }
}
