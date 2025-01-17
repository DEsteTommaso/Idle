using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pallottola_specialeVedovaNera : MonoBehaviour
{
    private float velocita = 10f;

    private Transform personaggio;

    private Vector3 target;

    private bool spara = false;

    public AudioClip clip;
    private AudioSource sparareAudio;

    singleton singleton;
    void Start()
    {
        singleton = singleton.Instance;

        Destroy(gameObject, 3f); // distruggi il proiettile dopo 3 secondi
        personaggio = GameObject.FindWithTag("personaggioAttivo").transform;
        //Debug.Log("colpo Speciale vedova nera");

        sparareAudio = gameObject.GetComponent<AudioSource>();

            if (sparareAudio != null)
            sparareAudio.PlayOneShot(clip, singleton.Suono);
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

            // Calcola la rotazione per far coincidere la direzione della pallottola con il vettore di movimento
            Vector3 direction = ((target * 1000) - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            spara = true;
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
                nemico.vedovaNera();
            }
            else if (collision.gameObject.name == "ghoul-2(Clone)")
            {
                ghoul_2 nemico = collision.gameObject.GetComponent<ghoul_2>();
                nemico.vedovaNera();
            }
            //controllo oltre al nome anche che sia il boxcollider (corpo) e non il circlecollider (mira)
            else if (collision.gameObject.name == "imp-2(Clone)" && collision is BoxCollider2D)
            {
                imp_2 nemico = collision.gameObject.GetComponent<imp_2>();
                nemico.vedovaNera();
            }
            else if (collision.gameObject.name == "reaper-2(Clone)")
            {
                reaper_2 nemico = collision.gameObject.GetComponent<reaper_2>();
                nemico.vedovaNera();
            }
            else if (collision.gameObject.name == "phantom_knight-2(Clone)")
            {
                phantom_knight_2 nemico = collision.gameObject.GetComponent<phantom_knight_2>();
                nemico.vedovaNera();
            }


        }
    }
}
