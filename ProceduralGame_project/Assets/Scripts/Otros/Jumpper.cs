
using UnityEngine;

public class Jumpper : MonoBehaviour
{
    public Vector2 forceVector;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            //Verificamos que el jugador venga de arriba
            if(collision.transform.position.y > transform.position.y)
            {
                //Si la colision es correcta aplicamos la fuerza
                Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
                rb.velocity = new Vector2(rb.velocity.x, 0);
                rb.AddForce(forceVector, ForceMode2D.Impulse);
            }
        }
    }
}
