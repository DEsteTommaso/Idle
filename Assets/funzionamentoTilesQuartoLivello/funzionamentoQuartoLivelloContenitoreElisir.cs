using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class funzionamentoQuartoLivelloContenitoreElisir : MonoBehaviour
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
        if (singleton.CompratoQuartoLivelloContenitoreElisir) { 
        //domando valori livello
        a = singleton.QuartoLivelloContenitore;

        //domando livelloEstrazione singleton
        lev = singleton.LivelloQuartoLivelloCapienzaContenitoreElisir;

        singleton.QuartoLivelloContenitoreElisir = a[lev];
        singleton.aggiornamentoContenitoreElisir();
}
    }
}
