using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pallottola : MonoBehaviour
{
    private int danno;
    private GameObject target;
    private float velocita = 10f;
    private string tipologia;

    void Start()
    {
        Destroy(gameObject, 10f); // distruggi il proiettile dopo 3 secondi

    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name.Equals("Tutorial"))
            transform.position += Vector3.left * velocita * Time.deltaTime;
        else
        // Muovi la pallottola nella direzione in cui è stata sparata
        transform.position += Vector3.right * velocita * Time.deltaTime;


    }

    public string getTipologia()
    {
        return tipologia;
    }

    public void setTarget(GameObject target, int danno, string tipologia)
    {
        this.target = target;
        this.danno = danno;
        this.tipologia = tipologia;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (SceneManager.GetActiveScene().name.Equals("Tutorial")) { 
            if (collision.gameObject.name == "ghoul-1(Clone)")
            {
                ghoul_Tutorial nemico = collision.gameObject.GetComponent<ghoul_Tutorial>();
                if (nemico != null)
                    nemico.colpito(danno);
                Destroy(gameObject);
            }
        }
        //controllo che prima sia un nemico e poi che colpisca solamente il nemico indicato (problema sovrapposizione)
        else if (collision.gameObject.CompareTag("nemico") && (target == collision.gameObject))
        {
            if (collision.gameObject.name == "undead_warrior-1(Clone)")
            {
                undead_warrior nemico = collision.gameObject.GetComponent<undead_warrior>();
                if (nemico != null)
                    nemico.colpito(danno);
                Destroy(gameObject);
            }
            else if (collision.gameObject.name == "ghoul-1(Clone)")
            {
                ghoul nemico = collision.gameObject.GetComponent<ghoul>();
                if (nemico != null)
                    nemico.colpito(danno);
                Destroy(gameObject);
            }
            else if (collision.gameObject.name == "imp-1(Clone)")
            {
                imp nemico = collision.gameObject.GetComponent<imp>();
                if (nemico != null)
                    nemico.colpito(danno);
                Destroy(gameObject);
            }
            else if (collision.gameObject.name == "reaper-1(Clone)")
            {
                reaper nemico = collision.gameObject.GetComponent<reaper>();
                if (nemico != null)
                    nemico.colpito(danno);
                Destroy(gameObject);
            }
            else if (collision.gameObject.name == "phantom_knight-1(Clone)")
            {
                phantom_knight nemico = collision.gameObject.GetComponent<phantom_knight>();
                if (nemico != null)
                    nemico.colpito(danno);
                Destroy(gameObject);
            }
            /*else
            {
                Destroy(gameObject);
            }*/
       
        }

    }
}
