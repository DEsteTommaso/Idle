using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class pulsanteComprareLivello3 : MonoBehaviour
{
    public Button pulsante;
    public GameObject gameObj;

    public GameObject cameraGameObject;
    private CameraActions.PanPinchCameraMovement c;

    singleton singleton;

    public AudioClip accettato;
    public AudioClip rifiutato;
    private AudioSource pulsanteAudio;
    // Start is called before the first frame update
    void Start()
    {
        singleton = singleton.Instance;
        c = cameraGameObject.GetComponent<CameraActions.PanPinchCameraMovement>();

        pulsanteAudio = gameObject.GetComponent<AudioSource>();

        pulsante.onClick.AddListener(HandleButtonClick); 
        
        

    }

    private void Update()
    {
        if (singleton.CompratoPrimoLivelloNuovoLivello) { 
            if (singleton.CompratoSecondoLivelloNuovoLivello)
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
        if (i >= 10000)
        {


            singleton.removeMoneta(10000);
            singleton.CompratoSecondoLivelloNuovoLivello = true;

                if (pulsanteAudio != null)
                    pulsanteAudio.PlayOneShot(accettato, singleton.Suono);

            c.refresh();
            //attivazione pulsanti

        }
        else
            if (pulsanteAudio != null)
                pulsanteAudio.PlayOneShot(rifiutato, singleton.Suono);
    }

}
