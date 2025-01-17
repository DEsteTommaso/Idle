using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class tilemapTerzoLivelloTorretta : MonoBehaviour
{
    private SpriteRenderer image;
    singleton singleton;
    private bool spawnBool = false;

    // Start is called before the first frame update
    void Start()
    {
        singleton = singleton.Instance;
        image = GetComponent<SpriteRenderer>();
    }

    void LateUpdate()
    {
        //se entra nel secondo if non potrà più entrare
        if (!spawnBool)
        {
            if (singleton.CompratoTerzoLivelloTorretta)
            {
                image.enabled = true;
                spawnBool = true;

                foreach (Transform child in transform)
                {
                    child.gameObject.SetActive(true);
                }
            }
            else
            {
                image.enabled = false;

            }
        }

    }
}
