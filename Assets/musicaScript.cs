using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicaScript : MonoBehaviour
{

    //public AudioClip musica;
    private AudioSource audioSource;

    singleton singleton;

    // Start is called before the first frame update
    void Start()
    {
        singleton = singleton.Instance;

        DontDestroyOnLoad(this);
        audioSource = gameObject.GetComponent<AudioSource>();
        //audioSource.PlayOneShot(musica);
    }

    public void playMusica()
    {
        audioSource.Play();
    }


    public void Update()
    {
        audioSource.volume = singleton.Musica;
    }
}
