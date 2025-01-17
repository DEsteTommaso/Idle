using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class managerTutorial : MonoBehaviour
{
    public GameObject tutorial;

    public GameObject testo1;
    public GameObject testo2;
    public GameObject testo3;
    public GameObject testo4;
    public GameObject testo5;
    public GameObject testo6;
    public GameObject testo7;
    public GameObject testo8;
    public GameObject testo9;
    public GameObject testo10;
    public GameObject testo11;
    public GameObject testo12;
    public GameObject testo13;
    public GameObject testo14;
    public GameObject testo15;
    public GameObject testo16;
    public GameObject testo17;
    public GameObject testo18;

    public GameObject mostro;

    public GameObject frecciaArmiEroi;

    public GameObject frecciaUpgrade;

    public GameObject frecciaDungeon;

    public Transform pannelloDialogo;
    public Image pannelloDialogoImage;
    public Image immagine;
    public GameObject testoDev;

    public AudioClip avanti;
    private AudioSource audioSource;


    singleton singleton;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        tutorial.SetActive(true);
        singleton = singleton.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            //se cliccato allora seleziona il testo successivo
            if (testo1.activeSelf)
            {
                //Debug.Log("Posizione: " + pannelloDialogo.position);

                audioSource.PlayOneShot(avanti, singleton.Suono);
                azzerare();
                testo2.SetActive(true);
            }
            else if (testo2.activeSelf)
            {
                audioSource.PlayOneShot(avanti, singleton.Suono);
                azzerare();
                testo3.SetActive(true);
                //attiva per il terzo
                singleton.EscaTutorial = true;
            }
            else if (testo3.activeSelf)
            {
                audioSource.PlayOneShot(avanti, singleton.Suono);
                azzerare();
                testo4.SetActive(true);
                singleton.TorrettaTutorial = true;
            }
            else if (testo4.activeSelf)
            {
                audioSource.PlayOneShot(avanti, singleton.Suono);
                azzerare();
                testo5.SetActive(true);
                singleton.MuroTutorial = true;
            }
            else if (testo5.activeSelf)
            {
                audioSource.PlayOneShot(avanti, singleton.Suono);
                azzerare();
                mostro.SetActive(true);
                testo6.SetActive(true);
                singleton.MostroTutorial = true;
            }
            else if (testo6.activeSelf)
            {
               
                if (mostro == null)
                {
                    audioSource.PlayOneShot(avanti, singleton.Suono);
                    azzerare();
                    testo7.SetActive(true);
                }
                
            }
            else if (testo7.activeSelf)
            {
                audioSource.PlayOneShot(avanti, singleton.Suono);
                azzerare();
                testo8.SetActive(true);
                singleton.ColpoTutorial = true;
            }
            else if (testo8.activeSelf)
            {
                if (!singleton.ColpoTutorial) {
                    audioSource.PlayOneShot(avanti, singleton.Suono);
                    azzerare();
                testo9.SetActive(true);
                singleton.RisorseTutorial = true;
                }
            }
            else if (testo9.activeSelf)
            {
                if (!singleton.RisorseTutorial)
                {
                    audioSource.PlayOneShot(avanti, singleton.Suono);
                    azzerare();
                    testo10.SetActive(true);
                    frecciaArmiEroi.SetActive(true);
                }
                
            }
            else if (testo10.activeSelf)
            {
                audioSource.PlayOneShot(avanti, singleton.Suono);
                azzerare();
                testo11.SetActive(true);
                frecciaUpgrade.SetActive(true);
            }
            else if (testo11.activeSelf)
            {
                audioSource.PlayOneShot(avanti, singleton.Suono);
                azzerare();
                testo12.SetActive(true);
                frecciaDungeon.SetActive(true);
            }
            else if (testo12.activeSelf)
            {
                audioSource.PlayOneShot(avanti, singleton.Suono);
                azzerare();
                testo13.SetActive(true);
            }
            else if (testo13.activeSelf)
            {
                audioSource.PlayOneShot(avanti, singleton.Suono);
                azzerare();
                testo14.SetActive(true);
            }
            else if (testo14.activeSelf)
            {

                audioSource.PlayOneShot(avanti, singleton.Suono);
                //pannelloDialogo.position.y =  0;
                Debug.Log(pannelloDialogo.position);
                //pannelloDialogo.position = new Vector2(768, 1600);
                pannelloDialogoImage.color = Color.black;
                immagine.color = Color.black;
                testoDev.GetComponent<Text>().text = "DEV";

                azzerare();
                testo15.SetActive(true);
            }
            else if (testo15.activeSelf)
            {
                audioSource.PlayOneShot(avanti, singleton.Suono);
                azzerare();
                testo16.SetActive(true);
            }
            else if (testo16.activeSelf)
            {
                audioSource.PlayOneShot(avanti, singleton.Suono);
                azzerare();
                testo17.SetActive(true);
            }
            else if (testo17.activeSelf)
            {
                audioSource.PlayOneShot(avanti, singleton.Suono);
                azzerare();
                //chiusura tutorial
                testo18.SetActive(true);
            }
            else if (testo18.activeSelf)
            {
                //CARICARE SCENA
                SceneManager.LoadScene("Spawn");
            }

        }
    }


    public void azzerare()
    {
        testo1.SetActive(false);
        testo2.SetActive(false);
        testo3.SetActive(false);
        testo4.SetActive(false);
        testo5.SetActive(false);
        testo6.SetActive(false);
        testo7.SetActive(false);
        testo8.SetActive(false);
        testo9.SetActive(false);
        testo10.SetActive(false);
        testo11.SetActive(false);
        testo12.SetActive(false);
        testo13.SetActive(false);
        testo14.SetActive(false);
        testo15.SetActive(false);
        testo16.SetActive(false);
        testo17.SetActive(false);
        testo18.SetActive(false);

        //azzera anche i bool del singleton
        singleton.EscaTutorial = false;
        singleton.TorrettaTutorial = false;
        singleton.MuroTutorial = false;
        singleton.MostroTutorial = false;
        singleton.ColpoTutorial = false;
        singleton.RisorseTutorial = false;

        //azzero anche le frecce
        frecciaArmiEroi.SetActive(false);
        frecciaUpgrade.SetActive(false);
        frecciaDungeon.SetActive(false);

    }


}
