using UnityEngine;
using System.Collections;
using EasyJoystick; //line added
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class codicePersonaggio : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private Joystick joystick; //line added
    [SerializeField] private Joystick joystickMira; //line added
    private int vita;

    private float posX = 0;
    private float posY = 0;

    private Animator animazione;
    private SpriteRenderer sprite;
    private new Collider2D collider;

    public Image immagineVitaVerde;

    private bool colpitoBool = false;
    private bool morteBool = false;

    public AudioClip camminata;
    public AudioClip morteAudio;
    private AudioSource personaggioAudio;
    private bool corsaAudioBool = true;

    public GameObject pannelloRinascita;

    singleton singleton;


    private void Start()
    {
        singleton = singleton.Instance;

        animazione = gameObject.GetComponent<Animator>();
        sprite = gameObject.GetComponent<SpriteRenderer>();
        collider = gameObject.GetComponent<Collider2D>();

        personaggioAudio = gameObject.GetComponent<AudioSource>();

        gameObject.tag = "personaggioAttivo";
        if (gameObject.name == "Uomo")
            vita = 100;
        else if (gameObject.name == "Gufo")
            vita = 150;
        else if ((gameObject.name == "Mr.Coniglio"))
            vita = 200;
    }

    IEnumerator run()
    {
        corsaAudioBool = false;
        yield return new WaitForSeconds(0.4f);
        corsaAudioBool = true;
    }

    private void Update()
    {
        if (gameObject.name == "Uomo")
            immagineVitaVerde.fillAmount = vita / 100f;
        else if (gameObject.name == "Gufo")
            immagineVitaVerde.fillAmount = vita / 150f;
        else if ((gameObject.name == "Mr.Coniglio"))
            immagineVitaVerde.fillAmount = vita / 200f;


        if (!morteBool) {
            

        //update anche per la barra della vita

        //correre o idle
        if (posX == transform.position.x && posY == transform.position.y)
        {
            if(!colpitoBool && !morteBool)
                 animazione.Play("idle");
        }
        else
        {

            if (!colpitoBool && !morteBool) { 
                animazione.Play("corsa");

                        if (personaggioAudio != null && corsaAudioBool)
                        {
                            personaggioAudio.PlayOneShot(camminata, singleton.Suono);
                            StartCoroutine(run());
                        }
                                

                }
        }

            //flip
            if (joystickMira.IsTouching) { 
                if (joystickMira.Horizontal() > 0)
                {
                    sprite.flipX = false;
                }
                else if(joystickMira.Horizontal() < 0)
                {
                    sprite.flipX = true;
                }
            }
            else
            {
                //se non sto toccando la mira allora ruoto con quello del movimento
                if (joystick.Horizontal() > 0)
                {
                    sprite.flipX = false;
                }
                else if (joystick.Horizontal() < 0)
                {
                    sprite.flipX = true;
                }


            }


        posX = transform.position.x;
        posY = transform.position.y;

        
        transform.position += new Vector3(joystick.Horizontal(), joystick.Vertical(), 0f) * speed * Time.deltaTime; 
        }
        
    }

    public void colpito(int danno)
    { 
        vita -= danno;

        StartCoroutine(colpito());

        if (vita <= 0)
        {
                if (personaggioAudio != null)
                        personaggioAudio.PlayOneShot(morteAudio, singleton.Suono);



            //Debug.Log("MORTO");
            StartCoroutine(morte());
        }
        
    }

    IEnumerator colpito()
    {
        colpitoBool = true;
        animazione.Play("danno");
        yield return new WaitForSeconds(0.5f);
        colpitoBool = false;

    }

    IEnumerator morte()
    {
        animazione.Play("morte");
        collider.enabled = false;
        morteBool = true;

        singleton.MorteGiocatoreDungeon = true;

        yield return new WaitForSeconds(1f);


        pannelloRinascita.SetActive(true);
        sprite.enabled = false;

        

    }

    public void aggiungiVita(int aggiunta)
    {
        if(gameObject.name == "Uomo")
        {
            //Debug.Log("vita aggiunta");
            if (vita <= 0)
            {
                collider.enabled = true;
                morteBool = false;
                sprite.enabled = true;
            }

            vita += aggiunta;
            if (vita > 100)
                vita = 100;
        }
        else if (gameObject.name == "Gufo")
        {
            //Debug.Log("vita aggiunta");

            if (vita <= 0)
            {
                collider.enabled = true;
                morteBool = false;
                sprite.enabled = true;
            }

            vita += aggiunta;
            if (vita > 150)
                vita = 150;
        }
        else if(gameObject.name == "Mr.Coniglio")
        {
            //Debug.Log("vita aggiunta");

            if (vita <= 0)
            {
                collider.enabled = true;
                morteBool = false;
                sprite.enabled = true;
            }

            vita += aggiunta;
            if (vita > 200)
                vita = 200;
        }
    }

    

}