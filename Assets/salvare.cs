using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Firestore;
using Firebase.Extensions;


public class salvare : MonoBehaviour
{

    //database firestore
    private FirebaseFirestore db;
    private Dictionary<string, object> c;
    singleton singleton;

    private static salvare salvareInstance;
    void Awake()
    {
        DontDestroyOnLoad(this);

        if (salvareInstance == null)
        {
            salvareInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        singleton = singleton.Instance;
        //INSERITO DATI
        db = FirebaseFirestore.DefaultInstance;

    }

    void OnApplicationQuit()
     {
        salvareDati();
         Debug.Log("Salvato");
     }

     void OnApplicationFocus(bool focus)
     {
         
         if (focus)
         {
            salvareDati();
             Debug.Log("Salvato");
         }
     }

     void OnApplicationPause(bool pause)
     {
         if (pause)
         {
            salvareDati();
             Debug.Log("Salvato");
         }

     }




    private void salvareDati()
    {

        c = new Dictionary<string, object>()
        {
            {"Monete", singleton.Moneta},
            {"Elisir", singleton.Elisir },
            {"Metallo" , singleton.Metallo },
            {"Munizione" , singleton.Munizione },
            {"Comprato Primo Livello Pulsanti" , new Dictionary<string, object>
                {
                    {"Nuovo Livello", singleton.CompratoPrimoLivelloNuovoLivello},
                    {"Spawn", singleton.CompratoPrimoLivelloSpawn},
                    {"Estrattore Elisir", singleton.CompratoPrimoLivelloEstrattoreElisir},
                    {"Contenitore Elisir", singleton.CompratoPrimoLivelloContenitoreElisir},
                    {"Produzione Metallo", singleton.CompratoPrimoLivelloProduzioneMetallo},
                    {"Contenitore Metallo", singleton.CompratoPrimoLivelloContenitoreMetallo},
                    {"Produzione Munizioni", singleton.CompratoPrimoLivelloProduzioneMunizioni},
                    {"Contenitore Munizioni", singleton.CompratoPrimoLivelloContenitoreMunizioni},
                }
            },
            {"Comprato Secondo Livello Pulsanti" , new Dictionary<string, object>
                {
                    {"Nuovo Livello", singleton.CompratoSecondoLivelloNuovoLivello},
                    {"Spawn", singleton.CompratoSecondoLivelloSpawn},
                    {"Estrattore Elisir", singleton.CompratoSecondoLivelloEstrattoreElisir},
                    {"Contenitore Elisir", singleton.CompratoSecondoLivelloContenitoreElisir},
                    {"Produzione Metallo", singleton.CompratoSecondoLivelloProduzioneMetallo},
                    {"Contenitore Metallo", singleton.CompratoSecondoLivelloContenitoreMetallo},
                    {"Produzione Munizioni", singleton.CompratoSecondoLivelloProduzioneMunizioni},
                    {"Contenitore Munizioni", singleton.CompratoSecondoLivelloContenitoreMunizioni},
                    {"Torretta", singleton.CompratoSecondoLivelloTorretta},
                }
            },
            {"Comprato Terzo Livello Pulsanti" , new Dictionary<string, object>
                {
                    {"Nuovo Livello", singleton.CompratoTerzoLivelloNuovoLivello},
                    {"Spawn", singleton.CompratoTerzoLivelloSpawn},
                    {"Estrattore Elisir", singleton.CompratoTerzoLivelloEstrattoreElisir},
                    {"Contenitore Elisir", singleton.CompratoTerzoLivelloContenitoreElisir},
                    {"Produzione Metallo", singleton.CompratoTerzoLivelloProduzioneMetallo},
                    {"Contenitore Metallo", singleton.CompratoTerzoLivelloContenitoreMetallo},
                    {"Produzione Munizioni", singleton.CompratoTerzoLivelloProduzioneMunizioni},
                    {"Contenitore Munizioni", singleton.CompratoTerzoLivelloContenitoreMunizioni},
                    {"Torretta", singleton.CompratoTerzoLivelloTorretta},
                }
            },
            {"Comprato Quarto Livello Pulsanti" , new Dictionary<string, object>
                {
                    {"Nuovo Livello", singleton.CompratoQuartoLivelloNuovoLivello},
                    {"Spawn", singleton.CompratoQuartoLivelloSpawn},
                    {"Estrattore Elisir", singleton.CompratoQuartoLivelloEstrattoreElisir},
                    {"Contenitore Elisir", singleton.CompratoQuartoLivelloContenitoreElisir},
                    {"Produzione Metallo", singleton.CompratoQuartoLivelloProduzioneMetallo},
                    {"Contenitore Metallo", singleton.CompratoQuartoLivelloContenitoreMetallo},
                    {"Produzione Munizioni", singleton.CompratoQuartoLivelloProduzioneMunizioni},
                    {"Contenitore Munizioni", singleton.CompratoQuartoLivelloContenitoreMunizioni},
                    {"Torretta", singleton.CompratoQuartoLivelloTorretta},
                }
            },
            {"Comprato Quinto Livello Pulsanti" , new Dictionary<string, object>
                {
                    {"Spawn", singleton.CompratoQuintoLivelloSpawn},
                    {"Estrattore Elisir", singleton.CompratoQuintoLivelloEstrattoreElisir},
                    {"Contenitore Elisir", singleton.CompratoQuintoLivelloContenitoreElisir},
                    {"Produzione Metallo", singleton.CompratoQuintoLivelloProduzioneMetallo},
                    {"Contenitore Metallo", singleton.CompratoQuintoLivelloContenitoreMetallo},
                    {"Produzione Munizioni", singleton.CompratoQuintoLivelloProduzioneMunizioni},
                    {"Contenitore Munizioni", singleton.CompratoQuintoLivelloContenitoreMunizioni},
                    {"Torretta", singleton.CompratoQuintoLivelloTorretta},
                }
            },
            {"Livelli Primo Livello" , new Dictionary<string, object>
                {
                    {"Spawn", singleton.LivelloPrimoLivelloVelocitaSpawn},
                    {"Estrattore Elisir", singleton.LivelloPrimoLivelloQuantitaEstrattoreElisir},
                    {"Contenitore Elisir", singleton.LivelloPrimoLivelloCapienzaContenitoreElisir},
                    {"Produzione Metallo", singleton.LivelloPrimoLivelloQuantitaProduzioneMetallo},
                    {"Contenitore Metallo", singleton.LivelloPrimoLivelloCapienzaProduzioneMetallo },
                    {"Produzione Munizioni", singleton.LivelloPrimoLivelloQuantitaProduzioneMunizioni},
                    {"Contenitore Munizioni", singleton.LivelloPrimoLivelloCapienzaContenitoreMunizioni},
                }
            },
            {"Livelli Secondo Livello" , new Dictionary<string, object>
                {
                    {"Spawn", singleton.LivelloSecondoLivelloVelocitaSpawn},
                    {"Estrattore Elisir", singleton.LivelloSecondoLivelloQuantitaEstrattoreElisir},
                    {"Contenitore Elisir", singleton.LivelloSecondoLivelloCapienzaContenitoreElisir},
                    {"Produzione Metallo", singleton.LivelloSecondoLivelloQuantitaProduzioneMetallo},
                    {"Contenitore Metallo", singleton.LivelloSecondoLivelloCapienzaProduzioneMetallo },
                    {"Produzione Munizioni", singleton.LivelloSecondoLivelloQuantitaProduzioneMunizioni},
                    {"Contenitore Munizioni", singleton.LivelloSecondoLivelloCapienzaContenitoreMunizioni},
                    {"Torretta", singleton.LivelloSecondoLivelloDannoMitraglietta},
                }
            },
            {"Livelli Terzo Livello" , new Dictionary<string, object>
                {
                    {"Spawn", singleton.LivelloTerzoLivelloVelocitaSpawn},
                    {"Estrattore Elisir", singleton.LivelloTerzoLivelloQuantitaEstrattoreElisir},
                    {"Contenitore Elisir", singleton.LivelloTerzoLivelloCapienzaContenitoreElisir},
                    {"Produzione Metallo", singleton.LivelloTerzoLivelloQuantitaProduzioneMetallo},
                    {"Contenitore Metallo", singleton.LivelloTerzoLivelloCapienzaProduzioneMetallo },
                    {"Produzione Munizioni", singleton.LivelloTerzoLivelloQuantitaProduzioneMunizioni},
                    {"Contenitore Munizioni", singleton.LivelloTerzoLivelloCapienzaContenitoreMunizioni},
                    {"Torretta", singleton.LivelloTerzoLivelloDannoMitraglietta},
                }
            },
            {"Livelli Quarto Livello" , new Dictionary<string, object>
                {
                    {"Spawn", singleton.LivelloQuartoLivelloVelocitaSpawn},
                    {"Estrattore Elisir", singleton.LivelloQuartoLivelloQuantitaEstrattoreElisir},
                    {"Contenitore Elisir", singleton.LivelloQuartoLivelloCapienzaContenitoreElisir},
                    {"Produzione Metallo", singleton.LivelloQuartoLivelloQuantitaProduzioneMetallo},
                    {"Contenitore Metallo", singleton.LivelloQuartoLivelloCapienzaProduzioneMetallo },
                    {"Produzione Munizioni", singleton.LivelloQuartoLivelloQuantitaProduzioneMunizioni},
                    {"Contenitore Munizioni", singleton.LivelloQuartoLivelloCapienzaContenitoreMunizioni},
                    {"Torretta", singleton.LivelloQuartoLivelloDannoMitraglietta},
                }
            },
            {"Livelli Quinto Livello" , new Dictionary<string, object>
                {
                    {"Spawn", singleton.LivelloQuintoLivelloVelocitaSpawn},
                    {"Estrattore Elisir", singleton.LivelloQuintoLivelloQuantitaEstrattoreElisir},
                    {"Contenitore Elisir", singleton.LivelloQuintoLivelloCapienzaContenitoreElisir},
                    {"Produzione Metallo", singleton.LivelloQuintoLivelloQuantitaProduzioneMetallo},
                    {"Contenitore Metallo", singleton.LivelloQuintoLivelloCapienzaProduzioneMetallo },
                    {"Produzione Munizioni", singleton.LivelloQuintoLivelloQuantitaProduzioneMunizioni},
                    {"Contenitore Munizioni", singleton.LivelloQuintoLivelloCapienzaContenitoreMunizioni},
                    {"Torretta", singleton.LivelloQuintoLivelloDannoMitraglietta},
                }
            },
            {"Comprato Arma" , new Dictionary<string, object>
                {
                    {"Arma 1", singleton.CompratoArma1},
                    {"Arma 2", singleton.CompratoArma2},
                    {"Arma 3", singleton.CompratoArma3},
                    {"Arma 4", singleton.CompratoArma4},
                    {"Arma 5", singleton.CompratoArma5 },
                }
            },
            {"Selezionata Arma" , new Dictionary<string, object>
                {
                    {"Arma 1", singleton.SelezionatoArma1},
                    {"Arma 2", singleton.SelezionatoArma2},
                    {"Arma 3", singleton.SelezionatoArma3},
                    {"Arma 4", singleton.SelezionatoArma4},
                    {"Arma 5", singleton.SelezionatoArma5},
                }
            },
            {"Comprato Eroe" , new Dictionary<string, object>
                {
                    {"Eroe 1", singleton.CompratoPersonaggio1},
                    {"Eroe 2", singleton.CompratoPersonaggio2},
                    {"Eroe 3", singleton.CompratoPersonaggio3},
                }
            },
            {"Selezionato Eroe" , new Dictionary<string, object>
                {
                    {"Eroe 1", singleton.SelezionatoPersonaggio1},
                    {"Eroe 2", singleton.SelezionatoPersonaggio2},
                    {"Eroe 3", singleton.SelezionatoPersonaggio3},
                }
            },
            //INSERISCO VALORI MENU
            {"Lingua" , singleton.Lingua },
            {"Musica" , singleton.Musica },
            {"Suono" , singleton.Suono },
            //INSERISCO ULTIMO ACCESSO
            {"Ultimo Accesso" , singleton.UltimoAccesso },
        };


        DocumentReference countRef = db.Collection("Idle-gioco").Document(singleton.Id);
        countRef.SetAsync(c).ContinueWithOnMainThread(task =>
        {
            Debug.Log("Inseriti i dati");
        });

    }


    


}
