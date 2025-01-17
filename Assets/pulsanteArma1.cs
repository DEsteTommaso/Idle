using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pulsanteArma1 : MonoBehaviour
{
    public Button pulsante;
    singleton singleton;
    public GameObject immagine;
    public GameObject prezzo;
    public GameObject selezione;

    private Text testoSelezione;

    // Start is called before the first frame update
    void Start()
    {
        singleton = singleton.Instance;
        pulsante.onClick.AddListener(HandleButton);
        testoSelezione = selezione.GetComponent<Text>();

        if (singleton.CompratoArma1)
        {
            selezione.SetActive(true);
            immagine.SetActive(false);
            prezzo.SetActive(false);
            if (singleton.SelezionatoArma1)
            {
                if (singleton.Lingua.Equals("it"))
                    testoSelezione.text = "Gia' selezionato";
                else if (singleton.Lingua.Equals("en"))
                    testoSelezione.text = "Already selected";
            }
            else
            {
                if (singleton.Lingua.Equals("it"))
                    testoSelezione.text = "Seleziona";
                else if (singleton.Lingua.Equals("en"))
                    testoSelezione.text = "Select";
            }
        }

    }

    private void Update()
    {
        //se non è selezionato
        if(!singleton.SelezionatoArma1)
            if (singleton.Lingua.Equals("it"))
                testoSelezione.text = "Seleziona";
            else if (singleton.Lingua.Equals("en"))
                testoSelezione.text = "Select";
    }

    // Update is called once per frame
    private void HandleButton()
    {
        if (!singleton.CompratoArma1)
        {
            if(singleton.Moneta >= 0)
                {
                resetSelezionamento();
                singleton.CompratoArma1 = true;
                singleton.SelezionatoArma1 = true;

                if (singleton.Lingua.Equals("it"))
                    testoSelezione.text = "Gia' selezionato";
                else if (singleton.Lingua.Equals("en"))
                    testoSelezione.text = "Already selected";

                selezione.SetActive(true);
                immagine.SetActive(false);
                prezzo.SetActive(false);
            }
        }
        else
        {
            resetSelezionamento();
            singleton.SelezionatoArma1 = true;
            if (singleton.Lingua.Equals("it"))
                testoSelezione.text = "Gia' selezionato";
            else if (singleton.Lingua.Equals("en"))
                testoSelezione.text = "Already selected";
        }
        
    }

    private void resetSelezionamento()
    {
        singleton.SelezionatoArma1 = false;
        singleton.SelezionatoArma2 = false;
        singleton.SelezionatoArma3 = false;
        singleton.SelezionatoArma4 = false;
        singleton.SelezionatoArma5 = false;
    }
}
