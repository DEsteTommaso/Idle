using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colpo_imp : MonoBehaviour
{
    private int danno = 20;
    private float velocita = 5f;

    private Vector3 target;

    private bool spara = false;

    private Vector3 initialDirection;


    void Start()
    {
        Destroy(gameObject, 10f); // distruggi il proiettile dopo 3 secondi  
    }

    // Update is called once per frame
    void Update()
    {
        if (spara) {
            transform.position += initialDirection * velocita * Time.deltaTime;
            //transform.position += initialDirection * velocita * Time.deltaTime;
        }
    }

    public void setTarget(Vector3 target)
    {
        //target = posizione personaggio
        if (target != null)
        {

            initialDirection = (target - transform.position).normalized;
            //Debug.Log("target: " + target);

            //Rotazione colpo
            Vector2 direction = target - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            //assegno 180 gradi così la rotazione non è sbagliata
            angle += 180f;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        //

            this.target = target;
            spara = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //controllo che prima sia un nemico e poi che colpisca solamente il nemico indicato (problema sovrapposizione)
        if (collision.gameObject.CompareTag("personaggioAttivo"))
        {
            //Debug.Log("nome: " + collision.gameObject.name);

            codicePersonaggio personaggio = collision.gameObject.GetComponent<codicePersonaggio>();
                personaggio.colpito(danno);
                Destroy(gameObject);
            //Debug.Log("Colpo Imp");


        }
    }
}
