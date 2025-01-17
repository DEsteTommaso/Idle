using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pallottola_specialeBolla : MonoBehaviour
{
    private float velocita = 10f;

    private Transform personaggio;

    private Vector3 target;

    private bool spara = false;

    private Animator animazione;

    public AudioClip inizio;
    public AudioClip durata;
    private AudioSource sparareAudio;

    private BoxCollider2D colliderDistruzione;

    singleton singleton;

    void Start()
    {
        singleton = singleton.Instance;

        colliderDistruzione = gameObject.GetComponent<BoxCollider2D>();
        Destroy(gameObject, 5f); // distruggi il proiettile dopo 3 secondi
        animazione = gameObject.GetComponent<Animator>();
        personaggio = GameObject.FindWithTag("personaggioAttivo").transform;

        sparareAudio = gameObject.GetComponent<AudioSource>();

            if (sparareAudio != null) { 
            sparareAudio.PlayOneShot(inizio, singleton.Suono);
            StartCoroutine(wait());
           
        }
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(0.5f);
        yield return new WaitForSeconds(1f);
        sparareAudio.PlayOneShot(durata, singleton.Suono);
    }

    // Update is called once per frame
    void Update()
    {
        // Muovi la pallottola nella direzione in cui è stata sparata
        float step = velocita * Time.deltaTime;
        if (spara)
            transform.position = Vector3.MoveTowards(transform.position, target * 1000, step);
        //transform.position += initialDirection * velocita * Time.deltaTime;
    }

    public void setTarget(Vector3 target)
    {
        if (target != null)
        {
            this.target = target;
            transform.position = personaggio.transform.position;
            spara = true;
            //Debug.Log("Fino qua tutto bene");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //controllo che prima sia un nemico e poi che colpisca solamente il nemico indicato (problema sovrapposizione)
        if (collision.gameObject.CompareTag("nemico"))
        {
           
            if (collision.gameObject.name == "undead_warrior-2(Clone)")
            {
                undead_warrior_2 nemico = collision.gameObject.GetComponent<undead_warrior_2>();
                nemico.bolla(transform);
              
            }
            else if (collision.gameObject.name == "ghoul-2(Clone)")
            {
                ghoul_2 nemico = collision.gameObject.GetComponent<ghoul_2>();
                nemico.bolla(transform);
                
            }
            //controllo oltre al nome anche che sia il boxcollider (corpo) e non il circlecollider (mira)
            else if (collision.gameObject.name == "imp-2(Clone)" && collision is BoxCollider2D)
            {
                imp_2 nemico = collision.gameObject.GetComponent<imp_2>();
                nemico.bolla(transform);
               
            }
            else if (collision.gameObject.name == "reaper-2(Clone)")
            {
                reaper_2 nemico = collision.gameObject.GetComponent<reaper_2>();
                nemico.bolla(transform);
                
            }
            else if (collision.gameObject.name == "phantom_knight-2(Clone)")
            {
                phantom_knight_2 nemico = collision.gameObject.GetComponent<phantom_knight_2>();
                nemico.bolla(transform);
               
            }

        }
        if (collision.gameObject.CompareTag("parete") && colliderDistruzione.IsTouching(collision))
        {
            Destroy(gameObject);
        }
    }

}
