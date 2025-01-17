using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class funzionamentoTerzoLivelloContenitoreMunizioni : MonoBehaviour
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
        if (singleton.CompratoTerzoLivelloContenitoreMunizioni) { 
        //domando valori livello
        a = singleton.TerzoLivelloContenitore;

        //domando livelloEstrazione singleton
        lev = singleton.LivelloTerzoLivelloCapienzaContenitoreMunizioni;

        singleton.TerzoLivelloContenitoreMunizioni = a[lev];
        singleton.aggiornamentoContenitoreMunizioni();
}
    }
}
