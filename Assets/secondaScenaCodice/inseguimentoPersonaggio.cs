using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inseguimentoPersonaggio : MonoBehaviour
{
    private Transform personaggio;

    // Start is called before the first frame update
    void Start()
    {
        personaggio = GameObject.FindWithTag("personaggioAttivo").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(personaggio.position.x, personaggio.position.y, -10f);
    }
}
