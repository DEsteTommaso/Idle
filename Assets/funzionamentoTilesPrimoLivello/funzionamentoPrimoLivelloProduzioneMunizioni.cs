using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class funzionamentoPrimoLivelloProduzioneMunizioni : MonoBehaviour
{
    Dictionary<int, int> a;
    singleton singleton;
    public GameObject testo;
    public Button pulsante;

    public Transform contenitoreElisir;
    public Transform contenitoreMetallo;

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
        lev = singleton.LivelloPrimoLivelloQuantitaProduzioneMunizioni;

    }

    IEnumerator estrazione()
    {
        while (true)
        {
            if (singleton.Ads3)
                yield return new WaitForSeconds(1f);
            else
                yield return new WaitForSeconds(3f);

            if (singleton.CompratoPrimoLivelloProduzioneMunizioni && singleton.getContenitoreMunizioni() >= singleton.Munizione + a[lev] && (singleton.Elisir - a[lev]) >= 0 && (singleton.Metallo - a[lev] >= 0))
            {
                singleton.removeElisir(a[lev]);
                singleton.removeMetallo(a[lev]);
                singleton.addMunizione(a[lev]);

                GameObject newTextObject = Instantiate(testo, transform.position + Vector3.up, Quaternion.identity);
                TextMeshPro testoCaratteristica = newTextObject.GetComponent<TextMeshPro>();

                GameObject elisir = Instantiate(testo, contenitoreElisir.position + Vector3.up, Quaternion.identity);
                TextMeshPro testoCaratteristicaElisir = elisir.GetComponent<TextMeshPro>();

                GameObject metallo = Instantiate(testo, contenitoreMetallo.position + Vector3.up, Quaternion.identity);
                TextMeshPro testoCaratteristicaMetallo = metallo.GetComponent<TextMeshPro>();


                testoCaratteristica.text = "+" + a[lev].ToString();
                testoCaratteristicaElisir.text = "-" + a[lev].ToString();
                testoCaratteristicaMetallo.text = "-" + a[lev].ToString();

                newTextObject.SetActive(true);
                if (singleton.CompratoPrimoLivelloContenitoreElisir)
                    elisir.SetActive(true);
                if (singleton.CompratoPrimoLivelloContenitoreMetallo)
                    metallo.SetActive(true);
                yield return new WaitForSeconds(0.5f);
                newTextObject.SetActive(false);
                elisir.SetActive(false);
                metallo.SetActive(false);

                Destroy(newTextObject);
                Destroy(elisir);
                Destroy(metallo);

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
        if (singleton.CompratoPrimoLivelloProduzioneMunizioni && singleton.getContenitoreMunizioni() >= singleton.Munizione + a[lev] && (singleton.Elisir - a[lev]) >= 0 && (singleton.Metallo - a[lev] >= 0))
        {
            singleton.removeElisir(a[lev]);
            singleton.removeMetallo(a[lev]);
            singleton.addMunizione(a[lev]);

            GameObject newTextObject = Instantiate(testo, transform.position + Vector3.up, Quaternion.identity);
            TextMeshPro testoCaratteristica = newTextObject.GetComponent<TextMeshPro>();

            GameObject elisir = Instantiate(testo, contenitoreElisir.position + Vector3.up, Quaternion.identity);
            TextMeshPro testoCaratteristicaElisir = elisir.GetComponent<TextMeshPro>();

            GameObject metallo = Instantiate(testo, contenitoreMetallo.position + Vector3.up, Quaternion.identity);
            TextMeshPro testoCaratteristicaMetallo = metallo.GetComponent<TextMeshPro>();


            testoCaratteristica.text = "+" + a[lev].ToString();
            testoCaratteristicaElisir.text = "-" + a[lev].ToString();
            testoCaratteristicaMetallo.text = "-" + a[lev].ToString();

            newTextObject.SetActive(true);
            if (singleton.CompratoPrimoLivelloContenitoreElisir)
                elisir.SetActive(true);
            if (singleton.CompratoPrimoLivelloContenitoreMetallo)
                metallo.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            newTextObject.SetActive(false);
            elisir.SetActive(false);
            metallo.SetActive(false);

            Destroy(newTextObject);
            Destroy(elisir);
            Destroy(metallo);

            //Debug.Log("Aggiunto " + a[lev]);
        }
    }


}
