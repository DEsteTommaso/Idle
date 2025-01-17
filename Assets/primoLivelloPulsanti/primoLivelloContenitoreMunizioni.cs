using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class primoLivelloContenitoreMunizioni : MonoBehaviour
{
    public Button pulsante;
    public GameObject gameObj;
    public GameObject freccia;
    singleton singleton;

    public AudioClip accettato;
    public AudioClip rifiutato;
    private AudioSource pulsanteAudio;

    // Start is called before the first frame update
    void Start()
    {
        singleton = singleton.Instance;
        pulsante.onClick.AddListener(HandleButtonClick);

        pulsanteAudio = gameObject.GetComponent<AudioSource>();

        if (singleton.CompratoPrimoLivelloContenitoreMunizioni)
        {
            freccia.SetActive(false);
            gameObj.SetActive(false);
        }
    }

    // Update is called once per frame
    private void HandleButtonClick()
    {
        float i = singleton.Moneta;
        if (i >= 0)
        {
            singleton.CompratoPrimoLivelloContenitoreMunizioni = true;
            singleton.removeMoneta(0);

                if (pulsanteAudio != null)
                {
                    pulsanteAudio.PlayOneShot(accettato, singleton.Suono);
                }

            freccia.SetActive(false);
            // Avvia una coroutine per disattivare il GameObject dopo un breve ritardo
            gameObj.SetActive(false);
        }
        else
        {

                if (pulsanteAudio != null)
                {
                    pulsanteAudio.PlayOneShot(rifiutato, singleton.Suono);
                }
            
        }
    }

}
