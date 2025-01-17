using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class castRicarica : MonoBehaviour
{
    public Image ricaricaArma;
    public Image ricaricaPersonaggio;

    public Button armaButton;
    public Button eroeButton;

    public Sprite[] immaginiRicarica;

    singleton singleton;

    private bool coroutineArma = true;
    private bool coroutineEroe = true;

    public GameObject pulsanti;
    private codiceImmaginiAbilita cd;
    // Start is called before the first frame update
    void Start()
    {
        singleton = singleton.Instance;
        cd = pulsanti.GetComponent<codiceImmaginiAbilita>();
        armaButton.onClick.AddListener(cliccatoArma);
        eroeButton.onClick.AddListener(cliccatoEroe);
    }

    // Update is called once per frame
    void Update()
    {
        if (singleton.AbilitaUsataArma) { 
            //se true vuol dire che è usata
            //Debug.Log("asdadasdasd");
        if (coroutineArma)
            {
                ricaricaArma.color = Color.white;

                coroutineArma = false;
                StartCoroutine(arma());
            }

        }

        if (singleton.AbilitaUsataEroe) { 
        
        if (coroutineEroe)
            {
                ricaricaPersonaggio.color = Color.white;
            
                coroutineEroe = false;
                StartCoroutine(eroe());
            }
        
        
        }

    }

    private void cliccatoArma()
    {
        if (!singleton.AbilitaUsataArma)
        {
            //Debug.Log("1");
            cd.abilitaArmaPulsanteClick();
        }
        
        
    }

    private void cliccatoEroe()
    {
        if (!singleton.AbilitaUsataEroe)
        {
            // Debug.Log("2");
            cd.abilitaEroePulsanteClick();
        }

    }


    IEnumerator arma()
    {
        for(int i = 0; i<immaginiRicarica.Length; i++)
        {
            ricaricaArma.sprite = immaginiRicarica[i];
            //ogni 10 millesimi di secondo quindi essendo 100 foto sono 10 secondi
            yield return new WaitForSeconds(0.10f);
        }
       
        singleton.AbilitaUsataArma = false;
        ricaricaArma.color = new Color(1f, 1f, 1f, 0f);
        coroutineArma = true;
    }

    IEnumerator eroe()
    {
        for(int i = 0; i<immaginiRicarica.Length; i++)
        {

            ricaricaPersonaggio.sprite = immaginiRicarica[i];
            //ogni 20 millesimi di secondo quindi essendo 100 foto sono 20 secondi
            yield return new WaitForSeconds(0.20f);
        }
        
        singleton.AbilitaUsataEroe = false;
        ricaricaPersonaggio.color = new Color(1f, 1f, 1f, 0f);
        coroutineEroe = true;
    }
}
