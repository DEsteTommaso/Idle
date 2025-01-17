using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sliderMusica : MonoBehaviour
{
    private Slider slider;
    singleton singleton;
    private void Start()
    {
        singleton = singleton.Instance;
        slider = gameObject.GetComponent<Slider>();
        slider.value = singleton.Musica;
        // Aggiungi un listener per il cambiamento di valore dello Slider
        slider.onValueChanged.AddListener(ValoreCambiato);
    }

    // Questo metodo verrà chiamato ogni volta che il valore dello Slider cambia
    private void ValoreCambiato(float nuovoValore)
    {
        // Puoi fare qualcosa con il nuovo valore qui, ad esempio stamparlo nella console
        singleton.Musica = nuovoValore;
    }
}
