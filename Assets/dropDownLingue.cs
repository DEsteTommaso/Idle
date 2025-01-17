using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dropDownLingue : MonoBehaviour
{

    public Dropdown dropDownLingua;
    singleton singleton;

    // Start is called before the first frame update
    void Start()
    {
        singleton = singleton.Instance;

        if (singleton.Lingua.Contains("it"))
            dropDownLingua.value = 0;
        else if (singleton.Lingua.Contains("en"))
            dropDownLingua.value = 1;

        dropDownLingua.onValueChanged.AddListener(delegate
        {
            valoreCambiato(dropDownLingua);
        });


    }

    private void valoreCambiato(Dropdown valore) {
        switch (valore.value)
        {
            case 0:
                singleton.Lingua = "it";
                break;

            case 1:
                singleton.Lingua = "en";
                break;
        }
        //esco dall'applicazione
        StartCoroutine(wait());

    }


    IEnumerator wait()
    {
        yield return new WaitForSeconds(1f);
        Application.Quit();
    }
}
