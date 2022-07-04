
using UnityEngine;

public class ScaleEverthing : MonoBehaviour
{
    //Este script tiene la funcion de que un objeto hijo ignore la escala de su padre
    public Transform parent;
    public enum Method {Exacto , Multiplicativo}
    public Method metodo;
    private void Update()
    {
        switch (metodo)
        {
            case Method.Exacto:
                transform.localScale = new Vector2(parent.localScale.x, transform.localScale.y);
                break;
            case Method.Multiplicativo:
                if(parent.localScale.x > 0) transform.localScale = new Vector2(transform.localScale.x, transform.localScale.y);
                else if(parent.localScale.x < 0) transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
                break;
            default:
                break;
        }
        
    }
}
