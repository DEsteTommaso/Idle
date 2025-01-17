using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class spawnLivello1 : MonoBehaviour
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
        tempo = singleton.PrimoLivelloSpawn[singleton.LivelloPrimoLivelloVelocitaSpawn];
        //se entra nel secondo if non potrà più entrare
        if (!spawnBool)
        {
            if (singleton.CompratoPrimoLivelloSpawn)
            {
                StartCoroutine(spawnMostri());
                spawnBool = true;
            }
        }

        testoMaxMostri.text = singleton.MostriLivello1.ToString() + "/10";
    }

    IEnumerator spawnMostri()
    {
        yield return new WaitForSeconds(4f);
        while (true) {
            if(singleton.MostriLivello1 < 10)
                Instantiate(mostro, transform.position, Quaternion.identity);
            //Debug.Log("spawnato");
            yield return new WaitForSeconds(tempo);
         }
    }
}
