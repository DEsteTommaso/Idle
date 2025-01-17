using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class personaggio : MonoBehaviour
{

    public GameObject arma;
    arma_Scena1 armaScript;

    torretta1_scena1 torretta1Script;
    torretta2_scena1 torretta2Script;
    torretta3_scena1 torretta3Script;
    torretta4_scena1 torretta4Script;

    public GameObject testoInglese;
    public GameObject testoItaliano;


    singleton singleton;
    private Animator animazione;
    private int precedenteSelezionato = 1;

    private BoxCollider2D boxCollider;

    private bool entratoMostro = false;

    private Collider2D collisione;


    // Start is called before the first frame update
    void Start()
    {
       singleton = singleton.Instance;
        boxCollider = gameObject.GetComponent<BoxCollider2D>();
        if (gameObject.CompareTag("personaggioAttivo"))
        {
            if (singleton.Lingua.Equals("it"))
                testoItaliano.SetActive(true);
            else if (singleton.Lingua.Equals("en"))
                testoInglese.SetActive(true);
        }


       animazione = gameObject.GetComponent<Animator>();
        if(gameObject.CompareTag("torrettaArma2"))
            torretta1Script = arma.GetComponent<torretta1_scena1>();
        else if(gameObject.CompareTag("torrettaArma3"))
            torretta2Script = arma.GetComponent<torretta2_scena1>();
        else if (gameObject.CompareTag("torrettaArma4"))
            torretta3Script = arma.GetComponent<torretta3_scena1>();
        else if (gameObject.CompareTag("torrettaArma5"))
            torretta4Script = arma.GetComponent<torretta4_scena1>();
        else
            armaScript = arma.GetComponent<arma_Scena1>();
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

        if(collisione == null)
        {
            entratoMostro = false;

            boxCollider.enabled = false;
            boxCollider.enabled = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "nemico" && !entratoMostro)
        {
            //se non esiste più il mostro
            collisione = collision;

            if (gameObject.CompareTag("torrettaArma2"))
                torretta1Script.aggiungereMostroCoda(collision);
            else if (gameObject.CompareTag("torrettaArma3"))
                torretta2Script.aggiungereMostroCoda(collision);
            else if (gameObject.CompareTag("torrettaArma4"))
                torretta3Script.aggiungereMostroCoda(collision);
            else if (gameObject.CompareTag("torrettaArma5"))
                torretta4Script.aggiungereMostroCoda(collision);
            else
                armaScript.aggiungereMostroCoda(collision);

            //vuol dire che rileva solo il primo mostro e poi non più
            entratoMostro = true;
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "nemico") {

            entratoMostro = false;

            boxCollider.enabled = false;
            boxCollider.enabled = true;
        }
    }
}
