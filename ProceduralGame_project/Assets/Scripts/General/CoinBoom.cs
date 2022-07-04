
using UnityEngine;

public class CoinBoom : MonoBehaviour
{
    [Header("Configuracion")]
    public int coinCount;
    public float coinForce;
    [Header("Dependencias")]
    public GameObject coinObj;
    public Transform[] direcciones;
    //Variables privadas
    private bool fistTime = true;
    private GameObject[] localCoins;
    public Rigidbody2D[] localRb;
    private System.Random random;
    private Vector2 startPos;
    void Start()
    {
        //Solo la primera vez
        if (fistTime)
        {
            startPos = transform.localPosition;
            random = new System.Random();
            localCoins = new GameObject[coinCount];
            localRb = new Rigidbody2D[coinCount];
            for (int i = 0; i < localCoins.Length; i++)
            {
                //Instanciamos local
                localCoins[i] = Instantiate(coinObj, transform.position, Quaternion.identity
                    , this.transform);
                //Obtenemos rigidbodys
                localRb[i] = localCoins[i].GetComponent<Rigidbody2D>();
                //Desactivamos
                localCoins[i].SetActive(false);
            }
            fistTime = false;
        }
    }
    public void Boom()
    {
        //Recorremos los coins
        for (int i = 0; i < localCoins.Length; i++)
        {
            ////Si no esta dentro de nostros lo reincorporamos
            if (localCoins[i].transform.parent != this.transform)
            {
                //lo desactivamos
                localCoins[i].SetActive(false);
                //lo reubicamos
                localCoins[i].transform.SetParent(this.transform);
                localCoins[i].transform.localPosition = Vector2.zero;
            }
            //Si esta dentro de nostors , lo usamos
            if (localCoins[i].transform.parent == this.transform)
            {
                //lo sacamos de nostros
                localCoins[i].transform.SetParent(null);
                //lo activamos y lanzamos
                localCoins[i].SetActive(true);
                localRb[i].AddForce(direcciones[random.Next(0, direcciones.Length)].up *
                    coinForce, ForceMode2D.Impulse);
            }
        }
    }
}
