using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class funzionamentoQuintoLivelloContenitoreMetallo : MonoBehaviour
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
        if (singleton.CompratoQuintoLivelloContenitoreMetallo) { 
        //domando valori livello
        a = singleton.QuintoLivelloContenitore;

        //domando livelloEstrazione singleton
        lev = singleton.LivelloQuintoLivelloCapienzaProduzioneMetallo;

        singleton.QuintoLivelloContenitoreMetallo = a[lev];
        singleton.aggiornamentoContenitoreMetallo();
}
    }
}
