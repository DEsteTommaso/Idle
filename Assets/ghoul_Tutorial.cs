using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ghoul_Tutorial : MonoBehaviour
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




    void Start()
    {
        singleton = singleton.Instance;
        movimento = true;
        animator = GetComponent<Animator>();
        collider2D = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (movimento)
        {
            // Sposta il nemico verso sinistra
            transform.position = new Vector2(transform.position.x + (velocita * Time.deltaTime), transform.position.y);
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
            //Debug.Log("Muro");

        }
    }

    public void colpito(float danni)
    {

        if (!colpitoBool)
        {
            //Debug.Log("Attivato");
            vitaVerde.enabled = true;
            vitaRossa.enabled = true;
            vitaSfondo.enabled = true;
            colpitoBool = true;
        }



        vita -= danni;
        //Debug.Log("Ricevuti danni, vita: " + vita);
        vitaVerde.fillAmount = vita / 75f;
        if (vita <= 0)
        {
            singleton.addMoneta(50);
            testo.SetActive(true);
            animator.Play("morte");
            StartCoroutine(morte());

        }

    }



    IEnumerator morte()
    {
        collider2D.enabled = false;
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }

}
