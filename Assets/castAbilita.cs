using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class castAbilita : MonoBehaviour
{
    public Image attivoArma;
    public Image attivoPersonaggio;
    singleton singleton;
    // Start is called before the first frame update
    void Start()
    {
        singleton = singleton.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (singleton.AbilitaCliccataArma)
            attivoArma.enabled = true;
        else
            attivoArma.enabled = false;

        if (singleton.AbilitaCliccataEroe)
            attivoPersonaggio.enabled = true;
        else
            attivoPersonaggio.enabled = false;
    }
}
