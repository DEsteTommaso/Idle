using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class pulsanteComprareLivello5 : MonoBehaviour
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
        pulsanteAudio = gameObject.GetComponent<AudioSource>();
        c = cameraGameObject.GetComponent<CameraActions.PanPinchCameraMovement>();
        pulsante.onClick.AddListener(HandleButtonClick);

        

    }

    private void Update()
    {
        if (singleton.CompratoTerzoLivelloNuovoLivello)
        {
            if (singleton.CompratoQuartoLivelloNuovoLivello)
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
        if (i >= 100000)
        {
            singleton.removeMoneta(100000);
            singleton.CompratoQuartoLivelloNuovoLivello = true;

            c.refresh();

            //attivazione pulsanti


                if (pulsanteAudio != null)
                    pulsanteAudio.PlayOneShot(accettato, singleton.Suono);
        }
        else
            if (pulsanteAudio != null)
                pulsanteAudio.PlayOneShot(rifiutato, singleton.Suono);
    }
}
