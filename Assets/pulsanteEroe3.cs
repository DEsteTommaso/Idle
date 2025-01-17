using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pulsanteEroe3 : MonoBehaviour
{
    public Button pulsante;
    singleton singleton;
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
        pulsante.onClick.AddListener(refresh);
        testoSelezione = selezione.GetComponent<Text>();

        pulsanteAudio = gameObject.GetComponent<AudioSource>();

        if (singleton.CompratoPersonaggio3)
        {
            selezione.SetActive(true);
            prezzo.SetActive(false);
            if (singleton.SelezionatoPersonaggio3)
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
        if (!singleton.SelezionatoPersonaggio3)
            if (singleton.Lingua.Equals("it"))
                testoSelezione.text = "Seleziona";
            else if (singleton.Lingua.Equals("en"))
                testoSelezione.text = "Select";
    }

    public void refresh()
    {
        if (singleton.CompratoPersonaggio3)
        {
            resetSelezionamento();
            singleton.SelezionatoPersonaggio3 = true;

            selezione.SetActive(true);
            prezzo.SetActive(false);

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
