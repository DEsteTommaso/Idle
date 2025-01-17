using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class arma_Scena1 : MonoBehaviour
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



    Vector3 pos;

    singleton singleton;

    public Sprite arma1;
    public Sprite arma2;
    public Sprite arma3;
    public Sprite arma4;
    public Sprite arma5;

    private SpriteRenderer spriteGameObject;

    private int precedenteSelezionato = 0;

    private int colpiNecessari;

    public AudioClip clip;
    private AudioSource audioSparare;

    void Start()
    {
        singleton = singleton.Instance;

        pos = transform.position;
        spriteGameObject = gameObject.GetComponent<SpriteRenderer>();

        audioSparare = gameObject.GetComponent<AudioSource>();


    }


    // Update is called once per frame
    void Update()
    {
        
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

        
        //

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
                
                if (singleton.SelezionatoArma1 || singleton.SelezionatoArma2 || singleton.SelezionatoArma5)
                {
                    ricaricaArma = 1f;
                }
                
                else if (singleton.SelezionatoArma3 || singleton.SelezionatoArma4)
                {
                    ricaricaArma = 0.5f;
                } 
                
               
                //shoot(direction);
                sparare();
            }

        }

    }

    private void suono()
    {
        //suono sparare
        if (audioSparare != null)
            audioSparare.PlayOneShot(clip, singleton.Suono);
    }

    private void sparare()
    {
        if (mostro != null)
        {
            // sparare solo se è passato abbastanza tempo dall'ultimo sparo  
            if ((singleton.Munizione - colpiNecessari) >= 0)
            {
                

                

                //scelgo il colpo dell'arma
                //scelgo il danno del colpo
            if (mostro.GetComponent<Collider2D>().enabled)
                {
                    GameObject newpallottola = Instantiate(pallottola, cannaArma.transform.position, Quaternion.identity);
                    singleton.removeMunizione(colpiNecessari);
                if (singleton.SelezionatoArma1)
                {
                    
                        suono();
                        newpallottola.GetComponent<pallottola>().setTarget(mostro, 10, "arma1");
                    
                       
                }
                else if (singleton.SelezionatoArma2)
                {

                        suono();
                        newpallottola.GetComponent<pallottola>().setTarget(mostro, 25, "arma2");
                    
                        
                }
                else if (singleton.SelezionatoArma3)
                {

                        suono();
                        newpallottola.GetComponent<pallottola>().setTarget(mostro, 15, "arma3");
                    
                        
                }
                else if (singleton.SelezionatoArma4)
                {

                        suono();
                        newpallottola.GetComponent<pallottola>().setTarget(mostro, 25, "arma4");
                    
                        
                }
                else if (singleton.SelezionatoArma5)
                {

                        suono();
                        newpallottola.GetComponent<pallottola>().setTarget(mostro, 50, "arma5");
                    
                        
                }
                }
                
               /* else
                {
                    Debug.Log("Errore arma");
                    try
                    {
                        Destroy(bersaglio.gameObject);
                        rimuovereMostroCoda();
                    }
                    catch (System.Exception)
                    {

                        throw;
                    }

                    //nel caso il bersaglio non esistesse più per qualche ragione
                    Destroy(newpallottola);
                    singleton.addMunizione(colpiNecessari);
                }*/
            }

        }
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
