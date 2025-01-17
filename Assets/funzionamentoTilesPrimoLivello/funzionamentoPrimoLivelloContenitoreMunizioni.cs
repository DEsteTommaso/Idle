using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class funzionamentoPrimoLivelloContenitoreMunizioni : MonoBehaviour
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
        if (singleton.CompratoPrimoLivelloContenitoreMunizioni) { 
        //domando valori livello
        a = singleton.PrimoLivelloContenitore;

        //domando livelloEstrazione singleton
        lev = singleton.LivelloPrimoLivelloCapienzaContenitoreMunizioni;

        singleton.PrimoLivelloContenitoreMunizioni = a[lev];
        singleton.aggiornamentoContenitoreMunizioni();
}
    }
}
