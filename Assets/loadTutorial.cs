using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class loadTutorial : MonoBehaviour
{
    private Button pulsante;
    // Start is called before the first frame update
    void Start()
    {
        pulsante = gameObject.GetComponent<Button>();
        pulsante.onClick.AddListener(HandleButton);
    }

private void HandleButton()
    {
        SceneManager.LoadScene("Tutorial");
    }
}
