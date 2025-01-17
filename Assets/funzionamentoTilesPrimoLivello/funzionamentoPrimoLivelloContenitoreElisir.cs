using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class funzionamentoPrimoLivelloContenitoreElisir : MonoBehaviour
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
        if (singleton.CompratoPrimoLivelloContenitoreElisir) { 
        //domando valori livello
        a = singleton.PrimoLivelloContenitore;

        //domando livelloEstrazione singleton
        lev = singleton.LivelloPrimoLivelloCapienzaContenitoreElisir;

        singleton.PrimoLivelloContenitoreElisir = a[lev];
        singleton.aggiornamentoContenitoreElisir();
}
    }

}
