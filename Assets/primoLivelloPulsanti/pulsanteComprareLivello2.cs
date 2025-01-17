using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class pulsanteComprareLivello2 : MonoBehaviour
{
    public Button pulsante;
    public GameObject gameObj;
    public GameObject cameraGameObject;
    private CameraActions.PanPinchCameraMovement c;

    public AudioClip accettato;
    public AudioClip rifiutato;
    private AudioSource pulsanteAudio;

    singleton singleton;
    // Start is called before the first frame update
    void Start()
    {
        singleton = singleton.Instance;
        c = cameraGameObject.GetComponent<CameraActions.PanPinchCameraMovement>();

        pulsanteAudio = gameObject.GetComponent<AudioSource>();

        pulsante.onClick.AddListener(HandleButtonClick); 
        
        if (singleton.CompratoPrimoLivelloNuovoLivello)
        {
            gameObj.SetActive(false);
        }
    }


    private void HandleButtonClick()
    {
        float i = singleton.Moneta;
        if (i >= 1000)
        {
            singleton.removeMoneta(1000);

                if (pulsanteAudio != null)
                    pulsanteAudio.PlayOneShot(accettato, singleton.Suono);

            //segnare che è stato comprato
            singleton.CompratoPrimoLivelloNuovoLivello = true;

            c.refresh();
            //attivazione pulsanti

            gameObj.SetActive(false);
        }
        else
            if (pulsanteAudio != null)
                pulsanteAudio.PlayOneShot(rifiutato, singleton.Suono);
    }

}
