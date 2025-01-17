using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pietreMagicheValute : MonoBehaviour
{
    private bool primoLivello = false;
    private bool secondoLivello = false;
    private bool terzoLivello = false;
    private bool quartoLivello = false;
    private bool quintoLivello = false;

    public GameObject valuta;

    public Transform pos1;
    private GameObject pietra1;

    public Transform pos2;
    private GameObject pietra2;

    public Transform pos3;
    private GameObject pietra3;

    public Transform pos4;
    private GameObject pietra4;

    public Transform pos5;
    private GameObject pietra5;

    private SpriteRenderer pietraImmagine1;
    private SpriteRenderer pietraImmagine2;
    private SpriteRenderer pietraImmagine3;
    private SpriteRenderer pietraImmagine4;
    private SpriteRenderer pietraImmagine5;

    singleton singleton;

    // Start is called before the first frame update
    void Start()
    {
        singleton = singleton.Instance;
        pietra1 = Instantiate(valuta, new Vector2(pos1.position.x, pos1.position.y - 1.5f), Quaternion.identity);
        pietraImmagine1 = pietra1.GetComponent<SpriteRenderer>();

        pietra2 = Instantiate(valuta, new Vector2(pos2.position.x, pos2.position.y - 1.5f), Quaternion.identity);
        pietraImmagine2 = pietra2.GetComponent<SpriteRenderer>();

        pietra3 = Instantiate(valuta, new Vector2(pos3.position.x, pos3.position.y - 1.5f), Quaternion.identity);
        pietraImmagine3 = pietra3.GetComponent<SpriteRenderer>();

        pietra4 = Instantiate(valuta, new Vector2(pos4.position.x, pos4.position.y - 1.5f), Quaternion.identity);
        pietraImmagine4 = pietra4.GetComponent<SpriteRenderer>();

        pietra5 = Instantiate(valuta, new Vector2(pos5.position.x, pos5.position.y - 1.5f), Quaternion.identity);
        pietraImmagine5 = pietra5.GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        if (singleton.CompratoPrimoLivelloProduzioneMetallo && !primoLivello)
        {
            primoLivello = true;
            pietraImmagine1.enabled = true;
        }

        if (singleton.CompratoSecondoLivelloProduzioneMetallo && !secondoLivello)
        {
            secondoLivello = true;
            pietraImmagine2.enabled = true;
        }

        if (singleton.CompratoTerzoLivelloProduzioneMetallo && !terzoLivello)
        {
            terzoLivello = true;
            pietraImmagine3.enabled = true;
        }

        if (singleton.CompratoQuartoLivelloProduzioneMetallo && !quartoLivello)
        {
            quartoLivello = true;
            pietraImmagine4.enabled = true;
        }


        if (singleton.CompratoQuintoLivelloProduzioneMetallo && !quintoLivello)
        {
            quintoLivello = true;
            pietraImmagine5.enabled = true;
        }
    }
}
