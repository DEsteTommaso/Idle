using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class funzionamentoTerzoLivelloContenitoreMetallo : MonoBehaviour
{
    Dictionary<int, int> a;
    singleton singleton;
    private int lev = 1;

    // Start is called before the first frame update
    void Start()
    {
        singleton = singleton.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (singleton.CompratoTerzoLivelloContenitoreMetallo) { 
        //domando valori livello
        a = singleton.TerzoLivelloContenitore;

        //domando livelloEstrazione singleton
        lev = singleton.LivelloTerzoLivelloCapienzaProduzioneMetallo;

        singleton.TerzoLivelloContenitoreMetallo = a[lev];
        singleton.aggiornamentoContenitoreMetallo();
}
    }
}
