using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralGenerator : MonoBehaviour
{
    [Header("Depedences")]
    public GameObject Player;
    public MesageSystem mesageSystem_cs;
    public GameObject[] TileLevels;
    //[Header("Configuracion")]
    //variables locales
    private GameObject[] TileStatic;
    private int focusTileOrder;
    private float limitTile , limitUnable;
    private bool inExecute;
    private int afterTileOrder;
    //Vaqriables de Debbugin
    private int mapsCount;
    private void Start()
    {
        //Definir el tamaño de los Tiles locales
        TileStatic = new GameObject[TileLevels.Length];
        //Asignamos los Tiles a los Tiles Locales , para modificarlos sin afectar al Prefab
        for (int i = 0; i < TileLevels.Length; i++)
        {
            TileStatic[i] = Instantiate(TileLevels[i], Vector2.zero, Quaternion.identity, this.transform);
        }
        StartFirstTile();
    }
    private void StartFirstTile()
    {
        //Generamos un valor aleatorio
        int random = new System.Random().Next(0, TileLevels.Length);
        //y le asignamos ese valor al orden objetivo
        focusTileOrder = random;
        //Activamos el Tile seleccionado
        TileStatic[focusTileOrder].SetActive(true);
        //Asiganamos el limite del Tile antes de mostrar el Siguiente
        limitTile = TileStatic[focusTileOrder].transform.position.x + 15.97f;
        //Una vez activado el Tile , activamos al Jugador
        Player.SetActive(true);

        SetUnabledLimit();
    }
    private void LateUpdate()
    {
        //Si sobrepasamos el limite del Tile actual , activamos el siguiente tile
        //Solo si la corrutina no esta en ejecucion
        if (Player.transform.position.x > limitTile && !inExecute){
            StopAllCoroutines();
            StartCoroutine(Generate());
            inExecute = true;
            //Debuggin
            //mapsCount++;
            //Debug.Log("[!]Mapas Generados : " + mapsCount);
        }
        //Comprobamos si se supero el Unabled Time para desactivar Tile anterior
        if (Player.transform.position.x > limitUnable)
        {
            TileStatic[afterTileOrder].SetActive(false);
        }
    }
    private IEnumerator Generate()
    {
        //LLamada de Actualizacion
        SetUnabledLimit();
        //Generamos un valor aleatorio de un Tile no repetido
        int random = -1;
        do
        {
            random = new System.Random().Next(0, TileLevels.Length);
            yield return null;
        } while (random == focusTileOrder);
        //Movemos al nuevo Tile a la posicion correcta
        TileStatic[random].transform.position =
            new Vector2(TileStatic[focusTileOrder].transform.position.x + 24.5f, 0);
        //Ahora le asignamos ese valor al orden objetivo
        focusTileOrder = random;
        //Asignamos el limite del nuevo Tile
        limitTile = TileStatic[focusTileOrder].transform.position.x + 15.97f;
        //Finalmente Activamos el nuevo Tile
        TileStatic[focusTileOrder].SetActive(true);
        //Enviamos un mensaje 
        mesageSystem_cs.SayMesagge("Orden de Mapa Generado : " + focusTileOrder.ToString());

        inExecute = false; 
    }
    private void SetUnabledLimit()
    {
        //Actualizamos el Tile anterior , asi sabemos cal desactivar al ser superado
        afterTileOrder = focusTileOrder;
        limitUnable = TileStatic[afterTileOrder].transform.position.x + 35f;
    }
}
