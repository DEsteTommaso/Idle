using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using UnityEngine.Networking;
using System;
using UnityEngine.UI;

public class tempoManager : MonoBehaviour
{       
    
    const string API_URL = "https://worldtimeapi.org/api/ip";

    singleton singleton;

    public GameObject pannello;
    public Button pulsante;
    public Text testo;

    // Start is called before the first frame update
    void Start()
    {

        singleton = singleton.Instance;
        pulsante.onClick.AddListener(pulsanteMoneta);
        StartCoroutine(GetRealDateTimeFromAPI());

    }


    private void pulsanteMoneta()
    {
        singleton.addMoneta((float)singleton.MoneteGuadagnateOffline);
        pannello.SetActive(false);
    }

    IEnumerator GetRealDateTimeFromAPI()
    {
        UnityWebRequest webRequest = UnityWebRequest.Get(API_URL);

        yield return webRequest.SendWebRequest();

        if (webRequest.isNetworkError)
        {
            Debug.Log("Fetch data error");
        }
        else
        {
            TimeData timeData = JsonUtility.FromJson<TimeData>(webRequest.downloadHandler.text);

            //conversione
            string date = Regex.Match(timeData.datetime, @"^\d{4}-\d{2}-\d{2}").Value;
            string time = Regex.Match(timeData.datetime, @"\d{2}:\d{2}:\d{2}").Value;


            Debug.Log("Data: " + date);
            Debug.Log("Time: " + time);

            string dataString = string.Format("{0} {1}", date, time);

            // Calcola la differenza in minuti

            Debug.Log("Ultimo accesso: " + singleton.UltimoAccesso);

            if(singleton.UltimoAccesso.Length == 0)
            {
                singleton.UltimoAccesso = dataString;
            }
            else
            {

                TimeSpan differenza = DateTime.Parse(dataString) - DateTime.Parse(singleton.UltimoAccesso);
                double differenzaInMinuti = differenza.TotalMinutes;

                differenzaInMinuti = Math.Round(differenzaInMinuti);

                double monete = 0;

                Debug.Log("Differenza " + differenzaInMinuti);


                    Debug.Log("Entrato");

                    if (singleton.SelezionatoArma1)
                    {
                        monete += differenzaInMinuti * 12 * 25;
                    }else if (singleton.SelezionatoArma2)
                    {
                        monete += differenzaInMinuti * 20 * 25;
                    }
                    else if (singleton.SelezionatoArma3)
                    {
                        monete += differenzaInMinuti * 30 * 25;
                    }
                    else if (singleton.SelezionatoArma4)
                    {
                        monete += differenzaInMinuti * 30 * 25;
                    }
                    else if (singleton.SelezionatoArma5)
                    {
                        monete += differenzaInMinuti * 60 * 25;
                    }



                    //secondo livello
                    if (singleton.CompratoPrimoLivelloNuovoLivello) {

                        int v = singleton.LivelloSecondoLivelloDannoMitraglietta;
                        if (v == 1)
                        {
                            monete += differenzaInMinuti * 3 * 50;
                        }
                        else if (v == 2)
                        {
                            monete += differenzaInMinuti * 5 * 50;
                        }
                        else if (v == 3)
                        {
                            monete += differenzaInMinuti * 6 * 50;
                        }
                        else if (v == 4)
                        {
                            monete += differenzaInMinuti * 9 * 50;
                        }
                        else if (v == 5)
                        {
                            monete += differenzaInMinuti * 12 * 50;
                        }

                    }

                    //terzo livello
                    if (singleton.CompratoSecondoLivelloNuovoLivello) {

                        int v = singleton.LivelloTerzoLivelloDannoMitraglietta;
                        if (v == 1)
                        {
                            monete += differenzaInMinuti * 3 * 100;
                        }
                        else if (v == 2)
                        {
                            monete += differenzaInMinuti * 5 * 100;
                        }
                        else if (v == 3)
                        {
                            monete += differenzaInMinuti * 6 * 100;
                        }
                        else if (v == 4)
                        {
                            monete += differenzaInMinuti * 9 * 100;
                        }
                        else if (v == 5)
                        {
                            monete += differenzaInMinuti * 12 * 100;
                        }

                    }

                    //quarto livello
                    if (singleton.CompratoTerzoLivelloNuovoLivello) {
                        int v = singleton.LivelloQuartoLivelloDannoMitraglietta;
                        if (v == 1)
                        {
                            monete += differenzaInMinuti * 3 * 150;
                        }
                        else if (v == 2)
                        {
                            monete += differenzaInMinuti * 5 * 150;
                        }
                        else if (v == 3)
                        {
                            monete += differenzaInMinuti * 6 * 150;
                        }
                        else if (v == 4)
                        {
                            monete += differenzaInMinuti * 9 * 150;
                        }
                        else if (v == 5)
                        {
                            monete += differenzaInMinuti * 12 * 150;
                        }

                    }

                    //quinto livello
                    if (singleton.CompratoQuartoLivelloNuovoLivello) {

                        int v = singleton.LivelloQuintoLivelloDannoMitraglietta;
                        if (v == 1)
                        {
                            monete += differenzaInMinuti * 3 * 200;
                        }
                        else if (v == 2)
                        {
                            monete += differenzaInMinuti * 5 * 200;
                        }
                        else if (v == 3)
                        {
                            monete += differenzaInMinuti * 6 * 200;
                        }
                        else if (v == 4)
                        {
                            monete += differenzaInMinuti * 9 * 200;
                        }
                        else if (v == 5)
                        {
                            monete += differenzaInMinuti * 12 * 200;
                        }
                    }

                    monete = Math.Floor(monete / 2);

                    if(monete > 100000)
                    {
                        monete = 100000;
                    }


                    pannello.SetActive(true);
                    testo.text = monete.ToString();
                    singleton.MoneteGuadagnateOffline = monete;



                
            }
            


        }

    }


    struct TimeData {

        public string datetime;

    }

}
