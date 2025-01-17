using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class logica : MonoBehaviour
{
    public GameObject mostro;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnMostri());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator spawnMostri()
    {
       // while (true) {
            Instantiate(mostro, new Vector2(10,0), new Quaternion(0f,0f,0f,0f));
        //Debug.Log("spawnato");
        yield return new WaitForSeconds(5f);
       // }
    }
}
