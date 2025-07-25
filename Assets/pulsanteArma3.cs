using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pulsanteArma3 : MonoBehaviour
{
    public Button pulsante;
    singleton singleton;
    public GameObject immagine;
    public GameObject prezzo;
    public GameObject selezione;

    private Text testoSelezione;

    public AudioClip accettato;
    public AudioClip rifiutato;
    private AudioSource pulsanteAudio;

    // Start is called before the first frame update
    void Start()
    {
        singleton = singleton.Instance;
        pulsante.onClick.AddListener(HandleButton);
        testoSelezione = selezione.GetComponent<Text>();

        pulsanteAudio = gameObject.GetComponent<AudioSource>();

        if (singleton.CompratoArma3)
        {
            selezione.SetActive(true);
            immagine.SetActive(false);
            prezzo.SetActive(false);
            if (singleton.SelezionatoArma3)
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
        //se non � selezionato
        if (!singleton.SelezionatoArma3)
            if(singleton.Lingua.Equals("it"))
                testoSelezione.text = "Seleziona";
            else if (singleton.Lingua.Equals("en"))
                testoSelezione.text = "Select";
    }

    // Update is called once per frame
    private void HandleButton()
    {
        if (!singleton.CompratoArma3)
        {
            if (singleton.Moneta >= 25000)
            {
                resetSelezionamento();
                singleton.removeMoneta(25000);
                singleton.CompratoArma3 = true;
                singleton.SelezionatoArma3 = true;

                accettatoSuono();

                if (singleton.Lingua.Equals("it"))
                    testoSelezione.text = "Gia' selezionato";
                else if (singleton.Lingua.Equals("en"))
                    testoSelezione.text = "Already selected";

                selezione.SetActive(true);
                immagine.SetActive(false);
                prezzo.SetActive(false);
            }
            else

                if (pulsanteAudio != null)
                    pulsanteAudio.PlayOneShot(rifiutato, singleton.Suono);
        }
        else
        {
            resetSelezionamento();
            singleton.SelezionatoArma3 = true;

            accettatoSuono();

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

    private void accettatoSuono()
    {

            if (pulsanteAudio != null)
                pulsanteAudio.PlayOneShot(accettato, singleton.Suono);
    }
}
