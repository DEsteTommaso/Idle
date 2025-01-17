using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class linguaTutorial : MonoBehaviour
{
    public Button pulsanteInglese;
    public Button pulsanteItaliano;
    singleton singleton;

    // Start is called before the first frame update
    void Start()
    {
        singleton = singleton.Instance;
        pulsanteInglese.onClick.AddListener(eng);
        pulsanteItaliano.onClick.AddListener(ita);
    }

    // Update is called once per frame

    private void ita()
    {

        singleton.Lingua = "it";
        SceneManager.LoadScene("Tutorial");
    }

    private void eng()
    {

        singleton.Lingua = "en";
        SceneManager.LoadScene("Tutorial");
    }
}
