using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class cervelloUI : MonoBehaviour
{
    public Text testoCervelloContenitore;
    singleton singleton;
    // Start is called before the first frame update
    void Start()
    {
        singleton = singleton.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        testoCervelloContenitore.text = singleton.getContenitoreElisir().ToString();
    }
}
