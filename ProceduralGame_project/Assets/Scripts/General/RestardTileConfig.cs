
using UnityEngine;

public class RestardTileConfig : MonoBehaviour
{
    [Header("Dependencias")]
    public GameObject[] integrants;
    [HideInInspector]public Vector2[] integrantStartPos;
    private bool only = true;
    private void OnEnable()
    {
        //Guardamos las posiciones inciales de los integrantes del Tile
        if (only)
        {
            integrantStartPos = new Vector2[integrants.Length];
            for (int i = 0; i < integrants.Length; i++)
            {
                integrantStartPos[i] = integrants[i].transform.localPosition;
            }
            only = false;
        }
        //Enviamos el mensaje de reseteo a los objetos que conforman el Tile
        //Ademas movemos los integrantes a su posicion original con respecto al tile
        for (int i = 0; i < integrants.Length; i++)
        {
            integrants[i].SetActive(true);
            integrants[i].transform.localPosition = integrantStartPos[i];

            try { integrants[i].SendMessage("ResetValues"); }
            catch { Debug.Log("[!]El objeto en el orden " + i + " no recibio el mensaje"); }
        }
    }
}
