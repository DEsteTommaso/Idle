using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class funzionamentoSecondoLivelloContenitoreMetallo : MonoBehaviour
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
        if (singleton.CompratoSecondoLivelloContenitoreMetallo) { 
        //domando valori livello
        a = singleton.SecondoLivelloContenitore;

        //domando livelloEstrazione singleton
        lev = singleton.LivelloSecondoLivelloCapienzaProduzioneMetallo;

        singleton.SecondoLivelloContenitoreMetallo = a[lev];
        singleton.aggiornamentoContenitoreMetallo();
}
    }
}
