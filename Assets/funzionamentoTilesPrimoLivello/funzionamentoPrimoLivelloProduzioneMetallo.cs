using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class funzionamentoPrimoLivelloProduzioneMetallo : MonoBehaviour
{
    Dictionary<int, int> a;
    singleton singleton;
    public GameObject testo;
    public Button pulsante;
    private int lev = 1;

    // Start is called before the first frame update
    void Start()
    {
        singleton = singleton.Instance;
        pulsante.onClick.AddListener(click);
        StartCoroutine(estrazione());
    }

    // Update is called once per frame
    void Update()
    {
        //domando valori livello
        a = singleton.PrimoLivelloProduzione;

        //domando livello singleton
        lev = singleton.LivelloPrimoLivelloQuantitaProduzioneMetallo;

    }

    IEnumerator estrazione()
    {
        while (true)
        {
            if (singleton.Ads3)
                yield return new WaitForSeconds(1f);
            else
                yield return new WaitForSeconds(3f);

            if (singleton.CompratoPrimoLivelloProduzioneMetallo && singleton.getContenitoreMetallo() >= singleton.Metallo + a[lev])
            {
                singleton.addMetallo(a[lev]);
                GameObject newTextObject = Instantiate(testo, transform.position + Vector3.up, Quaternion.identity);
                TextMeshPro testoCaratteristica = newTextObject.GetComponent<TextMeshPro>();

                testoCaratteristica.text = "+"+a[lev].ToString();
                newTextObject.SetActive(true);
                yield return new WaitForSeconds(0.5f);
                newTextObject.SetActive(false);
                Destroy(newTextObject);

                //Debug.Log("Aggiunto " + a[lev]);
            }
        }
    }

    public void click()
    {
        StartCoroutine(funzioneClick());
    }

    IEnumerator funzioneClick()
    {
        if (singleton.CompratoPrimoLivelloProduzioneMetallo && singleton.getContenitoreMetallo() >= singleton.Metallo + a[lev])
        {
            singleton.addMetallo(a[lev]);
            GameObject newTextObject = Instantiate(testo, transform.position + Vector3.up, Quaternion.identity);
            TextMeshPro testoCaratteristica = newTextObject.GetComponent<TextMeshPro>();

            testoCaratteristica.text = "+" + a[lev].ToString();
            newTextObject.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            newTextObject.SetActive(false);
            Destroy(newTextObject);

            //Debug.Log("Aggiunto " + a[lev]);
        }
    }
}
