using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class spawnMostri : MonoBehaviour
{
    //spawn
    public GameObject undead_warrior;
    public GameObject ghoul;
    public GameObject imp;    
    public GameObject reaper;
    public GameObject phantom_knight;


    private bool spawnUndeadWarrior = true;
    private bool spawnGhoul = false;
    private bool spawnImp = false;
    private bool spawnReaper = false;
    private bool spawnPhantomKnight = false;


    //spawn intervallo
    private float timer = 0f;
    private float spawnInterval = 5f; // Intervallo tra ogni spawn di tipo di nemico
    private int nemicoCorrente = 0;

    //spawn intervallo 15 secondi
    private float timer2 = 0f;
    private float spawnInterval2 = 25f; // Intervallo tra ogni spawn di tipo di nemico

    //

    private Vector3 vertice0 = new Vector3(-11f, 5f, 0f);
    private Vector3 vertice1 = new Vector3(-18f, -2f, 0f);
    private Vector3 vertice2 = new Vector3(-18f, -12f, 0f);
    private Vector3 vertice3 = new Vector3(-11f, -19f, 0f);
    private Vector3 vertice4 = new Vector3(12f, -19f, 0f);
    private Vector3 vertice5 = new Vector3(19f, -12f, 0f);
    private Vector3 vertice6 = new Vector3(19f, -2f, 0f);
    private Vector3 vertice7 = new Vector3(12f, 5f, 0f);

    private Vector3 nuovaPosizione;

    private Transform personaggio;
    private float massimo;
    private int num;

    private float distanza1;
    private float distanza2;
    private float distanza3;
    private float distanza4;
    private float distanza5;
    private float distanza6;
    private float distanza7;
    private float distanza8;

    //private bool spawnBool = false;
    private bool aspettareSpawnBool = false;

    private GameObject nuovoOggetto;
    private Transform nuovoTransform;

    




    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(aspettare());
        
    }

    // Update is called once per frame
    void Update()
    {
        if (aspettareSpawnBool) { 
        // Crea un nuovo oggetto GameObject
        nuovoOggetto = new GameObject("NuovoOggetto");

        // Crea un oggetto Transform
        nuovoTransform = nuovoOggetto.transform;

        //distanza vettore1
        nuovaPosizione = vertice0;
        nuovoTransform.position = nuovaPosizione;

        distanza1 = calcolaDistanzaTraPunti(personaggio, nuovoTransform);

        //distanza vettore2

        nuovaPosizione = vertice1;
        nuovoTransform.position = nuovaPosizione;

        distanza2 = calcolaDistanzaTraPunti(personaggio, nuovoTransform);

        //distanza vettore3

        nuovaPosizione = vertice2;
        nuovoTransform.position = nuovaPosizione;

        distanza3 = calcolaDistanzaTraPunti(personaggio, nuovoTransform);

        //distanza vettore4

        nuovaPosizione = vertice3;
        nuovoTransform.position = nuovaPosizione;

        distanza4 = calcolaDistanzaTraPunti(personaggio, nuovoTransform);

        //distanza vettore5

        nuovaPosizione = vertice4;
        nuovoTransform.position = nuovaPosizione;

        distanza5 = calcolaDistanzaTraPunti(personaggio, nuovoTransform);

        //distanza vettore6

        nuovaPosizione = vertice5;
        nuovoTransform.position = nuovaPosizione;

        distanza6 = calcolaDistanzaTraPunti(personaggio, nuovoTransform);

        //distanza vettore7

        nuovaPosizione = vertice6;
        nuovoTransform.position = nuovaPosizione;

        distanza7 = calcolaDistanzaTraPunti(personaggio, nuovoTransform);

        //distanza vettore8

        nuovaPosizione = vertice7;
        nuovoTransform.position = nuovaPosizione;

        distanza8 = calcolaDistanzaTraPunti(personaggio, nuovoTransform);


        List<float> numeri = new List<float>();

        numeri.Add(distanza1);
        numeri.Add(distanza2);
        numeri.Add(distanza3);
        numeri.Add(distanza4);
        numeri.Add(distanza5);
        numeri.Add(distanza6);
        numeri.Add(distanza7);
        numeri.Add(distanza8);

        massimo = numeri.Max();

        // Debug.Log("Max: " + massimo);

        //trovo l'index
        num = numeri.FindIndex(a => a == massimo);


            //codice spawn mostri
            timer += Time.deltaTime;
            timer2 += Time.deltaTime;

            //ogni tot secondi spawna un mostro
            if (timer >= spawnInterval)
        {
            timer = 0f;

                if (spawnUndeadWarrior)
                {

                    StartCoroutine(SpawnEnemy(undead_warrior, 0f));
                }

                if (spawnGhoul)
                {
                    StartCoroutine(SpawnEnemy(ghoul, 1f));

                }
                if (spawnImp)
                {
                    StartCoroutine(SpawnEnemy(imp,2f));
                }

                if (spawnReaper)
                {
                    StartCoroutine(SpawnEnemy(reaper,3f));
                }

                if (spawnPhantomKnight)
                {
                    StartCoroutine(SpawnEnemy(phantom_knight,4f));
                    
                }

                //ogni 15 secondi spawna anche il mostro successivo
                if (timer2 >= spawnInterval2)
                {
                    timer2 = 0;
                    nemicoCorrente = (nemicoCorrente + 1) % 5; // Passa al tipo di nemico successivo

                    switch (nemicoCorrente)
                    {
                        case 1:
                            spawnGhoul = true;
                            break;
                        case 2:
                            spawnImp = true;
                            break;
                        case 3:
                            spawnReaper = true;
                            break;
                        case 4:
                            spawnPhantomKnight = true;
                            break;
                        default:
                            break;
                    }
                }
            }
            






            //Debug.Log("E' il vettore: " + (num));
            Destroy(nuovoOggetto);
            Destroy(nuovoTransform);

        }
    }

    IEnumerator SpawnEnemy(GameObject enemyPrefab, float delay)
    {
        yield return new WaitForSeconds(delay);

        switch (num)
        {
            case 0:
                Instantiate(enemyPrefab, vertice0, Quaternion.identity);
                break;
            case 1:
                Instantiate(enemyPrefab, vertice1, Quaternion.identity);
                break;
            case 2:
                Instantiate(enemyPrefab, vertice2, Quaternion.identity);
                break;
            case 3:
                Instantiate(enemyPrefab, vertice3, Quaternion.identity);
                break;
            case 4:
                Instantiate(enemyPrefab, vertice4, Quaternion.identity);
                break;
            case 5:
                Instantiate(enemyPrefab, vertice5, Quaternion.identity);
                break;
            case 6:
                Instantiate(enemyPrefab, vertice6, Quaternion.identity);
                break;
            case 7:
                Instantiate(enemyPrefab, vertice7, Quaternion.identity);
                break;
        }

        yield return null;

        //g = Instantiate(g, )
    }

    IEnumerator aspettare()
    {
        yield return new WaitForSeconds(2f);
        personaggio = GameObject.FindWithTag("personaggioAttivo").transform;
        aspettareSpawnBool = true;
        StopCoroutine(aspettare());
    }

    float calcolaDistanzaTraPunti(Transform personaggio, Transform vertice)
    {
        float distanza = Vector3.Distance(personaggio.position, vertice.position);
        return distanza;
    }
}
