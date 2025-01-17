using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class battagliaPulsante : MonoBehaviour
{
    public Button pulsanteApertura;
    public Button pulsanteChiusura;
    public Button pulsanteBattaglia;

    private Animator animazione;

    public GameObject pannelloComparsa;

    singleton singleton;


    // Start is called before the first frame update
    void Start()
    {
        singleton = singleton.Instance;

        pulsanteApertura.onClick.AddListener(HandleButtonApertura);
        pulsanteChiusura.onClick.AddListener(HandleButtonChiusura);
        pulsanteBattaglia.onClick.AddListener(HandleButtonBattaglia);

        animazione = pannelloComparsa.GetComponentInChildren<Animator>();
    }

    // Update is called once per frame

    private void HandleButtonApertura()
    {
        pannelloComparsa.SetActive(true);
        //animazione.Play("BattagliaDungeonApertura");
    }

    private void HandleButtonChiusura()
    {
        animazione.Play("BattagliaDungeonChiusura");
        StartCoroutine(chiusura());
    }

    private void HandleButtonBattaglia()
    {
        // Rimuovi la scena corrente prima di caricare la nuova scena
        //SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);

        //azzero lo spawn degli indici dei mostri

        singleton.MostriLivello1 = 0;
        singleton.MostriLivello2 = 0;
        singleton.MostriLivello3 = 0;
        singleton.MostriLivello4 = 0;
        singleton.MostriLivello5 = 0;

        // Carica la nuova scena specificata
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        SceneManager.LoadScene("Dungeon");
    }


    IEnumerator chiusura()
    {
        yield return new WaitForSeconds(1f);
        pannelloComparsa.SetActive(false);
    }
}
