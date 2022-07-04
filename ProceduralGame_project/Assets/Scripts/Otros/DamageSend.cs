
using UnityEngine;

public class DamageSend : MonoBehaviour
{
    [Header("Configuracion")]
    public int damage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Enviamos el da�o al objeto Hurt
        Health health = collision.GetComponent<Health>();
        if(health != null)
        {
            //Asignamos de que direccion viene el golpe para mirar hacia el
            int direction;
            if (transform.parent.position.x > collision.transform.position.x) direction = 1;
            else direction = -1;
            //Mandamos el metodo para aplicar da�o y empuje
            health.SendDamage(damage , direction);
        }
    }
}
