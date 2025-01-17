using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class codiceImmaginiAbilita : MonoBehaviour
{
    public Sprite abilitaArma3;
    public Sprite abilitaArma4;
    public Sprite abilitaArma5;

    public Sprite abilitaEroe1;
    public Sprite abilitaEroe2;
    public Sprite abilitaEroe3;

    public Button abilitaArmaPulsante;
    public Button abilitaEroePulsante;

    singleton singleton;

    // Start is called before the first frame update
    void Start()
    {
        singleton = singleton.Instance;
        //abilitaArmaPulsante.onClick.AddListener(abilitaArmaPulsanteClick);
        //abilitaEroePulsante.onClick.AddListener(abilitaEroePulsanteClick);
    }

    // Update is called once per frame
    void Update()
    {

        /*if (singleton.AbilitaUsataArma)
            abilitaArmaPulsante.enabled = false;
        else
            abilitaArmaPulsante.enabled = true;

        if (singleton.AbilitaUsataEroe)
            abilitaEroePulsante.enabled = false;
        else
            abilitaEroePulsante.enabled = true;*/



        if (singleton.SelezionatoArma3)
        {
            abilitaArmaPulsante.image.color = Color.white;
            abilitaArmaPulsante.image.sprite = abilitaArma3;
        }
        else if (singleton.SelezionatoArma4)
        {
            abilitaArmaPulsante.image.color = Color.white;
            abilitaArmaPulsante.image.sprite = abilitaArma4;
        }
        else if (singleton.SelezionatoArma5)
        {
            abilitaArmaPulsante.image.color = Color.white;
            abilitaArmaPulsante.image.sprite = abilitaArma5;
        }
        else
        {
            abilitaArmaPulsante.image.color = new Color(0f, 0f, 0f, 208f / 255.0f);
        }

        if (singleton.SelezionatoPersonaggio1)
        {
            abilitaEroePulsante.image.sprite = abilitaEroe1;
        }
        else if (singleton.SelezionatoPersonaggio2)
        {
            abilitaEroePulsante.image.sprite = abilitaEroe2;
        }
        else if (singleton.SelezionatoPersonaggio3)
        {
            abilitaEroePulsante.image.sprite = abilitaEroe3;
        }


    }



    public void abilitaArmaPulsanteClick()
    {
        //le armi che non hanno abilità
        if(!singleton.SelezionatoArma1 && !singleton.SelezionatoArma2)
            if(singleton.AbilitaCliccataEroe && !singleton.AbilitaCliccataArma)
            {
                singleton.AbilitaCliccataArma = true;
                singleton.AbilitaCliccataEroe = false;
            }
            else
                singleton.AbilitaCliccataArma = !singleton.AbilitaCliccataArma;
    }

    public void abilitaEroePulsanteClick()
    {
        if(singleton.AbilitaCliccataArma && !singleton.AbilitaCliccataEroe)
        {
            singleton.AbilitaCliccataEroe = true;
            singleton.AbilitaCliccataArma = false;
        }
        else
            singleton.AbilitaCliccataEroe = !singleton.AbilitaCliccataEroe;
    }
    
}
