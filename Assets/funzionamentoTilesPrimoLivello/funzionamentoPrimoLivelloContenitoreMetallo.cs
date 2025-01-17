using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class funzionamentoPrimoLivelloContenitoreMetallo : MonoBehaviour
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
        if (singleton.CompratoPrimoLivelloContenitoreMetallo) { 
        //domando valori livello
        a = singleton.PrimoLivelloContenitore;

        //domando livelloEstrazione singleton
        lev = singleton.LivelloPrimoLivelloCapienzaProduzioneMetallo;

        singleton.PrimoLivelloContenitoreMetallo = a[lev];
        singleton.aggiornamentoContenitoreMetallo();
}
    }
}
