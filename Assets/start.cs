using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class start : MonoBehaviour
{
    private bool spawnParticelle = false;
    singleton singleton;

    // Start is called before the first frame update
    void Start()
    {
        singleton = singleton.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (!spawnParticelle)
        {
            //Se il primo livello è comparso allora iniziano anche le particelle
            if (singleton.CompratoPrimoLivelloSpawn)
            {
                ParticleSystem ps = GetComponent<ParticleSystem>();
                ps.Play();
                spawnParticelle = true;
            }
        }
    }
}
