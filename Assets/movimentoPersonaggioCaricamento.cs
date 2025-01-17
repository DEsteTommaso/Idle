using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class movimentoPersonaggioCaricamento : MonoBehaviour
{
    private float speed = 20;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x >= 1250)
        {
            transform.position = new Vector3(-220, 1311, 0);
        }
        transform.position += new Vector3(10, 0, 0) * speed * Time.deltaTime;
    }
}
