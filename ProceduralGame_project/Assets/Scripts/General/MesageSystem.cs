
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MesageSystem : MonoBehaviour
{
    [Header("Dependencias")]
    public Text[] msgDisplay;
    [Header("Configuration")]
    public float waitTimeMsg;
    public float speed;

    public void SayMesagge(string msg = "Mensaje Vacio")
    {
        //Si el texto de abajo esta vacio , el mensaje ira ahi
        if(msgDisplay[0].text == "")
        {
            msgDisplay[0].text = msg;
            StartCoroutine(ShowMesagge(0));
        }
        //Si el texto de abajo esta lleno lo subimos , y el nuevo mensaje lo colocamos ahi
        else
        {
            msgDisplay[1].text = msgDisplay[0].text;
            msgDisplay[0].text = msg;
            StartCoroutine(ShowMesagge(0));
            StartCoroutine(DownMesagge(1));
        }
    }
    private IEnumerator ShowMesagge(int msgOrder)
    {
        //Creamos un color estatico
        Color color = Color.white;
        color.a = 0f;
        //Se lo asignamos al texto
        msgDisplay[msgOrder].color = color;
        //Aumentamos su alpha proceduralmente
        while (msgDisplay[msgOrder].color.a < 1f)
        {
            color.a += (speed * Time.deltaTime);
            msgDisplay[msgOrder].color = color;
            yield return null;
        }
        yield return new WaitForSecondsRealtime(waitTimeMsg);
        //Bajamos su alpha proceduralmente
        while (msgDisplay[msgOrder].color.a > 0f)
        {
            color.a -= (speed * Time.deltaTime);
            msgDisplay[msgOrder].color = color;
            yield return null;
        }
        msgDisplay[msgOrder].text = "";
    }
    private IEnumerator DownMesagge(int msgOrder)
    {
        //Creamos un color estatico
        Color color = Color.white;
        color.a = 1f;
        //Se lo asignamos al texto
        msgDisplay[msgOrder].color = color;
        yield return new WaitForSecondsRealtime(waitTimeMsg);
        //Bajamos su alpha proceduralmente
        while (msgDisplay[msgOrder].color.a > 0f)
        {
            color.a -= (speed * Time.deltaTime);
            msgDisplay[msgOrder].color = color;
            yield return null;
        }
        msgDisplay[msgOrder].text = "";
    }
}
