using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class armaTutorial : MonoBehaviour
{
    public GameObject pallottola;
    public GameObject cannaArma;
    private Transform bersaglio;
    private Queue<Transform> codaMostri = new Queue<Transform>(); // coda di nemici entrati nell'area
    private float ricaricaArma = 0;
    //adjust this to change speed
    float speed = 3f;
    //adjust this to change how high it goes
    float height = 0.25f;

    Vector3 pos;

    singleton singleton;

    public Sprite arma1;
    public Sprite arma2;
    public Sprite arma3;
    public Sprite arma4;
    public Sprite arma5;

    private SpriteRenderer spriteGameObject;

    private int precedenteSelezionato = 1;

    private int colpiNecessari;

    private void Start()
    {
        pos = transform.position;
        spriteGameObject = gameObject.GetComponent<SpriteRenderer>();
        singleton = singleton.Instance;
    }


    // Update is called once per frame
    void Update()
    {
        if (gameObject.CompareTag("torrettaArma1"))
        {
            //cambio sprite arma
            if (singleton.SelezionatoArma1 && precedenteSelezionato != 1)
            {
                spriteGameObject.sprite = arma1;
                //Debug.Log("Arma 1");
            }

            else if (singleton.SelezionatoArma2 && precedenteSelezionato != 2)
            {
                spriteGameObject.sprite = arma2;
                //Debug.Log("Arma 2");
            }
            else if (singleton.SelezionatoArma3 && precedenteSelezionato != 3)
            {
                spriteGameObject.sprite = arma3;
                //Debug.Log("Arma 3");
            }
            else if (singleton.SelezionatoArma4 && precedenteSelezionato != 4)
            {
                spriteGameObject.sprite = arma4;
                //Debug.Log("Arma 4");
            }
            else if (singleton.SelezionatoArma5 && precedenteSelezionato != 5)
            {
                spriteGameObject.sprite = arma5;
                //Debug.Log("Arma 5");
            }

            //cambio sprite arma
            if (singleton.SelezionatoArma1)
            {
                precedenteSelezionato = 1;
                colpiNecessari = 1;
            }

            else if (singleton.SelezionatoArma2)
            {
                precedenteSelezionato = 2;
                colpiNecessari = 2;
            }
            else if (singleton.SelezionatoArma3)
            {
                precedenteSelezionato = 3;
                colpiNecessari = 3;
            }
            else if (singleton.SelezionatoArma4)
            {
                precedenteSelezionato = 4;
                colpiNecessari = 4;
            }
            else if (singleton.SelezionatoArma5)
            {
                precedenteSelezionato = 5;
                colpiNecessari = 5;
            }

        }
        //

        //calculate what the new Y position will be
        float newY = Mathf.Sin(Time.time * speed) * height + pos.y;
        //set the object's Y to the new calculated Y
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);

        // Se non ci sono bersagli nella coda, non fare nulla
        if (codaMostri.Count == 0) return;

        // Se il bersaglio attuale non è più valido (es. è stato distrutto o è uscito dall'area), passa al prossimo bersaglio nella coda
        if (bersaglio == null || !codaMostri.Contains(bersaglio))
        {
            bersaglio = codaMostri.Peek();
        }
        if (bersaglio != null)
        {

            if (ricaricaArma > 0)
            {
                ricaricaArma -= Time.deltaTime;
            }
            else if (ricaricaArma <= 0)
            {
                if (gameObject.CompareTag("torrettaArma1"))
                {
                    //tempo per sparare armi
                    if (singleton.SelezionatoArma1 || singleton.SelezionatoArma2 || singleton.SelezionatoArma5)
                    {
                        ricaricaArma = 1f;
                    }

                    else if (singleton.SelezionatoArma3 || singleton.SelezionatoArma4)
                    {
                        ricaricaArma = 0.5f;
                    }
                }
                else
                    ricaricaArma = 3f;           //Intervallo tra gli spari
                //shoot(direction);
                sparare();
            }

        }

    }

    private void sparare()
    {
        if (bersaglio != null)
        {
            // sparare solo se è passato abbastanza tempo dall'ultimo sparo  
            if (gameObject.CompareTag("torrettaArma1") && (singleton.Munizione - colpiNecessari) >= 0)
            {
                GameObject newpallottola = Instantiate(pallottola, cannaArma.transform.position, Quaternion.identity);
                singleton.removeMunizione(colpiNecessari);
                //scelgo il colpo dell'arma
                //scelgo il danno del colpo
                if (singleton.SelezionatoArma1)
                {
                    newpallottola.GetComponent<pallottola>().setTarget(bersaglio.gameObject, 10, "arma1");
                }
                else if (singleton.SelezionatoArma2)
                {
                    newpallottola.GetComponent<pallottola>().setTarget(bersaglio.gameObject, 25, "arma2");
                }
                else if (singleton.SelezionatoArma3)
                {
                    newpallottola.GetComponent<pallottola>().setTarget(bersaglio.gameObject, 15, "arma3");
                }
                else if (singleton.SelezionatoArma4)
                {
                    newpallottola.GetComponent<pallottola>().setTarget(bersaglio.gameObject, 25, "arma4");
                }
                else if (singleton.SelezionatoArma5)
                {
                    newpallottola.GetComponent<pallottola>().setTarget(bersaglio.gameObject, 50, "arma5");
                }

            }
            else if (gameObject.CompareTag("torrettaArma2"))
            {
                GameObject newpallottola = Instantiate(pallottola, cannaArma.transform.position, Quaternion.identity);
                newpallottola.GetComponent<pallottola>().setTarget(bersaglio.gameObject, singleton.SecondoLivelloTorretta[singleton.LivelloSecondoLivelloDannoMitraglietta], "torretta1");
            }
            else if (gameObject.CompareTag("torrettaArma3"))
            {
              
                GameObject newpallottola = Instantiate(pallottola, cannaArma.transform.position, Quaternion.identity);
                newpallottola.GetComponent<pallottola>().setTarget(bersaglio.gameObject, singleton.TerzoLivelloTorretta[singleton.LivelloTerzoLivelloDannoMitraglietta], "torretta2");
            }
            else if (gameObject.CompareTag("torrettaArma4"))
            {

                GameObject newpallottola = Instantiate(pallottola, cannaArma.transform.position, Quaternion.identity);
                newpallottola.GetComponent<pallottola>().setTarget(bersaglio.gameObject, singleton.QuartoLivelloTorretta[singleton.LivelloQuartoLivelloDannoMitraglietta], "torretta3");
            }
            else if (gameObject.CompareTag("torrettaArma5"))
            {
    
                GameObject newpallottola = Instantiate(pallottola, cannaArma.transform.position, Quaternion.identity);
                newpallottola.GetComponent<pallottola>().setTarget(bersaglio.gameObject, singleton.QuintoLivelloTorretta[singleton.LivelloQuintoLivelloDannoMitraglietta], "torretta4");
            }

            //newpallottola.GetComponent<Rigidbody2D>().velocity = direction.normalized * 10f;


        }
    }

    public void aggiungereMostroCoda(Collider2D collider)
    {
        codaMostri.Enqueue(collider.transform);
        Debug.Log("Mostro entrato in zona");
    }

    public void rimuovereMostroCoda()
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
    }
}
