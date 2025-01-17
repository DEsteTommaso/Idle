using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pulsanteEroe2 : MonoBehaviour
{
    public Button pulsante;
    singleton singleton;
    public GameObject immagine;
    public GameObject prezzo;
    public GameObject selezione;

    public AudioClip accettato;
    public AudioClip rifiutato;
    private AudioSource pulsanteAudio;

    private Text testoSelezione;

    // Start is called before the first frame update
    void Start()
    {
        singleton = singleton.Instance;
        pulsante.onClick.AddListener(HandleButton);
        testoSelezione = selezione.GetComponent<Text>();

        pulsanteAudio = gameObject.GetComponent<AudioSource>();

        if (singleton.CompratoPersonaggio2)
        {
            selezione.SetActive(true);
            immagine.SetActive(false);
            prezzo.SetActive(false);
            if (singleton.SelezionatoPersonaggio2)
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
        if (!singleton.SelezionatoPersonaggio2)
            if (singleton.Lingua.Equals("it"))
                testoSelezione.text = "Seleziona";
            else if (singleton.Lingua.Equals("en"))
                testoSelezione.text = "Select";
    }

    // Update is called once per frame
    private void HandleButton()
    {
        if (!singleton.CompratoPersonaggio2)
        {
            if (singleton.Moneta >= 40000)
            {
                resetSelezionamento();
                singleton.removeMoneta(40000);
                singleton.CompratoPersonaggio2 = true;
                singleton.SelezionatoPersonaggio2 = true;

                if (singleton.Lingua.Equals("it"))
                    testoSelezione.text = "Gia' selezionato";
                else if (singleton.Lingua.Equals("en"))
                    testoSelezione.text = "Already selected";
                accettatoSuono();

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
            singleton.SelezionatoPersonaggio2 = true;

            accettatoSuono();

            if (singleton.Lingua.Equals("it"))
                testoSelezione.text = "Gia' selezionato";
            else if (singleton.Lingua.Equals("en"))
                testoSelezione.text = "Already selected";
        }

    }

    private void resetSelezionamento()
    {
        singleton.SelezionatoPersonaggio1 = false;
        singleton.SelezionatoPersonaggio2 = false;
        singleton.SelezionatoPersonaggio3 = false;
    }

    private void accettatoSuono()
    {

            if (pulsanteAudio != null)
                pulsanteAudio.PlayOneShot(accettato, singleton.Suono);
    }
}
