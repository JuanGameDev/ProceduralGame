
using UnityEngine;
using UnityEngine.UI;


public class CoinUI : MonoBehaviour
{
    [Header("Dependencias")]
    public Text coinDisplay;
    public Text shadowDisplay;
    [Header("Configuracion")]
    public int coinValue;
    void Start()
    {
        ////Aplicamos cantidad de monedas por defecto
        //coinDisplay.text = coinValue.ToString();
    }
    public void CoinUpdate()
    {
        //Mostramos de manera correcta los coin actuales
        
        //Obtenemos la distancia de coin value
        int coinValueLenght = coinValue.ToString().Length;
        //Reiniciamos el texto de monedas
        coinDisplay.text = "";
        for (int i = coinValueLenght; i < 6; i++)
        {
            //Por cada caracter restante agregamos un cero a la izquierda
            coinDisplay.text += "0";
        }
        //Finalmente ponemos el valor real de las monedas
        coinDisplay.text += coinValue.ToString();
        shadowDisplay.text = coinDisplay.text;
    }
    public void CoinUp()
    {
        //Aumentamos el valor de las coin
        coinValue++;
        CoinUpdate();
    }
    public void CoinDown(int value)
    {
        //Reducimos el valor de las coin
        if (coinValue - value > 0) coinValue -= value;
        else coinValue = 0;
        //
        CoinUpdate();
    }
}
