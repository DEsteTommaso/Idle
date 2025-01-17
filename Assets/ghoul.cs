using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ghoul : MonoBehaviour
{
    private float velocita = 3f;
    private bool movimento;
    private float vita = 75f;

    public Image vitaVerde;
    public Image vitaRossa;
    public Image vitaSfondo;
    singleton singleton;

    private Animator animator;
    private new Collider2D collider2D;

    private bool colpitoBool = false;

    //testo morte
    public GameObject testo;
    //


    private bool morteBool = false;

    public AudioClip dannoAudio;
    public AudioClip morteAudio;
    private AudioSource audioGhoul;


    void Start()
    {
        singleton = singleton.Instance;
        movimento = true;
        animator = GetComponent<Animator>();
        collider2D = GetComponent<Collider2D>();
        singleton.MostriLivello2 = singleton.MostriLivello2 + 1;
        audioGhoul = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {


        if (movimento && !morteBool)
        {
            // Sposta il nemico verso sinistra
            transform.position = new Vector2(transform.position.x - (velocita * Time.deltaTime), transform.position.y);
            vitaVerde.transform.position = new Vector2(transform.position.x - (velocita * Time.deltaTime), transform.position.y + 2);
            vitaRossa.transform.position = new Vector2(transform.position.x - (velocita * Time.deltaTime), transform.position.y + 2);
            vitaSfondo.transform.position = new Vector2(transform.position.x - (velocita * Time.deltaTime), transform.position.y + 2);

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "muro")
        {

            movimento = false;
            animator.Play("idle");
     

        }
    }

    public void colpito(float danni)
    {

        if (!colpitoBool)
        {
          
            vitaVerde.enabled = true;
            vitaRossa.enabled = true;
            vitaSfondo.enabled = true;
            colpitoBool = true;
        }



        vita -= danni;
       
        vitaVerde.fillAmount = vita / 75f;
        if (vita <= 0)
        {
            

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

            //subito danni
                if (audioGhoul != null)
                        audioGhoul.PlayOneShot(morteAudio, singleton.Suono);

            testo.SetActive(true);
            animator.Play("morte");
            morteBool = true;
            StartCoroutine(morte());

        }
        else
        {
            //subito danni
                if (audioGhoul != null)
                        audioGhoul.PlayOneShot(dannoAudio, singleton.Suono);
        }

    }



    IEnumerator morte()
    {
        singleton.MostriLivello2 = singleton.MostriLivello2 - 1;
        collider2D.enabled = false;
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }

}
