
using UnityEngine;

public class bala : MonoBehaviour
{
    [Header("Dependencias")]
    public GameObject particles;
    private void Start(){}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Instanciamos la particula
        if(particles != null)
        {
            Instantiate(particles, transform.position, Quaternion.identity);
        }
        //Nos Desactivamos
        gameObject.SetActive(false);
    }
}
