using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyJoystick; //line added

public class bastoneDelPrincipiante : MonoBehaviour
{

    private Transform personaggio;

    //per far oscillare l'arma
    //adjust this to change speed
    float speed = 3f;
    //adjust this to change how high it goes
    float height = 0.25f;

    float lastPosX = 0;
    //

    [SerializeField] private Joystick joystick;

    private bool staSparando = false;

    //codice per colpi
    private assegnareColpiArmi assegnareColpiArmi;
    public GameObject script;

    private bool pannelloColpiBool = true;
    public GameObject pannelloColpi;

    singleton singleton;

    // Start is called before the first frame update
    void Start()
    {
        singleton = singleton.Instance;
        personaggio = GameObject.FindWithTag("personaggioAttivo").transform;
        assegnareColpiArmi = script.GetComponent<assegnareColpiArmi>();
    }

    // Update is called once per frame
    void Update()
    {
        //calculate what the new Y position will be
        float newY = Mathf.Sin(Time.time * speed) * height + personaggio.position.y;
        //set the object's Y to the new calculated Y
        if (lastPosX <= personaggio.position.x)
        {
            transform.position = new Vector3(personaggio.position.x - 1, newY + 1, personaggio.position.z);
        }
        else
        {
            transform.position = new Vector3(personaggio.position.x + 1, newY + 1, personaggio.position.z);
        }

        lastPosX = personaggio.position.x;

        if (joystick.IsTouching && !staSparando)
        {
            staSparando = true;
            StartCoroutine(sparare());
        }

    }

    IEnumerator sparare()
    {
        yield return new WaitForSeconds(1f);
        while (joystick.IsTouching && !singleton.MorteGiocatoreDungeon)
        {
            float xMovement = joystick.Horizontal();
            float yMovement = joystick.Vertical();

            //Debug.Log("X: " + xMovement);
            //Debug.Log("Y: " + yMovement);

            Vector3 position = new Vector3(xMovement, yMovement, 0f);

            //nel caso fosse selezionata un'abilità e si cercasse di usare quella (non togliere colpi)
            if (singleton.AbilitaCliccataArma || singleton.AbilitaCliccataEroe)
            {
                GameObject newpallottola = Instantiate(assegnareColpiArmi.getColpo(), personaggio.position, Quaternion.identity);
                yield return new WaitForSeconds(0.1f);

                if (newpallottola != null)
                    assegnareColpiArmi.setTraiettoria(newpallottola, position);
            }
            else if (singleton.Munizione - 1 >= 0) {
                singleton.removeMunizione(1);
                
                
            GameObject newpallottola = Instantiate(assegnareColpiArmi.getColpo(), personaggio.position, Quaternion.identity);
            yield return new WaitForSeconds(0.1f);


            if (newpallottola != null)
                assegnareColpiArmi.setTraiettoria(newpallottola, position); }
            else
            {
                //vuol dire che sono finiti i colpi 
                if (pannelloColpiBool)
                {
                    pannelloColpiBool = false;
                    pannelloColpi.SetActive(true);

                    GameObject[] enemies = GameObject.FindGameObjectsWithTag("nemico");

                    // Distruggi ciascun nemico
                    foreach (GameObject enemy in enemies)
                    {
                        Destroy(enemy);
                    }
                    Time.timeScale = 0;
                }

            }
            


            // Destroy(g); // Distruggi il GameObject temporaneo dopo averlo utilizzato

            //faccio passare tre secondi
            if (joystick.IsTouching)
                yield return new WaitForSeconds(0.5f);
            else break;
            if (joystick.IsTouching)
                yield return new WaitForSeconds(0.5f);
            else break;

        }
        staSparando = false;
        StopCoroutine(sparare());
    }
}
