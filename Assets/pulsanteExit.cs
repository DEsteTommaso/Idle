using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uscitaMiglioramentiLivello : MonoBehaviour
{
    public GameObject miglioramentoLivelli;
    public Button pulsante;

    // Start is called before the first frame update
    void Start()
    {
        pulsante.onClick.AddListener(HandleButtonClick);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void HandleButtonClick()
    {

        miglioramentoLivelli.SetActive(false);
    }
}
