using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class upgradeCapienzaMunizioniLivello5 : MonoBehaviour
{
    public Text livello;
    public Text prezzo;
    public Text frequenza;
    public Button pulsante;
    singleton singleton;
    int liv;

    public AudioClip accettato;
    public AudioClip rifiutato;
    private AudioSource pulsanteAudio;

    // Start is called before the first frame update
    void Start()
    {
        singleton = singleton.Instance;
        pulsante.onClick.AddListener(HandleButtonClick);

        pulsanteAudio = gameObject.GetComponent<AudioSource>();

        refresh();
    }



    string FormatValueWithK(int valore)
    {
        if (valore >= 1000)
        {
            float valoreInK = valore / 1000.0f;
            return valoreInK.ToString("0.0") + "k";
        }
        else
        {
            return valore.ToString();
        }
    }


    private void HandleButtonClick()
    {
        float i = singleton.Moneta;
        if (liv <= 10)
        {
            if (i >= singleton.QuintoLivelloProduzioneEContenitoreSoldi[liv])
            {
                singleton.removeMoneta(singleton.QuintoLivelloProduzioneEContenitoreSoldi[liv]);

                //segnare che è stato comprato l'upgrade (assegno direttamente liv visto che è il livello corrente +1)
                singleton.LivelloQuintoLivelloCapienzaContenitoreMunizioni = liv;

                    if (pulsanteAudio != null)
                    pulsanteAudio.PlayOneShot(accettato, singleton.Suono);

                refresh();
            }
            else
                if (pulsanteAudio != null)
                pulsanteAudio.PlayOneShot(rifiutato, singleton.Suono);
        }
    }

    private void refresh()
    {
        liv = singleton.LivelloQuintoLivelloCapienzaContenitoreMunizioni + 1;
        if (liv >= 11)
            prezzo.text = "MAX";
        else
            prezzo.text = FormatValueWithK(singleton.QuintoLivelloProduzioneEContenitoreSoldi[liv]);

        //scrivo il nuovo Livello
        if (singleton.Lingua.Equals("it"))
            livello.text = "Livello " + (liv - 1);
        else if (singleton.Lingua.Equals("en"))
            livello.text = "Level " + (liv - 1);

        if (singleton.Lingua.Equals("it"))
            frequenza.text = singleton.QuintoLivelloContenitore[liv - 1].ToString() + " Colpi magici";
        else if (singleton.Lingua.Equals("en"))
            frequenza.text = singleton.QuintoLivelloContenitore[liv - 1].ToString() + " Magic shots";

    }
}
