using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class italianoTutorial : MonoBehaviour
{
    private Button pulsante;
    singleton singleton;
    // Start is called before the first frame update
    void Start()
    {
        singleton = singleton.Instance;
        pulsante = gameObject.GetComponent<Button>();
        pulsante.onClick.AddListener(HandleButton);
    }

    private void HandleButton()
    {
        singleton.Lingua = "it";
        SceneManager.LoadScene("Tutorial");
    }
}
