using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class spawnLivello2 : MonoBehaviour
{
    public GameObject mostro;
    private bool spawnBool = false;
    singleton singleton;
    private float tempo;
    public Text testoMaxMostri;
    // Start is called before the first frame update
    void Start()
    {
        singleton = singleton.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        tempo = singleton.SecondoLivelloSpawn[singleton.LivelloSecondoLivelloVelocitaSpawn];
        //se entra nel secondo if non potr� pi� entrare
        if (!spawnBool)
        {
            if (singleton.CompratoSecondoLivelloSpawn)
            {
                StartCoroutine(spawnMostri());
                spawnBool = true;
                testoMaxMostri.enabled = true;
            }
        }
        testoMaxMostri.text = singleton.MostriLivello2.ToString() + "/8";
    }

    IEnumerator spawnMostri()
    {
        yield return new WaitForSeconds(4f);
        while (true) {
            if (singleton.MostriLivello2 < 8)
                Instantiate(mostro, transform.position, Quaternion.identity);
            //Debug.Log("spawnato");
            yield return new WaitForSeconds(tempo);
         }
    }
}
