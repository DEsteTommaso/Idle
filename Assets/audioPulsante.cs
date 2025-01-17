using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class audioPulsante : MonoBehaviour
{
    public AudioClip clip;
    private AudioSource pulsante;
    singleton singleton;

    // Start is called before the first frame update
    void Start()
    {
        singleton = singleton.Instance;
        pulsante = gameObject.GetComponent<AudioSource>();
        gameObject.GetComponent<Button>().onClick.AddListener(click);

    }

    private void click()
    {
            if (pulsante != null)
            pulsante.PlayOneShot(clip, singleton.Suono);
    }

}
