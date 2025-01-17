using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Firestore;
using Firebase.Extensions;
using System;

public class ottenereDati : MonoBehaviour
{

    //database firestore
    private FirebaseFirestore db;
    private Dictionary<string, object> c;
    public caricamentoScena cS;
    public musicaScript musica;
    singleton singleton;


    // Start is called before the first frame update
    void Start()
    {
        singleton = singleton.Instance;

        //INSERITO DATI
        db = FirebaseFirestore.DefaultInstance;

    }

    public void richiestaDati(String id)
    {
        /*
        * SERVE PER CONTROLLARE SE UN UTENTE ESISTE
        * */

        CollectionReference usersRef = db.Collection("Idle-gioco");
        DocumentReference userDocRef = usersRef.Document(id);

        userDocRef.GetSnapshotAsync().ContinueWithOnMainThread(task =>
        {
            if (task.IsCompleted && !task.IsFaulted)
            {
                DocumentSnapshot snapshot = task.Result;

                if (snapshot.Exists)
                {
                    // Il documento esiste
                    Debug.Log("L'utente esiste.");

                    getDati(snapshot);
                }
                else
                {
                    // Il documento non esiste
                    Debug.Log("L'utente non esiste. Puoi crearlo se necessario.");
                    //salvare();

                    //CARICO LA LINGUA E POI SCENA TUTORIAL
                    musica.playMusica();
                    cS.LoadScene(1);
                }
            }
            else if (task.IsFaulted)
            {
                Debug.LogError("Errore durante il recupero del documento: " + task.Exception);
            }
        });

    }



    private void getDati(DocumentSnapshot snapshot)
    {
        // Ottieni i dati dallo snapshot
        Dictionary<string, object> dati = snapshot.ToDictionary();

        // Ora puoi accedere ai dati tramite le chiavi
        if (dati.ContainsKey("Monete"))
        {

            singleton.Moneta = Convert.ToSingle(dati["Monete"]);

            // Puoi fare qualcosa con il valore delle monete qui
        }
        if (dati.ContainsKey("Elisir"))
        {
            singleton.Elisir = Convert.ToSingle(dati["Elisir"]);
        }
        if (dati.ContainsKey("Metallo"))
        {
            singleton.Metallo = Convert.ToSingle(dati["Metallo"]);
        }
        if (dati.ContainsKey("Munizione"))
        {
            singleton.Munizione = Convert.ToSingle(dati["Munizione"]);
        }


        //MENU
        if (dati.ContainsKey("Lingua"))
        {
            singleton.Lingua = Convert.ToString(dati["Lingua"]);
        }
        if (dati.ContainsKey("Musica"))
        {
            //se c'è che la musica è un boolean (errore di programmazione iniziale)
            try
            {
                singleton.Musica = Convert.ToSingle(dati["Musica"]);
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        if (dati.ContainsKey("Suono"))
        {
            //se c'è che la musica è un boolean (errore di programmazione iniziale)
            try
            {
                    singleton.Suono = Convert.ToSingle(dati["Suono"]);
            }
            catch (Exception)
            {

                throw;
            }

            
        }


        //ora ai Dictionary annodati

        //COMPRATI


        if (dati.ContainsKey("Comprato Primo Livello Pulsanti"))
        {
            Dictionary<string, object> primoLivelloPulsanti = (Dictionary<string, object>)dati["Comprato Primo Livello Pulsanti"];

            if (primoLivelloPulsanti.ContainsKey("Nuovo Livello"))
            {
                singleton.CompratoPrimoLivelloNuovoLivello = Convert.ToBoolean(primoLivelloPulsanti["Nuovo Livello"]);
            }
            if (primoLivelloPulsanti.ContainsKey("Spawn"))
            {
                singleton.CompratoPrimoLivelloSpawn = Convert.ToBoolean(primoLivelloPulsanti["Spawn"]);
            }
            if (primoLivelloPulsanti.ContainsKey("Estrattore Elisir"))
            {
                singleton.CompratoPrimoLivelloEstrattoreElisir = Convert.ToBoolean(primoLivelloPulsanti["Estrattore Elisir"]);
            }

            if (primoLivelloPulsanti.ContainsKey("Contenitore Elisir"))
            {
                singleton.CompratoPrimoLivelloContenitoreElisir = Convert.ToBoolean(primoLivelloPulsanti["Contenitore Elisir"]);
            }
            if (primoLivelloPulsanti.ContainsKey("Produzione Metallo"))
            {
                singleton.CompratoPrimoLivelloProduzioneMetallo = Convert.ToBoolean(primoLivelloPulsanti["Produzione Metallo"]);
            }
            if (primoLivelloPulsanti.ContainsKey("Contenitore Metallo"))
            {
                singleton.CompratoPrimoLivelloContenitoreMetallo = Convert.ToBoolean(primoLivelloPulsanti["Contenitore Metallo"]);
            }
            if (primoLivelloPulsanti.ContainsKey("Produzione Munizioni"))
            {
                singleton.CompratoPrimoLivelloProduzioneMunizioni = Convert.ToBoolean(primoLivelloPulsanti["Produzione Munizioni"]);
            }
            if (primoLivelloPulsanti.ContainsKey("Contenitore Munizioni"))
            {
                singleton.CompratoPrimoLivelloContenitoreMunizioni = Convert.ToBoolean(primoLivelloPulsanti["Contenitore Munizioni"]);
            }

        }

        if (dati.ContainsKey("Comprato Secondo Livello Pulsanti"))
        {
            Dictionary<string, object> secondoLivelloPulsanti = (Dictionary<string, object>)dati["Comprato Secondo Livello Pulsanti"];

            if (secondoLivelloPulsanti.ContainsKey("Nuovo Livello"))
            {
                singleton.CompratoSecondoLivelloNuovoLivello = Convert.ToBoolean(secondoLivelloPulsanti["Nuovo Livello"]);
            }
            if (secondoLivelloPulsanti.ContainsKey("Spawn"))
            {
                singleton.CompratoSecondoLivelloSpawn = Convert.ToBoolean(secondoLivelloPulsanti["Spawn"]);
            }
            if (secondoLivelloPulsanti.ContainsKey("Estrattore Elisir"))
            {
                singleton.CompratoSecondoLivelloEstrattoreElisir = Convert.ToBoolean(secondoLivelloPulsanti["Estrattore Elisir"]);
            }
            if (secondoLivelloPulsanti.ContainsKey("Contenitore Elisir"))
            {
                singleton.CompratoSecondoLivelloContenitoreElisir = Convert.ToBoolean(secondoLivelloPulsanti["Contenitore Elisir"]);
            }
            if (secondoLivelloPulsanti.ContainsKey("Produzione Metallo"))
            {
                singleton.CompratoSecondoLivelloProduzioneMetallo = Convert.ToBoolean(secondoLivelloPulsanti["Produzione Metallo"]);
            }
            if (secondoLivelloPulsanti.ContainsKey("Contenitore Metallo"))
            {
                singleton.CompratoSecondoLivelloContenitoreMetallo = Convert.ToBoolean(secondoLivelloPulsanti["Contenitore Metallo"]);
            }
            if (secondoLivelloPulsanti.ContainsKey("Produzione Munizioni"))
            {
                singleton.CompratoSecondoLivelloProduzioneMunizioni = Convert.ToBoolean(secondoLivelloPulsanti["Produzione Munizioni"]);
            }
            if (secondoLivelloPulsanti.ContainsKey("Contenitore Munizioni"))
            {
                singleton.CompratoSecondoLivelloContenitoreMunizioni = Convert.ToBoolean(secondoLivelloPulsanti["Contenitore Munizioni"]);
            }
            if (secondoLivelloPulsanti.ContainsKey("Torretta"))
            {
                singleton.CompratoSecondoLivelloTorretta = Convert.ToBoolean(secondoLivelloPulsanti["Torretta"]);
            }
        }

        if (dati.ContainsKey("Comprato Terzo Livello Pulsanti"))
        {
            Dictionary<string, object> terzoLivelloPulsanti = (Dictionary<string, object>)dati["Comprato Terzo Livello Pulsanti"];

            if (terzoLivelloPulsanti.ContainsKey("Nuovo Livello"))
            {
                singleton.CompratoTerzoLivelloNuovoLivello = Convert.ToBoolean(terzoLivelloPulsanti["Nuovo Livello"]);
            }
            if (terzoLivelloPulsanti.ContainsKey("Spawn"))
            {
                singleton.CompratoTerzoLivelloSpawn = Convert.ToBoolean(terzoLivelloPulsanti["Spawn"]);
            }
            if (terzoLivelloPulsanti.ContainsKey("Estrattore Elisir"))
            {
                singleton.CompratoTerzoLivelloEstrattoreElisir = Convert.ToBoolean(terzoLivelloPulsanti["Estrattore Elisir"]);
            }
            if (terzoLivelloPulsanti.ContainsKey("Contenitore Elisir"))
            {
                singleton.CompratoTerzoLivelloContenitoreElisir = Convert.ToBoolean(terzoLivelloPulsanti["Contenitore Elisir"]);
            }
            if (terzoLivelloPulsanti.ContainsKey("Produzione Metallo"))
            {
                singleton.CompratoTerzoLivelloProduzioneMetallo = Convert.ToBoolean(terzoLivelloPulsanti["Produzione Metallo"]);
            }
            if (terzoLivelloPulsanti.ContainsKey("Contenitore Metallo"))
            {
                singleton.CompratoTerzoLivelloContenitoreMetallo = Convert.ToBoolean(terzoLivelloPulsanti["Contenitore Metallo"]);
            }
            if (terzoLivelloPulsanti.ContainsKey("Produzione Munizioni"))
            {
                singleton.CompratoTerzoLivelloProduzioneMunizioni = Convert.ToBoolean(terzoLivelloPulsanti["Produzione Munizioni"]);
            }
            if (terzoLivelloPulsanti.ContainsKey("Contenitore Munizioni"))
            {
                singleton.CompratoTerzoLivelloContenitoreMunizioni = Convert.ToBoolean(terzoLivelloPulsanti["Contenitore Munizioni"]);
            }
            if (terzoLivelloPulsanti.ContainsKey("Torretta"))
            {
                singleton.CompratoTerzoLivelloTorretta = Convert.ToBoolean(terzoLivelloPulsanti["Torretta"]);
            }
        }

        if (dati.ContainsKey("Comprato Quarto Livello Pulsanti"))
        {
            Dictionary<string, object> quartoLivelloPulsanti = (Dictionary<string, object>)dati["Comprato Quarto Livello Pulsanti"];

            if (quartoLivelloPulsanti.ContainsKey("Nuovo Livello"))
            {
                singleton.CompratoQuartoLivelloNuovoLivello = Convert.ToBoolean(quartoLivelloPulsanti["Nuovo Livello"]);
            }
            if (quartoLivelloPulsanti.ContainsKey("Spawn"))
            {
                singleton.CompratoQuartoLivelloSpawn = Convert.ToBoolean(quartoLivelloPulsanti["Spawn"]);
            }
            if (quartoLivelloPulsanti.ContainsKey("Estrattore Elisir"))
            {
                singleton.CompratoQuartoLivelloEstrattoreElisir = Convert.ToBoolean(quartoLivelloPulsanti["Estrattore Elisir"]);
            }
            if (quartoLivelloPulsanti.ContainsKey("Contenitore Elisir"))
            {
                singleton.CompratoQuartoLivelloContenitoreElisir = Convert.ToBoolean(quartoLivelloPulsanti["Contenitore Elisir"]);
            }
            if (quartoLivelloPulsanti.ContainsKey("Produzione Metallo"))
            {
                singleton.CompratoQuartoLivelloProduzioneMetallo = Convert.ToBoolean(quartoLivelloPulsanti["Produzione Metallo"]);
            }
            if (quartoLivelloPulsanti.ContainsKey("Contenitore Metallo"))
            {
                singleton.CompratoQuartoLivelloContenitoreMetallo = Convert.ToBoolean(quartoLivelloPulsanti["Contenitore Metallo"]);
            }
            if (quartoLivelloPulsanti.ContainsKey("Produzione Munizioni"))
            {
                singleton.CompratoQuartoLivelloProduzioneMunizioni = Convert.ToBoolean(quartoLivelloPulsanti["Produzione Munizioni"]);
            }
            if (quartoLivelloPulsanti.ContainsKey("Contenitore Munizioni"))
            {
                singleton.CompratoQuartoLivelloContenitoreMunizioni = Convert.ToBoolean(quartoLivelloPulsanti["Contenitore Munizioni"]);
            }
            if (quartoLivelloPulsanti.ContainsKey("Torretta"))
            {
                singleton.CompratoQuartoLivelloTorretta = Convert.ToBoolean(quartoLivelloPulsanti["Torretta"]);
            }
        }

        if (dati.ContainsKey("Comprato Quinto Livello Pulsanti"))
        {
            Dictionary<string, object> quintoLivelloPulsanti = (Dictionary<string, object>)dati["Comprato Quinto Livello Pulsanti"];

            if (quintoLivelloPulsanti.ContainsKey("Spawn"))
            {
                singleton.CompratoQuintoLivelloSpawn = Convert.ToBoolean(quintoLivelloPulsanti["Spawn"]);
            }
            if (quintoLivelloPulsanti.ContainsKey("Estrattore Elisir"))
            {
                singleton.CompratoQuintoLivelloEstrattoreElisir = Convert.ToBoolean(quintoLivelloPulsanti["Estrattore Elisir"]);
            }
            if (quintoLivelloPulsanti.ContainsKey("Contenitore Elisir"))
            {
                singleton.CompratoQuintoLivelloContenitoreElisir = Convert.ToBoolean(quintoLivelloPulsanti["Contenitore Elisir"]);
            }
            if (quintoLivelloPulsanti.ContainsKey("Produzione Metallo"))
            {
                singleton.CompratoQuintoLivelloProduzioneMetallo = Convert.ToBoolean(quintoLivelloPulsanti["Produzione Metallo"]);
            }
            if (quintoLivelloPulsanti.ContainsKey("Contenitore Metallo"))
            {
                singleton.CompratoQuintoLivelloContenitoreMetallo = Convert.ToBoolean(quintoLivelloPulsanti["Contenitore Metallo"]);
            }
            if (quintoLivelloPulsanti.ContainsKey("Produzione Munizioni"))
            {
                singleton.CompratoQuintoLivelloProduzioneMunizioni = Convert.ToBoolean(quintoLivelloPulsanti["Produzione Munizioni"]);
            }
            if (quintoLivelloPulsanti.ContainsKey("Contenitore Munizioni"))
            {
                singleton.CompratoQuintoLivelloContenitoreMunizioni = Convert.ToBoolean(quintoLivelloPulsanti["Contenitore Munizioni"]);
            }
            if (quintoLivelloPulsanti.ContainsKey("Torretta"))
            {
                singleton.CompratoQuintoLivelloTorretta = Convert.ToBoolean(quintoLivelloPulsanti["Torretta"]);
            }
        }

        //LIVELLI
        if (dati.ContainsKey("Livelli Primo Livello"))
        {
            Dictionary<string, object> livelliPrimoLivello = (Dictionary<string, object>)dati["Livelli Primo Livello"];

            if (livelliPrimoLivello.ContainsKey("Spawn"))
            {
                singleton.LivelloPrimoLivelloVelocitaSpawn = Convert.ToInt32(livelliPrimoLivello["Spawn"]);
            }
            if (livelliPrimoLivello.ContainsKey("Estrattore Elisir"))
            {
                singleton.LivelloPrimoLivelloQuantitaEstrattoreElisir = Convert.ToInt32(livelliPrimoLivello["Estrattore Elisir"]);
            }
            if (livelliPrimoLivello.ContainsKey("Contenitore Elisir"))
            {
                singleton.LivelloPrimoLivelloCapienzaContenitoreElisir = Convert.ToInt32(livelliPrimoLivello["Contenitore Elisir"]);
            }
            if (livelliPrimoLivello.ContainsKey("Produzione Metallo"))
            {
                singleton.LivelloPrimoLivelloQuantitaProduzioneMetallo = Convert.ToInt32(livelliPrimoLivello["Produzione Metallo"]);
            }
            if (livelliPrimoLivello.ContainsKey("Contenitore Metallo"))
            {
                singleton.LivelloPrimoLivelloCapienzaProduzioneMetallo = Convert.ToInt32(livelliPrimoLivello["Contenitore Metallo"]);
            }
            if (livelliPrimoLivello.ContainsKey("Produzione Munizioni"))
            {
                singleton.LivelloPrimoLivelloQuantitaProduzioneMunizioni = Convert.ToInt32(livelliPrimoLivello["Produzione Munizioni"]);
            }
            if (livelliPrimoLivello.ContainsKey("Contenitore Munizioni"))
            {
                singleton.LivelloPrimoLivelloCapienzaContenitoreMunizioni = Convert.ToInt32(livelliPrimoLivello["Contenitore Munizioni"]);
            }
        }

        if (dati.ContainsKey("Livelli Secondo Livello"))
        {
            Dictionary<string, object> livelliSecondoLivello = (Dictionary<string, object>)dati["Livelli Secondo Livello"];

            if (livelliSecondoLivello.ContainsKey("Spawn"))
            {
                singleton.LivelloSecondoLivelloVelocitaSpawn = Convert.ToInt32(livelliSecondoLivello["Spawn"]);
            }
            if (livelliSecondoLivello.ContainsKey("Estrattore Elisir"))
            {
                singleton.LivelloSecondoLivelloQuantitaEstrattoreElisir = Convert.ToInt32(livelliSecondoLivello["Estrattore Elisir"]);
            }
            if (livelliSecondoLivello.ContainsKey("Contenitore Elisir"))
            {
                singleton.LivelloSecondoLivelloCapienzaContenitoreElisir = Convert.ToInt32(livelliSecondoLivello["Contenitore Elisir"]);
            }
            if (livelliSecondoLivello.ContainsKey("Produzione Metallo"))
            {
                singleton.LivelloSecondoLivelloQuantitaProduzioneMetallo = Convert.ToInt32(livelliSecondoLivello["Produzione Metallo"]);
            }
            if (livelliSecondoLivello.ContainsKey("Contenitore Metallo"))
            {
                singleton.LivelloSecondoLivelloCapienzaProduzioneMetallo = Convert.ToInt32(livelliSecondoLivello["Contenitore Metallo"]);
            }
            if (livelliSecondoLivello.ContainsKey("Produzione Munizioni"))
            {
                singleton.LivelloSecondoLivelloQuantitaProduzioneMunizioni = Convert.ToInt32(livelliSecondoLivello["Produzione Munizioni"]);
            }
            if (livelliSecondoLivello.ContainsKey("Contenitore Munizioni"))
            {
                singleton.LivelloSecondoLivelloCapienzaContenitoreMunizioni = Convert.ToInt32(livelliSecondoLivello["Contenitore Munizioni"]);
            }
            if (livelliSecondoLivello.ContainsKey("Torretta"))
            {
                singleton.LivelloSecondoLivelloDannoMitraglietta = Convert.ToInt32(livelliSecondoLivello["Torretta"]);
            }
        }

        if (dati.ContainsKey("Livelli Terzo Livello"))
        {
            Dictionary<string, object> livelliTerzoLivello = (Dictionary<string, object>)dati["Livelli Terzo Livello"];

            if (livelliTerzoLivello.ContainsKey("Spawn"))
            {
                singleton.LivelloTerzoLivelloVelocitaSpawn = Convert.ToInt32(livelliTerzoLivello["Spawn"]);
            }
            if (livelliTerzoLivello.ContainsKey("Estrattore Elisir"))
            {
                singleton.LivelloTerzoLivelloQuantitaEstrattoreElisir = Convert.ToInt32(livelliTerzoLivello["Estrattore Elisir"]);
            }
            if (livelliTerzoLivello.ContainsKey("Contenitore Elisir"))
            {
                singleton.LivelloTerzoLivelloCapienzaContenitoreElisir = Convert.ToInt32(livelliTerzoLivello["Contenitore Elisir"]);
            }
            if (livelliTerzoLivello.ContainsKey("Produzione Metallo"))
            {
                singleton.LivelloTerzoLivelloQuantitaProduzioneMetallo = Convert.ToInt32(livelliTerzoLivello["Produzione Metallo"]);
            }
            if (livelliTerzoLivello.ContainsKey("Contenitore Metallo"))
            {
                singleton.LivelloTerzoLivelloCapienzaProduzioneMetallo = Convert.ToInt32(livelliTerzoLivello["Contenitore Metallo"]);
            }
            if (livelliTerzoLivello.ContainsKey("Produzione Munizioni"))
            {
                singleton.LivelloTerzoLivelloQuantitaProduzioneMunizioni = Convert.ToInt32(livelliTerzoLivello["Produzione Munizioni"]);
            }
            if (livelliTerzoLivello.ContainsKey("Contenitore Munizioni"))
            {
                singleton.LivelloTerzoLivelloCapienzaContenitoreMunizioni = Convert.ToInt32(livelliTerzoLivello["Contenitore Munizioni"]);
            }
            if (livelliTerzoLivello.ContainsKey("Torretta"))
            {
                singleton.LivelloTerzoLivelloDannoMitraglietta = Convert.ToInt32(livelliTerzoLivello["Torretta"]);
            }
        }

        if (dati.ContainsKey("Livelli Quarto Livello"))
        {
            Dictionary<string, object> livelliQuartoLivello = (Dictionary<string, object>)dati["Livelli Quarto Livello"];

            if (livelliQuartoLivello.ContainsKey("Spawn"))
            {
                singleton.LivelloQuartoLivelloVelocitaSpawn = Convert.ToInt32(livelliQuartoLivello["Spawn"]);
            }
            if (livelliQuartoLivello.ContainsKey("Estrattore Elisir"))
            {
                singleton.LivelloQuartoLivelloQuantitaEstrattoreElisir = Convert.ToInt32(livelliQuartoLivello["Estrattore Elisir"]);
            }
            if (livelliQuartoLivello.ContainsKey("Contenitore Elisir"))
            {
                singleton.LivelloQuartoLivelloCapienzaContenitoreElisir = Convert.ToInt32(livelliQuartoLivello["Contenitore Elisir"]);
            }
            if (livelliQuartoLivello.ContainsKey("Produzione Metallo"))
            {
                singleton.LivelloQuartoLivelloQuantitaProduzioneMetallo = Convert.ToInt32(livelliQuartoLivello["Produzione Metallo"]);
            }
            if (livelliQuartoLivello.ContainsKey("Contenitore Metallo"))
            {
                singleton.LivelloQuartoLivelloCapienzaProduzioneMetallo = Convert.ToInt32(livelliQuartoLivello["Contenitore Metallo"]);
            }
            if (livelliQuartoLivello.ContainsKey("Produzione Munizioni"))
            {
                singleton.LivelloQuartoLivelloQuantitaProduzioneMunizioni = Convert.ToInt32(livelliQuartoLivello["Produzione Munizioni"]);
            }
            if (livelliQuartoLivello.ContainsKey("Contenitore Munizioni"))
            {
                singleton.LivelloQuartoLivelloCapienzaContenitoreMunizioni = Convert.ToInt32(livelliQuartoLivello["Contenitore Munizioni"]);
            }
            if (livelliQuartoLivello.ContainsKey("Torretta"))
            {
                singleton.LivelloQuartoLivelloDannoMitraglietta = Convert.ToInt32(livelliQuartoLivello["Torretta"]);
            }
        }

        if (dati.ContainsKey("Livelli Quinto Livello"))
        {
            Dictionary<string, object> livelliQuintoLivello = (Dictionary<string, object>)dati["Livelli Quinto Livello"];

            if (livelliQuintoLivello.ContainsKey("Spawn"))
            {
                singleton.LivelloQuintoLivelloVelocitaSpawn = Convert.ToInt32(livelliQuintoLivello["Spawn"]);
            }
            if (livelliQuintoLivello.ContainsKey("Estrattore Elisir"))
            {
                singleton.LivelloQuintoLivelloQuantitaEstrattoreElisir = Convert.ToInt32(livelliQuintoLivello["Estrattore Elisir"]);
            }
            if (livelliQuintoLivello.ContainsKey("Contenitore Elisir"))
            {
                singleton.LivelloQuintoLivelloCapienzaContenitoreElisir = Convert.ToInt32(livelliQuintoLivello["Contenitore Elisir"]);
            }
            if (livelliQuintoLivello.ContainsKey("Produzione Metallo"))
            {
                singleton.LivelloQuintoLivelloQuantitaProduzioneMetallo = Convert.ToInt32(livelliQuintoLivello["Produzione Metallo"]);
            }
            if (livelliQuintoLivello.ContainsKey("Contenitore Metallo"))
            {
                singleton.LivelloQuintoLivelloCapienzaProduzioneMetallo = Convert.ToInt32(livelliQuintoLivello["Contenitore Metallo"]);
            }
            if (livelliQuintoLivello.ContainsKey("Produzione Munizioni"))
            {
                singleton.LivelloQuintoLivelloQuantitaProduzioneMunizioni = Convert.ToInt32(livelliQuintoLivello["Produzione Munizioni"]);
            }
            if (livelliQuintoLivello.ContainsKey("Contenitore Munizioni"))
            {
                singleton.LivelloQuintoLivelloCapienzaContenitoreMunizioni = Convert.ToInt32(livelliQuintoLivello["Contenitore Munizioni"]);
            }
            if (livelliQuintoLivello.ContainsKey("Torretta"))
            {
                singleton.LivelloQuintoLivelloDannoMitraglietta = Convert.ToInt32(livelliQuintoLivello["Torretta"]);
            }
        }


        //COMPRATO ARMI
        if (dati.ContainsKey("Comprato Arma"))
        {
            Dictionary<string, object> compratoArma = (Dictionary<string, object>)dati["Comprato Arma"];

            if (compratoArma.ContainsKey("Arma 1"))
            {
                singleton.CompratoArma1 = Convert.ToBoolean(compratoArma["Arma 1"]);
            }

            if (compratoArma.ContainsKey("Arma 2"))
            {
                singleton.CompratoArma2 = Convert.ToBoolean(compratoArma["Arma 2"]);
            }

            if (compratoArma.ContainsKey("Arma 3"))
            {
                singleton.CompratoArma3 = Convert.ToBoolean(compratoArma["Arma 3"]);
            }

            if (compratoArma.ContainsKey("Arma 4"))
            {
                singleton.CompratoArma4 = Convert.ToBoolean(compratoArma["Arma 4"]);
            }

            if (compratoArma.ContainsKey("Arma 5"))
            {
                singleton.CompratoArma5 = Convert.ToBoolean(compratoArma["Arma 5"]);
            }
        }

        //SELEZIONATO ARMI
        if (dati.ContainsKey("Selezionata Arma"))
        {
            Dictionary<string, object> selezionatoArma = (Dictionary<string, object>)dati["Selezionata Arma"];

            if (selezionatoArma.ContainsKey("Arma 1"))
            {
                singleton.SelezionatoArma1 = Convert.ToBoolean(selezionatoArma["Arma 1"]);
            }

            if (selezionatoArma.ContainsKey("Arma 2"))
            {
                singleton.SelezionatoArma2 = Convert.ToBoolean(selezionatoArma["Arma 2"]);
            }

            if (selezionatoArma.ContainsKey("Arma 3"))
            {
                singleton.SelezionatoArma3 = Convert.ToBoolean(selezionatoArma["Arma 3"]);
            }

            if (selezionatoArma.ContainsKey("Arma 4"))
            {
                singleton.SelezionatoArma4 = Convert.ToBoolean(selezionatoArma["Arma 4"]);
            }

            if (selezionatoArma.ContainsKey("Arma 5"))
            {
                singleton.SelezionatoArma5 = Convert.ToBoolean(selezionatoArma["Arma 5"]);
            }
        }

        //COMPRATO EROE
        if (dati.ContainsKey("Comprato Eroe"))
        {
            Dictionary<string, object> compratoEroe = (Dictionary<string, object>)dati["Comprato Eroe"];

            if (compratoEroe.ContainsKey("Eroe 1"))
            {
                singleton.CompratoPersonaggio1 = Convert.ToBoolean(compratoEroe["Eroe 1"]);
            }

            if (compratoEroe.ContainsKey("Eroe 2"))
            {
                singleton.CompratoPersonaggio2 = Convert.ToBoolean(compratoEroe["Eroe 2"]);
            }

            if (compratoEroe.ContainsKey("Eroe 3"))
            {
                singleton.CompratoPersonaggio3 = Convert.ToBoolean(compratoEroe["Eroe 3"]);
            }

        }

        //SELEZIONATO EROE
        if (dati.ContainsKey("Selezionato Eroe"))
        {
            Dictionary<string, object> selezionatoEroe = (Dictionary<string, object>)dati["Selezionato Eroe"];

            if (selezionatoEroe.ContainsKey("Eroe 1"))
            {
                singleton.SelezionatoPersonaggio1 = Convert.ToBoolean(selezionatoEroe["Eroe 1"]);
            }

            if (selezionatoEroe.ContainsKey("Eroe 2"))
            {
                singleton.SelezionatoPersonaggio2 = Convert.ToBoolean(selezionatoEroe["Eroe 2"]);
            }

            if (selezionatoEroe.ContainsKey("Eroe 3"))
            {
                singleton.SelezionatoPersonaggio3 = Convert.ToBoolean(selezionatoEroe["Eroe 3"]);
            }

        }

        if (dati.ContainsKey("Ultimo Accesso"))
        {
            //se c'è che la musica è un boolean (errore di programmazione iniziale)
            try
            {
                singleton.UltimoAccesso =Convert.ToString(dati["Ultimo Accesso"]);
            }
            catch (Exception)
            {

                throw;
            }

        }


        //CARICO LA SCENA
        //singleton.Salvare = true;
        musica.playMusica();
        cS.LoadScene(3);


    }


}
