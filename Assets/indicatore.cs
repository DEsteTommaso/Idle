using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyJoystick; //line added

public class indicatore : MonoBehaviour
{
    [SerializeField] private Joystick joystick;
    private Transform personaggio;

    private SpriteRenderer immagine;
    // Start is called before the first frame update
    void Start()
    {
        immagine = GetComponent<SpriteRenderer>();
        personaggio = GameObject.FindWithTag("personaggioAttivo").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (joystick.IsTouching)
        {
            immagine.enabled = true;
        }
        else
        {
            immagine.enabled = false;
        }
        
        transform.position = personaggio.position; 

        float xMovement = joystick.Horizontal(); //line changed
        float yMovement = joystick.Vertical();   //line changed
        Vector3 direction = new Vector3(xMovement, yMovement, 0f).normalized; // Normalizza la direzione

        if (direction != Vector3.zero)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; // Calcola l'angolo tra la direzione e l'asse X
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward); // Ruota l'indicatore in base all'angolo
        }
    }

}
