using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class funzionamentoQuintoLivelloContenitoreElisir : MonoBehaviour
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
        if (singleton.CompratoQuintoLivelloContenitoreElisir) { 
        //domando valori livello
        a = singleton.QuintoLivelloContenitore;

        //domando livelloEstrazione singleton
        lev = singleton.LivelloQuintoLivelloCapienzaContenitoreElisir;

        singleton.QuintoLivelloContenitoreElisir = a[lev];
        singleton.aggiornamentoContenitoreElisir();
}
    }
}
