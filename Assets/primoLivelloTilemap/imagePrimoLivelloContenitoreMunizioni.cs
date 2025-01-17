using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class imagePrimoLivelloContenitoreMunizioni : MonoBehaviour
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
            if (singleton.CompratoPrimoLivelloContenitoreMunizioni)
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
