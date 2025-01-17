using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class contenitoreMiglioramenti : MonoBehaviour
{
    //PRIMO LIVELLO
    public GameObject testo1;
    public GameObject spawn1;
    public GameObject estrattoreElisir1;
    public GameObject capienzaElisir1;
    public GameObject pietreMagiche1;
    public GameObject contenitorePietreMagiche1;
    public GameObject produttoreColpiMagici1;
    public GameObject contenitoreColpiMagici1;

    //SECONDO LIVELLO
    public GameObject testo2;
    public GameObject spawn2;
    public GameObject torretta2;
    public GameObject estrattoreElisir2;
    public GameObject capienzaElisir2;
    public GameObject pietreMagiche2;
    public GameObject contenitorePietreMagiche2;
    public GameObject produttoreColpiMagici2;
    public GameObject contenitoreColpiMagici2;

    //TERZO LIVELLO
    public GameObject testo3;
    public GameObject spawn3;
    public GameObject torretta3;
    public GameObject estrattoreElisir3;
    public GameObject capienzaElisir3;
    public GameObject pietreMagiche3;
    public GameObject contenitorePietreMagiche3;
    public GameObject produttoreColpiMagici3;
    public GameObject contenitoreColpiMagici3;

    //QUARTO LIVELLO
    public GameObject testo4;
    public GameObject spawn4;
    public GameObject torretta4;
    public GameObject estrattoreElisir4;
    public GameObject capienzaElisir4;
    public GameObject pietreMagiche4;
    public GameObject contenitorePietreMagiche4;
    public GameObject produttoreColpiMagici4;
    public GameObject contenitoreColpiMagici4;


    //QUINTO LIVELLO
    public GameObject testo5;
    public GameObject spawn5;
    public GameObject torretta5;
    public GameObject estrattoreElisir5;
    public GameObject capienzaElisir5;
    public GameObject pietreMagiche5;
    public GameObject contenitorePietreMagiche5;
    public GameObject produttoreColpiMagici5;
    public GameObject contenitoreColpiMagici5;

    //
    public GameObject[] listaGameObject;

    singleton singleton;

    private int posY = 0;

    private bool testo1Bool = false;
    private bool testo2Bool = false;
    private bool testo3Bool = false;
    private bool testo4Bool = false;
    private bool testo5Bool = false;


    public ScrollRect scroll;

    // Start is called before the first frame update


    public void refresh()
    {
        singleton = singleton.Instance;

        RectTransform rt = gameObject.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(990, 0);


        //RESETTIAMO ALTEZZA



        //Debug.Log("PosX: " + transform.position.x + " PosY: " + transform.position.y);

        //prima è da sommare 100 che è la distanza da top e ogni oggetto 30
        posY = 100;

        if (singleton.CompratoPrimoLivelloSpawn)
        {
            addY();
            testo1Bool = true;
            spawn1.SetActive(true);
        }
        if (singleton.CompratoPrimoLivelloEstrattoreElisir)
        {
            addY();
            testo1Bool = true;
            estrattoreElisir1.SetActive(true);
        }

        if (singleton.CompratoPrimoLivelloContenitoreElisir)
        {
            addY();
            testo1Bool = true;
            capienzaElisir1.SetActive(true);
        }

        if (singleton.CompratoPrimoLivelloProduzioneMetallo)
        {
            addY();
            testo1Bool = true;
            pietreMagiche1.SetActive(true);
        }

        if (singleton.CompratoPrimoLivelloContenitoreMetallo)
        {
            addY();
            testo1Bool = true;
            contenitorePietreMagiche1.SetActive(true);
        }

        if (singleton.CompratoPrimoLivelloProduzioneMunizioni)
        {
            addY();
            testo1Bool = true;
            produttoreColpiMagici1.SetActive(true);
        }

        if (singleton.CompratoPrimoLivelloContenitoreMunizioni)
        {
            addY();
            testo1Bool = true;
            contenitoreColpiMagici1.SetActive(true);
        }

        //secondo livello
        if (singleton.CompratoSecondoLivelloSpawn)
        {
            addY();
            testo2Bool = true;
            spawn2.SetActive(true);
        }

        if (singleton.CompratoSecondoLivelloEstrattoreElisir)
        {
            addY();
            testo2Bool = true;
            estrattoreElisir2.SetActive(true);
        }

        if (singleton.CompratoSecondoLivelloContenitoreElisir)
        {
            addY();
            testo2Bool = true;
            capienzaElisir2.SetActive(true);
        }

        if (singleton.CompratoSecondoLivelloProduzioneMetallo)
        {
            addY();
            testo2Bool = true;
            pietreMagiche2.SetActive(true);
        }

        if (singleton.CompratoSecondoLivelloContenitoreMetallo)
        {
            addY();
            testo2Bool = true;
            contenitorePietreMagiche2.SetActive(true);
        }

        if (singleton.CompratoSecondoLivelloProduzioneMunizioni)
        {
            addY();
            testo2Bool = true;
            produttoreColpiMagici2.SetActive(true);
        }

        if (singleton.CompratoSecondoLivelloContenitoreMunizioni)
        {
            addY();
            testo2Bool = true;
            contenitoreColpiMagici2.SetActive(true);
        }

        if (singleton.CompratoSecondoLivelloTorretta)
        {
            addY();
            testo2Bool = true;
            torretta2.SetActive(true);
        }

        //terzo livello

        if (singleton.CompratoTerzoLivelloSpawn)
        {
            addY();
            testo3Bool = true;
            spawn3.SetActive(true);
        }

        if (singleton.CompratoTerzoLivelloEstrattoreElisir)
        {
            addY();
            testo3Bool = true;
            estrattoreElisir3.SetActive(true);
        }

        if (singleton.CompratoTerzoLivelloContenitoreElisir)
        {
            addY();
            testo3Bool = true;
            capienzaElisir3.SetActive(true);
        }

        if (singleton.CompratoTerzoLivelloProduzioneMetallo)
        {
            addY();
            testo3Bool = true;
            pietreMagiche3.SetActive(true);
        }

        if (singleton.CompratoTerzoLivelloContenitoreMetallo)
        {
            addY();
            testo3Bool = true;
            contenitorePietreMagiche3.SetActive(true);
        }

        if (singleton.CompratoTerzoLivelloProduzioneMunizioni)
        {
            addY();
            testo3Bool = true;
            produttoreColpiMagici3.SetActive(true);
        }

        if (singleton.CompratoTerzoLivelloContenitoreMunizioni)
        {
            addY();
            testo3Bool = true;
            contenitoreColpiMagici3.SetActive(true);
        }

        if (singleton.CompratoTerzoLivelloTorretta)
        {
            addY();
            testo3Bool = true;
            torretta3.SetActive(true);
        }

        //quarto livello

        if (singleton.CompratoQuartoLivelloSpawn)
        {
            addY();
            testo4Bool = true;
            spawn4.SetActive(true);
        }
        if (singleton.CompratoQuartoLivelloEstrattoreElisir)
        {
            addY();
            testo4Bool = true;
            estrattoreElisir4.SetActive(true);
        }

        if (singleton.CompratoQuartoLivelloContenitoreElisir)
        {
            addY();
            testo4Bool = true;
            capienzaElisir4.SetActive(true);
        }

        if (singleton.CompratoQuartoLivelloProduzioneMetallo)
        {
            addY();
            testo4Bool = true;
            pietreMagiche4.SetActive(true);
        }

        if (singleton.CompratoQuartoLivelloContenitoreMetallo)
        {
            testo4Bool = true;
            addY();
            contenitorePietreMagiche4.SetActive(true);
        }

        if (singleton.CompratoQuartoLivelloProduzioneMunizioni)
        {
            addY();
            testo4Bool = true;
            produttoreColpiMagici4.SetActive(true);
        }

        if (singleton.CompratoQuartoLivelloContenitoreMunizioni)
        {
            addY();
            testo4Bool = true;
            contenitoreColpiMagici3.SetActive(true);
        }

        if (singleton.CompratoQuartoLivelloTorretta)
        {
            addY();
            testo4Bool = true;
            torretta4.SetActive(true);
        }

        //quinto livello
        if (singleton.CompratoQuintoLivelloSpawn)
        {
            addY();
            testo5Bool = true;
            spawn5.SetActive(true);
        }

        if (singleton.CompratoQuintoLivelloEstrattoreElisir)
        {
            addY();
            testo5Bool = true;
            estrattoreElisir5.SetActive(true);
        }

        if (singleton.CompratoQuintoLivelloContenitoreElisir)
        {
            addY();
            testo5Bool = true;
            capienzaElisir5.SetActive(true);
        }

        if (singleton.CompratoQuintoLivelloProduzioneMetallo)
        {
            addY();
            testo5Bool = true;
            pietreMagiche5.SetActive(true);
        }

        if (singleton.CompratoQuintoLivelloContenitoreMetallo)
        {
            addY();
            testo5Bool = true;
            contenitorePietreMagiche5.SetActive(true);
        }

        if (singleton.CompratoQuintoLivelloProduzioneMunizioni)
        {
            addY();
            testo5Bool = true;
            produttoreColpiMagici5.SetActive(true);
        }

        if (singleton.CompratoQuintoLivelloContenitoreMunizioni)
        {
            addY();
            testo5Bool = true;
            contenitoreColpiMagici5.SetActive(true);
        }

        if (singleton.CompratoQuintoLivelloTorretta)
        {
            addY();
            testo5Bool = true;
            torretta5.SetActive(true);
        }


        //testo
        if (testo1Bool)
        {
            addY();
            testo1.SetActive(true);
        }
        if (testo2Bool)
        {
            addY();
            testo2.SetActive(true);
        }
        if (testo3Bool)
        {
            addY();
            testo3.SetActive(true);
        }
        if (testo4Bool)
        {
            addY();
            testo4.SetActive(true);
        }
        if (testo5Bool)
        {
            addY();
            testo5.SetActive(true);
        }



        //Ho messo il - a posY perché se mettevo + lo scroll partiva dal basso
        rt.sizeDelta = new Vector2(990, posY);
        scroll.normalizedPosition = new Vector2(0, 1);


    }

    private void addY()
    {
        posY += 300;
        posY += 30;
    }

}
