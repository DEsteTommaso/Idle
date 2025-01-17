using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pulsanteShop : MonoBehaviour
{

    public GameObject GameObjectAttivare;
    public GameObject GameobjectDisattivare;
    public GameObject GameObjectDisattivare2;
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

        GameObjectAttivare.SetActive(true);
        GameobjectDisattivare.SetActive(false);
        GameObjectDisattivare2.SetActive(false);
    }


}
