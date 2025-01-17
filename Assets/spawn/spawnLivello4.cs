using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class spawnLivello4 : MonoBehaviour
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
        tempo = singleton.QuartoLivelloSpawn[singleton.LivelloQuartoLivelloVelocitaSpawn];
        //se entra nel secondo if non potrà più entrare
        if (!spawnBool)
        {
            if (singleton.CompratoQuartoLivelloSpawn)
            {
                StartCoroutine(spawnMostri());
                spawnBool = true;
                testoMaxMostri.enabled = true;
            }
        }
        testoMaxMostri.text = singleton.MostriLivello4.ToString() + "/4";
    }

    IEnumerator spawnMostri()
    {
        yield return new WaitForSeconds(4f);
        while (true) {
            if (singleton.MostriLivello4 < 4)
                Instantiate(mostro, transform.position, Quaternion.identity);
            //Debug.Log("spawnato");
            yield return new WaitForSeconds(tempo);
         }
    }
}
