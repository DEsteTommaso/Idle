using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class personaggioTutorial : MonoBehaviour
{
    private Animator animazione;
    private float speed = 3f;
    private bool corsa = false;
    private bool idle = true;
    singleton singleton;

    // Start is called before the first frame update
    void Start()
    {
        singleton = singleton.Instance;
        animazione = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (singleton.ColpoTutorial)
        {
            corsa = true;
            idle = false;
            animazione.Play("corsa");
        }
        else if (singleton.RisorseTutorial)
        {
            corsa = true;
            idle = false;
            animazione.Play("corsa");
        }

        if (singleton.ColpoTutorial && corsa && transform.position.x < 3.2f && !idle)
        {
            // Sposta il personaggio a destra utilizzando Translate
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else if(singleton.ColpoTutorial)
        {
            singleton.ColpoTutorial = false;
            corsa = false;
            idle = true;
            animazione.Play("idle");
        }


        if (singleton.RisorseTutorial && corsa && transform.position.x < 16.85f && !idle)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else if(singleton.RisorseTutorial)
        {
            singleton.RisorseTutorial = false;
            corsa = false;
            idle = true;
            animazione.Play("idle");
        }
    }
}
