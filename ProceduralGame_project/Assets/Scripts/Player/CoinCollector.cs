
using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    [Header("Dependencias")]
    public GameObject particlePickUp;
    public CoinUI coinUI_cs;
    [Header("configuracion")]
    public int coinPoolCount;
    //zonaPrivada
    private GameObject[] staticParticle;
    private void Start()
    {
        //Llenamos la pool
        staticParticle = new GameObject[coinPoolCount];
        for (int i = 0; i < staticParticle.Length; i++)
        {
            //Instanciamos las particulas
            staticParticle[i] = Instantiate(particlePickUp , transform.position , Quaternion.identity , 
                this.transform);
            //Desactivamos las particulas
            staticParticle[i].SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Usaremos una particula que sea nuestro hijo
        for (int i = 0; i < staticParticle.Length; i++)
        {
            if (staticParticle[i].transform.parent == this.transform) 
            {
                //Le quitamos el padre a la particula
                staticParticle[i].transform.SetParent(null);
                //ubicamos la particula en donde corresponde
                staticParticle[i].transform.position = collision.transform.position;
                //La activamos
                staticParticle[i].SetActive(true);
                //rompemos
                break;
            }
            //Si la particula no es nuestro hijo , lo reincorporamos 
            else
            {
                staticParticle[i].transform.SetParent(this.transform);
            }
        }
        //Respecto al Coin:

        //Metemos el coin a su padre CoinBoom, atravez de su metodo propio
        collision.transform.parent.GetComponent<coinActive>().SetInPartent();
        //Desactivamos el coin obtenido
        collision.gameObject.transform.parent.gameObject.SetActive(false);

        //Aumentamos la cantidad de monedas obtenidas
        coinUI_cs.CoinUp();
    }
}
