using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class uscitaDungeon : MonoBehaviour
{
    singleton singleton;
    // Start is called before the first frame update
    void Start()
    {
        singleton = singleton.Instance;
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("personaggioAttivo"))
        {
            singleton.AbilitaCliccataArma = false;
            singleton.AbilitaCliccataEroe = false;
            singleton.AbilitaUsataEroe = true;
            singleton.AbilitaUsataArma = true;
            singleton.MorteGiocatoreDungeon = false;

            Screen.orientation = ScreenOrientation.Portrait;
            SceneManager.LoadScene("Spawn");
        }
    }
}
