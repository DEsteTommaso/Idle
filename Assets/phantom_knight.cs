using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class phantom_knight : MonoBehaviour
{
    private float velocita = 3.5f;
    private bool movimento;
    private float vita = 150f;

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


    public AudioClip morteAudio;
    public AudioClip dannoAudio;
    private AudioSource audioPhantom;

    void Start()
    {
        singleton = singleton.Instance;
        movimento = true;
        animator = GetComponent<Animator>();
        collider2D = GetComponent<Collider2D>();
        singleton.MostriLivello5 = singleton.MostriLivello5 + 1;

        audioPhantom = gameObject.GetComponent<AudioSource>();
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
       
        vitaVerde.fillAmount = vita / 150f;
        if (vita <= 0)
        {


            if (singleton.Ads1)
            {
                testo.GetComponent<TextMeshPro>().text = "+400";
                singleton.addMoneta(400);
            }
            else
            {
                testo.GetComponent<TextMeshPro>().text = "+200";
                singleton.addMoneta(200);
            }


                if (audioPhantom != null)
                        audioPhantom.PlayOneShot(morteAudio, singleton.Suono);

            testo.SetActive(true);
            animator.Play("morte");
            morteBool = true;
            StartCoroutine(morte());

        }
        else
        {
                if (audioPhantom != null)
                        audioPhantom.PlayOneShot(dannoAudio, singleton.Suono);
        }

    }



    IEnumerator morte()
    {
        singleton.MostriLivello5 = singleton.MostriLivello5 - 1;
        collider2D.enabled = false;
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }

}
