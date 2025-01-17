using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rimborsoColpi : MonoBehaviour
{
    singleton singleton;
    // Start is called before the first frame update
    void Start()
    {
        singleton = singleton.Instance;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("nemico"))
        {
            if (collision.gameObject.GetComponent<pallottola>().getTipologia().Equals("arma1"))
            {
                singleton.addMunizione(1);
            }
            else if (collision.gameObject.GetComponent<pallottola>().getTipologia().Equals("arma2"))
            {
                singleton.addMunizione(2);
            }
            else if (collision.gameObject.GetComponent<pallottola>().getTipologia().Equals("arma3"))
            {
                singleton.addMunizione(3);
            }
            else if (collision.gameObject.GetComponent<pallottola>().getTipologia().Equals("arma4"))
            {
                singleton.addMunizione(4);
            }
            else if (collision.gameObject.GetComponent<pallottola>().getTipologia().Equals("arma5"))
            {
                singleton.addMunizione(5);
            }
            else if (collision.gameObject.GetComponent<pallottola>().getTipologia().Equals("torretta1"))
            {
                singleton.addMunizione(singleton.LivelloSecondoLivelloDannoMitraglietta);
            }
            else if (collision.gameObject.GetComponent<pallottola>().getTipologia().Equals("torretta2"))
            {
                singleton.addMunizione(singleton.LivelloTerzoLivelloDannoMitraglietta);
            }
            else if (collision.gameObject.GetComponent<pallottola>().getTipologia().Equals("torretta3"))
            {
                singleton.addMunizione(singleton.LivelloQuartoLivelloDannoMitraglietta);
            }
            else if (collision.gameObject.GetComponent<pallottola>().getTipologia().Equals("torretta4"))
            {
                singleton.addMunizione(singleton.LivelloQuintoLivelloDannoMitraglietta);
            }

        }
    }
}
