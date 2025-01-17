using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class imageQuartoLivelloProduzioneMetallo : MonoBehaviour
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
        //se entra nel secondo if non potr� pi� entrare
        if (!spawnBool)
        {
            if (singleton.CompratoQuartoLivelloProduzioneMetallo)
            {
                image.enabled = true;
                spawnBool = true;
            }
            else
            {
                image.enabled = false;

            }
        }

    }
}
