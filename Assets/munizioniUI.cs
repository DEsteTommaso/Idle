using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class munizioniUI : MonoBehaviour
{
    singleton singleton;
    public Text textUI; // Riferimento al componente di testo UI

    // Start is called before the first frame update
    void Start()
    {
        singleton = singleton.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        // Ottieni il valore dell'elisir
        int elisirValue = (int)singleton.getContenitoreMunizioni();

        // Formatta il valore numerico in modo appropriato
        string formattedValue = FormatNumber(elisirValue);

        // Aggiorna il testo UI con il valore formattato
        textUI.text = formattedValue;
    }

    // Metodo per formattare il numero
    string FormatNumber(int value)
    {
        if (value >= 1000000)
        {
            // Calcola il valore in milioni e formatta il testo
            float floatValue = value / 1000000.0f;
            return floatValue.ToString("0.0") + "M";
        }
        else if (value >= 1000)
        {
            // Calcola il valore in migliaia e formatta il testo
            float floatValue = value / 1000.0f;
            return floatValue.ToString("0.0") + "k";
        }
        else
        {
            // Restituisci il valore originale come stringa
            return value.ToString();
        }
    }
}
