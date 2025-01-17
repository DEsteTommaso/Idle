using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colpiMagiciValute : MonoBehaviour
{
    private bool primoLivello = false;
    private bool secondoLivello = false;
    private bool terzoLivello = false;
    private bool quartoLivello = false;
    private bool quintoLivello = false;

    public GameObject valuta;

    public Transform pos1;
    private GameObject colpo1;

    public Transform pos2;
    private GameObject colpo2;

    public Transform pos3;
    private GameObject colpo3;

    public Transform pos4;
    private GameObject colpo4;

    public Transform pos5;
    private GameObject colpo5;

    private SpriteRenderer colpoImmagine1;
    private SpriteRenderer colpoImmagine2;
    private SpriteRenderer colpoImmagine3;
    private SpriteRenderer colpoImmagine4;
    private SpriteRenderer colpoImmagine5;

    singleton singleton;

    // Start is called before the first frame update
    void Start()
    {
        singleton = singleton.Instance;
        colpo1 = Instantiate(valuta, new Vector2(pos1.position.x, pos1.position.y - 1.5f), Quaternion.identity);
        colpoImmagine1 = colpo1.GetComponent<SpriteRenderer>();

        colpo2 = Instantiate(valuta, new Vector2(pos2.position.x, pos2.position.y - 1.5f), Quaternion.identity);
        colpoImmagine2 = colpo2.GetComponent<SpriteRenderer>();

        colpo3 = Instantiate(valuta, new Vector2(pos3.position.x, pos3.position.y - 1.5f), Quaternion.identity);
        colpoImmagine3 = colpo3.GetComponent<SpriteRenderer>();

        colpo4 = Instantiate(valuta, new Vector2(pos4.position.x, pos4.position.y - 1.5f), Quaternion.identity);
        colpoImmagine4 = colpo4.GetComponent<SpriteRenderer>();

        colpo5 = Instantiate(valuta, new Vector2(pos5.position.x, pos5.position.y - 1.5f), Quaternion.identity);
        colpoImmagine5 = colpo5.GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        if (singleton.CompratoPrimoLivelloProduzioneMunizioni && !primoLivello)
        {
            primoLivello = true;
            colpoImmagine1.enabled = true;
        }

        if (singleton.CompratoSecondoLivelloProduzioneMunizioni && !secondoLivello)
        {
            secondoLivello = true;
            colpoImmagine2.enabled = true;
        }

        if (singleton.CompratoTerzoLivelloProduzioneMunizioni && !terzoLivello)
        {
            terzoLivello = true;
            colpoImmagine3.enabled = true;
        }

        if (singleton.CompratoQuartoLivelloProduzioneMunizioni && !quartoLivello)
        {
            quartoLivello = true;
            colpoImmagine4.enabled = true;
        }


        if (singleton.CompratoQuintoLivelloProduzioneMunizioni && !quintoLivello)
        {
            quintoLivello = true;
            colpoImmagine5.enabled = true;
        }
    }
}
