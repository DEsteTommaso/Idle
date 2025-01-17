using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timerAds : MonoBehaviour
{
    private Text timerText;
    private float timeLeft = 60.0f;
    public GameObject pannello;

    private void Start()
    {
        timerText = gameObject.GetComponent<Text>();
    }

    public void resetTimer()
    {
        timeLeft = 60.0f;
    }

    void Update()
    {

        // Sottrai il tempo dall'orologio
        timeLeft -= Time.deltaTime;

        // Assicurati che il timer non scenda sotto zero
        if (timeLeft < 0)
        {
            timeLeft = 0;
        }

        // Aggiorna il testo del timer con il tempo rimanente formattato come "ss s"
        timerText.text = timeLeft.ToString("00") + " s";

        // Se il tempo è scaduto, puoi eseguire un'azione qui
        if (timeLeft <= 0)
        {
            pannello.SetActive(false);
            // Fai qualcosa quando il timer raggiunge zero
            //Debug.Log("Tempo scaduto!");
        }
    }
}
