using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class funzionamentoQuartoLivelloContenitoreMetallo : MonoBehaviour
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
        if (singleton.CompratoQuartoLivelloContenitoreMetallo) { 
        //domando valori livello
        a = singleton.QuartoLivelloContenitore;

        //domando livelloEstrazione singleton
        lev = singleton.LivelloQuartoLivelloCapienzaProduzioneMetallo;

        singleton.QuartoLivelloContenitoreMetallo = a[lev];
        singleton.aggiornamentoContenitoreMetallo();
}
    }
}
