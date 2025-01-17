using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pulsanteFarm : MonoBehaviour
{
    private Button pulsante;
    private bool attivo = true;
    private float countdownTimer = 0.5f; // Durata del timer in secondi
    // Start is called before the first frame update
    void Start()
    {
        pulsante = gameObject.GetComponent<Button>();
        pulsante.onClick.AddListener(time);
    }

    // Update is called once per frame
    void Update()
    {
        if (!attivo)
        {
                countdownTimer -= Time.deltaTime; // Sottrai il tempo trascorso

                if (countdownTimer <= 0f)
                {
                // Il timer è scaduto
                //Debug.Log("Timer scaduto!");
                attivo = true;
                    pulsante.enabled = true;
                    countdownTimer = 0.5f;
            }
            
        }


    }

    private void time()
    {
        if (attivo)
        {
            attivo = false;
            pulsante.enabled = false;
        }
    }
}
