using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class pulsanteComprareLivello4 : MonoBehaviour
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
        pulsanteAudio = gameObject.GetComponent<AudioSource>();
        c = cameraGameObject.GetComponent<CameraActions.PanPinchCameraMovement>();
        pulsante.onClick.AddListener(HandleButtonClick); 
        
        
    }

    private void Update()
    {
if (singleton.CompratoSecondoLivelloNuovoLivello)
        {
            if (singleton.CompratoTerzoLivelloNuovoLivello)
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
        if (i >= 50000)
        {
            singleton.removeMoneta(50000);
            singleton.CompratoTerzoLivelloNuovoLivello = true;

            c.refresh();
                if (pulsanteAudio != null)
                    pulsanteAudio.PlayOneShot(accettato, singleton.Suono);

        }
        else
            if (pulsanteAudio != null)
                pulsanteAudio.PlayOneShot(rifiutato, singleton.Suono);
    }


}
