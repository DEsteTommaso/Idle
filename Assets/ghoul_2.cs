using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ghoul_2 : MonoBehaviour
{
    private Transform personaggio;
    private SpriteRenderer sprite;
    private Animator animator;
    private Transform colpoSlash;
    private Transform colpoBucoNero;

    //movimento
    private float velocita = 3.0f;
    private float velocitaBuconero = 1.5f;
    private float vita = 75f;
    private Vector3 direzione;
    private codicePersonaggio codice;

    private float ultimaDirezioneX = 0;
    //

    //valori booleani
    private bool muoversi = false;
    private bool attaccare = false;
    private bool colpitoBool = false;
    private bool morto = false;
    private bool ghiacciato = false;
    private bool slashBool = false;
    private bool bucoNeroBool = false;
    //

    //vita 
    public Image vitaVerde;
    public Image vitaRossa;
    public Image vitaSfondo;
    //

    //testo morte
    public GameObject testo;
    //

    //singleton
    singleton singleton;
    private new Collider2D collider2D;

    //colpo
    public GameObject colpoDanno;
    public GameObject colpoVedovaNera;

    //tempo prima che scompaia
    private float tempoRimanente = 60.0f;
    private bool colpitoTimerBool = false;


    public AudioClip attaccoAudio;
    public AudioClip morteAudio;
    public AudioClip dannoAudio;
    private AudioSource audioGhoul;

    // Start is called before the first frame update
    void Start()
    {
        //gli faccio distruggere dopo 50 secondi

        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        singleton = singleton.Instance;
        collider2D = GetComponent<Collider2D>();

        personaggio = GameObject.FindWithTag("personaggioAttivo").transform;
        muoversi = true;

        audioGhoul = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if (!colpitoTimerBool)
        {
            tempoRimanente -= Time.deltaTime;
           
            if (tempoRimanente <= 0)
            {
                //si distrugge se il tempo arriva a 0
                
                Destroy(gameObject);

                // Gestisci il termine del cronometro, ad esempio mostra un messaggio o esegui un'azione.
            }
        }




        if (!morto)
        {
            //Sposto la barra della vita con il personaggio
            vitaVerde.transform.position = new Vector2(transform.position.x - (velocita * Time.deltaTime), transform.position.y + 2);
            vitaRossa.transform.position = new Vector2(transform.position.x - (velocita * Time.deltaTime), transform.position.y + 2);
            vitaSfondo.transform.position = new Vector2(transform.position.x - (velocita * Time.deltaTime), transform.position.y + 2);
            //

            if(!ghiacciato)
            if (muoversi)
            {

                direzione = (personaggio.position - transform.position).normalized;

                // Sposta l'oggetto a sinistra di 1 unità rispetto alla sua posizione corrente


                // Muovi l'oggetto per inseguire l'altro oggetto
                transform.position = new Vector2(transform.position.x + direzione.x * velocita * Time.deltaTime,
                                                 transform.position.y + direzione.y * velocita * Time.deltaTime);

                if (ultimaDirezioneX > transform.position.x)
                {
                    //sta andando a sinistra
                    sprite.flipX = false;
                }
                else
                {
                    //sta andado a destra
                    sprite.flipX = true;
                }
                ultimaDirezioneX = transform.position.x;


            }
            if (slashBool)
            {

                // Muovi l'oggetto per inseguire l'altro oggetto
                if (colpoSlash != null)
                    transform.position = new Vector2(colpoSlash.position.x,
                                                 colpoSlash.position.y);

            }
            if (bucoNeroBool)
            {
                if(colpoBucoNero != null)
                {

                direzione = (colpoBucoNero.position - transform.position).normalized;

                // Sposta l'oggetto a sinistra di 1 unità rispetto alla sua posizione corrente


                // Muovi l'oggetto per inseguire l'altro oggetto
                transform.position = new Vector2(transform.position.x + direzione.x * velocitaBuconero * Time.deltaTime,
                                                 transform.position.y + direzione.y * velocitaBuconero * Time.deltaTime);

                if (ultimaDirezioneX > transform.position.x)
                {
                    //sta andando a sinistra e quindi metto l'opposto
                    sprite.flipX = true;
                }
                else
                {
                    //sta andado a destra e quindi metto l'opposto
                    sprite.flipX = false;
                }
                ultimaDirezioneX = transform.position.x;
  }

            }
        }
    }


    IEnumerator attacco()
    {
        animator.Play("attacco-2");
        attaccare = true;

        yield return new WaitForSeconds(0.5f);
        if (!ghiacciato)
        {
        codice.colpito(15);

                if (audioGhoul != null)
                        audioGhoul.PlayOneShot(attaccoAudio, singleton.Suono);
        }
       
        yield return new WaitForSeconds(0.5f);

        //Debug.Log("Allora entri=?");
        animator.Play("corsa-2");
        muoversi = true;
        attaccare = false;
        StopCoroutine(attacco());
    }

    //colpo normale
    public void colpito(float danni)
    {

        if (!colpitoBool)
        {
      

            colpitoTimerBool = true;

            vitaVerde.enabled = true;
            vitaRossa.enabled = true;
            vitaSfondo.enabled = true;
            colpitoBool = true;
        }

        

        vita -= danni;
      
        vitaVerde.fillAmount = vita / 75f;
        if (vita <= 0)
        {
            morto = true;


            if (singleton.Ads1)
            {
                testo.GetComponent<TextMeshPro>().text = "+100";
                singleton.addMoneta(100);
            }
            else
            {
                testo.GetComponent<TextMeshPro>().text = "+50";
                singleton.addMoneta(50);
            }

            testo.SetActive(true);

            //subito danni
                if (audioGhoul != null)
                        audioGhoul.PlayOneShot(morteAudio, singleton.Suono);
            //


            animator.Play("morte-2");
            StartCoroutine(morte());

        }
        else
        {
        //animazione colpito
        animator.Play("colpito-2");
        StartCoroutine(colpito());

            //subito danni
                if (audioGhoul != null)
                        audioGhoul.PlayOneShot(dannoAudio, singleton.Suono);
            //
        }

    }

    IEnumerator colpito()
    {
        muoversi = false;
        yield return new WaitForSeconds(0.2f);
        muoversi = true;
        //dopo che è stato colpito riparte l'animazione della  corsa
        animator.Play("corsa-2");
        StopCoroutine(colpito());
    }

    //colpo bacchettaOscura
    public void bacchettaOscura()
    {
        StartCoroutine(bacchettaOscuraCoroutine());
    }

    IEnumerator bacchettaOscuraCoroutine()
    {
        for (int i = 0; i < 8; i++)
        {
            colpito(10);
            colpoDanno.SetActive(true);


            yield return new WaitForSeconds(1f);
            colpoDanno.SetActive(false);
        }
    }
    //

    //colpo bastoneGhiacciato
    public void bastoneGhiaccio()
    {
        StartCoroutine(bastoneGhiaccioCoroutine());
    }

    IEnumerator bastoneGhiaccioCoroutine()
    {
        //blocco il movimento e il fatto che non possa attaccare neò caso dovessimo avvicinarci

        //fermo l'animazione
        animator.speed = 0f;
        ghiacciato = true;

        sprite.color = Color.blue;
        yield return new WaitForSeconds(5f);
        sprite.color = Color.white;

        // Successivamente, riprendi l'animazione
        ghiacciato = false;
        animator.speed = 1f;
        colpito(125);

    }
    //

    //colpo vedova nera
    public void vedovaNera()
    {
        StartCoroutine(vedonaNeraCoroutine());
    }

    IEnumerator vedonaNeraCoroutine()
    {
        codicePersonaggio codicePersonaggio = GameObject.FindWithTag("personaggioAttivo").GetComponent<codicePersonaggio>();
        velocita = velocita - 1;
        colpoVedovaNera.SetActive(true);
        for (int i = 0; i < 10; i++)
        {
            colpito(20);
            colpoDanno.SetActive(true);


            if (codicePersonaggio != null)
                codicePersonaggio.aggiungiVita(20);
            yield return new WaitForSeconds(1f);
            colpoDanno.SetActive(false);
        }
        velocita = velocita + 1;
    }

    //colposlash

    public void bolla(Transform pos)
    {
        colpoSlash = pos;
        StartCoroutine(bollaCoroutine());
    }

    IEnumerator bollaCoroutine()
    {
        //viene eseguito nell'update
        slashBool = true;
        muoversi = false;
        attaccare = true;
        while (colpoSlash != null)
        {
            //attende fino a quando il colpo non si distrugge
            yield return new WaitForSeconds(0.1f);
        }

        colpito(75);
        slashBool = false;
        muoversi = true;
        attaccare = false;

    }

    //bucoNero
    public void bucoNero(Transform pos)
    {
        colpoBucoNero = pos;
        StartCoroutine(bucoNeroCoroutine());
    }

    IEnumerator bucoNeroCoroutine()
    {
        //viene eseguito nell'update
        bucoNeroBool = true;
        muoversi = false;
        attaccare = true;

        while (colpoBucoNero != null)
        {
            //attende fino a quando il colpo non si distrugge
            colpito(20);
            yield return new WaitForSeconds(0.5f);
        }

        bucoNeroBool = false;
        muoversi = true;
        attaccare = false;

    }

    IEnumerator morte()
    {
        collider2D.enabled = false;
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }


    //se entra in collisione con il giocatore
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!morto)
        {
            if (collision.gameObject.tag == "personaggioAttivo")
            {
                codice = collision.gameObject.GetComponent<codicePersonaggio>();

                if (!attaccare)
                {
                    if (!ghiacciato) { muoversi = false;
                    StartCoroutine(attacco());}
                    
                }
            }
        }
    }
}
