using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elisirValute : MonoBehaviour
{
    private bool primoLivello = false;
    private bool secondoLivello = false;
    private bool terzoLivello = false;
    private bool quartoLivello = false;
    private bool quintoLivello = false;

    public GameObject valuta;

    public Transform pos1;
    private GameObject elisir1;

    public Transform pos2;
    private GameObject elisir2;

    public Transform pos3;
    private GameObject elisir3;

    public Transform pos4;
    private GameObject elisir4;

    public Transform pos5;
    private GameObject elisir5;

    private SpriteRenderer elisirImmagine1;
    private SpriteRenderer elisirImmagine2;
    private SpriteRenderer elisirImmagine3;
    private SpriteRenderer elisirImmagine4;
    private SpriteRenderer elisirImmagine5;

    singleton singleton;

    // Start is called before the first frame update
    void Start()
    {
        singleton = singleton.Instance;
        elisir1 = Instantiate(valuta, new Vector2(pos1.position.x, pos1.position.y - 1.5f), Quaternion.identity);
        elisirImmagine1 = elisir1.GetComponent<SpriteRenderer>();

        elisir2 = Instantiate(valuta, new Vector2(pos2.position.x, pos2.position.y - 1.5f), Quaternion.identity);
        elisirImmagine2 = elisir2.GetComponent<SpriteRenderer>();

        elisir3 = Instantiate(valuta, new Vector2(pos3.position.x, pos3.position.y - 1.5f), Quaternion.identity);
        elisirImmagine3 = elisir3.GetComponent<SpriteRenderer>();

        elisir4 = Instantiate(valuta, new Vector2(pos4.position.x, pos4.position.y - 1.5f), Quaternion.identity);
        elisirImmagine4 = elisir4.GetComponent<SpriteRenderer>();

        elisir5 = Instantiate(valuta, new Vector2(pos5.position.x, pos5.position.y - 1.5f), Quaternion.identity);
        elisirImmagine5 = elisir5.GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        if (singleton.CompratoPrimoLivelloEstrattoreElisir && !primoLivello)
        {
            primoLivello = true;
            elisirImmagine1.enabled = true;
        }

        if (singleton.CompratoSecondoLivelloEstrattoreElisir && !secondoLivello)
        {
            secondoLivello = true;
            elisirImmagine2.enabled = true;
        }

        if (singleton.CompratoTerzoLivelloEstrattoreElisir && !terzoLivello)
        {
            terzoLivello = true;
            elisirImmagine3.enabled = true;
        }

        if (singleton.CompratoQuartoLivelloEstrattoreElisir && !quartoLivello)
        {
            quartoLivello = true;
            elisirImmagine4.enabled = true;
        }


        if (singleton.CompratoQuintoLivelloEstrattoreElisir && !quintoLivello)
        {
            quintoLivello = true;
            elisirImmagine5.enabled = true;
        }
    }
}
