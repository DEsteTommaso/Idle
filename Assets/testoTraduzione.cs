using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class testoTraduzione : MonoBehaviour
{
   
    [SerializeField] private string testoIta;
    [SerializeField] private string testoEng;
    singleton singleton;

    // Start is called before the first frame update
    void Start()
    {
        singleton = singleton.Instance;
        setLingua();
    }

    // Update is called once per frame
    private void setLingua()
    {
        if(singleton.Lingua.Equals("it") && gameObject.TryGetComponent<Text>(out Text testo))
        {
            testo.text = testoIta;
        }
        else if(singleton.Lingua.Equals("it") && gameObject.TryGetComponent<TextMeshPro>(out TextMeshPro testo2))
        {
            testo2.text = testoIta;
        }
        else if (singleton.Lingua.Equals("en") && gameObject.TryGetComponent<Text>(out Text testo3))
        {
            testo3.text = testoEng;
        }
        else if (singleton.Lingua.Equals("en") && gameObject.TryGetComponent<TextMeshPro>(out TextMeshPro testo4))
        {
            testo4.text = testoEng;
        }

    }
}
