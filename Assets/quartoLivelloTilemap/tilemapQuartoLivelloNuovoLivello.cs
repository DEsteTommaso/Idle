using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class tilemapQuartoLivelloNuovoLivello : MonoBehaviour
{
    public TilemapRenderer Tilemap;
    singleton singleton;
    private bool spawnBool = false;

    // Start is called before the first frame update
    void Start()
    {
        singleton = singleton.Instance;
    }

    void LateUpdate()
    {
        //se entra nel secondo if non potr� pi� entrare
        if (!spawnBool)
        {
            if (singleton.CompratoQuartoLivelloNuovoLivello)
            {
                Tilemap.enabled = true;
                spawnBool = true;
            }
            else
            {
                Tilemap.enabled = false;

            }
        }

    }
}
