
using UnityEngine;
using UnityEngine.UI;


public class killsUI : MonoBehaviour
{
    [Header("Dependencias")]
    public Text killDisplay;
    public Text shadowDisplay;
    [Header("Configuracion")]
    public int killValue;
    void Start()
    {
        ////Aplicamos cantidad de monedas por defecto
        //coinDisplay.text = coinValue.ToString();
    }
    public void CoinUpdate()
    {
        //Mostramos de manera correcta los coin actuales

        //Obtenemos la distancia de coin value
        int killValueLenght = killValue.ToString().Length;
        //Reiniciamos el texto de monedas
        killDisplay.text = "";
        for (int i = killValueLenght; i < 6; i++)
        {
            //Por cada caracter restante agregamos un cero a la izquierda
            killDisplay.text += "0";
        }
        //Finalmente ponemos el valor real de las monedas
        killDisplay.text += killValue.ToString();
        shadowDisplay.text = killDisplay.text;
    }
    public void KillUp()
    {
        //Aumentamos el valor de las coin
        killValue++;
        CoinUpdate();
    }
}
