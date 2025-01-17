using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class quit : MonoBehaviour
{
    private Button pulsante;
    // Start is called before the first frame update
    void Start()
    {
        pulsante = gameObject.GetComponent<Button>();
        pulsante.onClick.AddListener(uscire);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void uscire()
    {
        Application.Quit();
    }
}
