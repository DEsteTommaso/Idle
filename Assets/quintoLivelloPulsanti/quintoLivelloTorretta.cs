using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class quintoLivelloTorretta : MonoBehaviour
{
    public Button pulsante;
    public GameObject gameObj;
    singleton singleton;

    public AudioClip accettato;
    public AudioClip rifiutato;
    private AudioSource pulsanteAudio;

    // Start is called before the first frame update
    void Start()
    {
        singleton = singleton.Instance;
        pulsanteAudio = gameObject.GetComponent<AudioSource>();
        pulsante.onClick.AddListener(HandleButtonClick);

        
    }

    private void Update()
    {
        if (singleton.CompratoQuartoLivelloNuovoLivello)
        {
            if (singleton.CompratoQuintoLivelloTorretta)
            {
                gameObj.SetActive(false);
            }
            else
            {
                gameObj.SetActive(true);
            }
        }
        else
        {
            gameObj.SetActive(false);
        }
    }


    // Update is called once per frame
    private void HandleButtonClick()
    {
        float i = singleton.Moneta;
        if (i >= 75000)
        {
            singleton.CompratoQuintoLivelloTorretta = true;
            singleton.removeMoneta(75000);

                if (pulsanteAudio != null)
                    pulsanteAudio.PlayOneShot(accettato, singleton.Suono);
        }
        else
            if (pulsanteAudio != null)
                pulsanteAudio.PlayOneShot(rifiutato, singleton.Suono);
    }


}
