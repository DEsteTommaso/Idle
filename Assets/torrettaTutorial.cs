using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tprrettaTutorial : MonoBehaviour
{

    public GameObject arma;
    armaTutorial armaScript;
    singleton singleton;
    private Animator animazione;
    private int precedenteSelezionato = 1;


    // Start is called before the first frame update
    void Start()
    {
        singleton = singleton.Instance;
        animazione = gameObject.GetComponent<Animator>();
        armaScript = arma.GetComponent<armaTutorial>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.CompareTag("personaggioAttivo"))
        {
            /*Debug.Log("Personaggio selezionato 1: " + singleton.SelezionatoPersonaggio1);
            Debug.Log("Personaggio selezionato 2: " + singleton.SelezionatoPersonaggio2);
            Debug.Log("Personaggio selezionato 3: " + singleton.SelezionatoPersonaggio3);*/

            if (singleton.SelezionatoPersonaggio1 && precedenteSelezionato != 1)
                animazione.Play("idle-Uomo");
            else if (singleton.SelezionatoPersonaggio2 && precedenteSelezionato != 2)
                animazione.Play("idle-Gufo");
            else if (singleton.SelezionatoPersonaggio3 && precedenteSelezionato != 3)
                animazione.Play("idle-Mr_Coniglio");

            if (singleton.SelezionatoPersonaggio1)
                precedenteSelezionato = 1;
            else if (singleton.SelezionatoPersonaggio2)
                precedenteSelezionato = 2;
            else if (singleton.SelezionatoPersonaggio3)
                precedenteSelezionato = 3;

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "nemico")
            armaScript.aggiungereMostroCoda(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "nemico")
        {
            armaScript.rimuovereMostroCoda();
        }
    }
}
