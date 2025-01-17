using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class torretta4_scena1 : MonoBehaviour
{
    public GameObject pallottola;
    public GameObject cannaArma;
    //private Transform bersaglio;
    //private Queue<Transform> codaMostri = new Queue<Transform>(); // coda di nemici entrati nell'area
    private GameObject mostro;
    private float ricaricaArma = 0;
    //adjust this to change speed
    float speed = 3f;
    //adjust this to change how high it goes
    float height = 0.25f;

    //vedere colpi consumati
    public Transform torretta;
    public GameObject testo;
    private GameObject testoModificabile;


    Vector3 pos;

    singleton singleton;

    public AudioClip clip;
    private AudioSource audioSparare;

    void Start()
    {
        pos = transform.position;

        testoModificabile = Instantiate(testo, new Vector2(torretta.position.x, torretta.position.y + 2), Quaternion.identity);
        testoModificabile.SetActive(false);

        audioSparare = gameObject.GetComponent<AudioSource>();

        singleton = singleton.Instance;
    }


    // Update is called once per frame
    void Update()
    {
        

        //calculate what the new Y position will be
        float newY = Mathf.Sin(Time.time * speed) * height + pos.y;
        //set the object's Y to the new calculated Y
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);

        // Se non ci sono bersagli nella coda, non fare nulla
        /*if (codaMostri.Count == 0) return;

        // Se il bersaglio attuale non è più valido (es. è stato distrutto o è uscito dall'area), passa al prossimo bersaglio nella coda
        if (bersaglio == null || !codaMostri.Contains(bersaglio))
        {
            bersaglio = codaMostri.Peek();
        }*/
        if (mostro != null)
        {

            if (ricaricaArma > 0)
            {
                ricaricaArma -= Time.deltaTime;
            }
            else if (ricaricaArma <= 0)
            {
                    //pubblicità
                if (singleton.Ads2)
                    ricaricaArma = 1f;
                else
                    ricaricaArma = 3f;           //Intervallo tra gli spari
                //shoot(direction);
                sparare();
            }

        }

    }

    private void sparare()
    {
        if (mostro != null)
        {
           if (singleton.Munizione - singleton.LivelloQuintoLivelloDannoMitraglietta >= 0)
            {

                //suono sparare
                    if (audioSparare != null)
                    audioSparare.PlayOneShot(clip, singleton.Suono);

                testoModificabile.GetComponent<TextMeshPro>().text = "-" + singleton.LivelloQuintoLivelloDannoMitraglietta;
                StartCoroutine(wait());

                singleton.removeMunizione(singleton.LivelloQuintoLivelloDannoMitraglietta);

                GameObject newpallottola = Instantiate(pallottola, cannaArma.transform.position, Quaternion.identity);
                newpallottola.GetComponent<pallottola>().setTarget(mostro, singleton.QuintoLivelloTorretta[singleton.LivelloQuintoLivelloDannoMitraglietta], "torretta4");
            }

            //newpallottola.GetComponent<Rigidbody2D>().velocity = direction.normalized * 10f;


        }
    }

    IEnumerator wait()
    {
        testoModificabile.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        testoModificabile.SetActive(false);
    }

    public void aggiungereMostroCoda(Collider2D collider)
    {
        //codaMostri.Enqueue(collider.transform);
        mostro = collider.gameObject;
        //Debug.Log("Mostro entrato in zona");
    }

    /*public void rimuovereMostroCoda()
    {
        codaMostri.Dequeue();
        if (codaMostri.Count > 0)
        {
            bersaglio = codaMostri.Peek();
        }
        else
        {
            bersaglio = null;

        }
    }*/
}
