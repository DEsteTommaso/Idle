using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attivareGameObjScena2 : MonoBehaviour
{
    public GameObject eroe1;
    public GameObject eroe2;
    public GameObject eroe3;

    public GameObject arma1;
    public GameObject arma2;
    public GameObject arma3;
    public GameObject arma4;
    public GameObject arma5;

    singleton singleton;

    // Start is called before the first frame update
    void Awake()
    {
        singleton = singleton.Instance;

        if (singleton.SelezionatoPersonaggio1)
            eroe1.SetActive(true);
        else if (singleton.SelezionatoPersonaggio2)
            eroe2.SetActive(true);
        else if (singleton.SelezionatoPersonaggio3)
            eroe3.SetActive(true);

        if (singleton.SelezionatoArma1)
            arma1.SetActive(true);
        else if (singleton.SelezionatoArma2)
            arma2.SetActive(true);
        else if (singleton.SelezionatoArma3)
            arma3.SetActive(true);
        else if (singleton.SelezionatoArma4)
            arma4.SetActive(true);
        else if (singleton.SelezionatoArma5)
            arma5.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
