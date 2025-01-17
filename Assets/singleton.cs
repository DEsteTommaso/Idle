using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class singleton : MonoBehaviour
{
    // Dichiarazione della variabile statica che conterrà l'istanza unica
    private static singleton _instance;


    // Proprietà per accedere all'istanza
    public static singleton Instance
    {
        get
        {
            // Se l'istanza non esiste, la crea
            if (_instance == null)
            {
                _instance = FindObjectOfType<singleton>();

                // Se non esiste ancora un'istanza nella scena, creane una
                if (_instance == null)
                {
                    GameObject singletonObject = new GameObject(typeof(singleton).Name);
                    _instance = singletonObject.AddComponent<singleton>();
                    DontDestroyOnLoad(_instance);
                }
            }
            return _instance;
        }
    }


    private singleton()
    {

    }


    private void Start()
    {

    }

    private float moneta = 0;
    private float elisir = 0;
    private float metallo = 0;
    private float munizione = 0;

    //Pulsanti comprati

    #region comprati oggetti livello
    //indica se è stato comprato il livello successivo
    private bool compratoPrimoLivelloNuovoLivello = false;

    private bool compratoPrimoLivelloSpawn = false;
    private bool compratoPrimoLivelloEstrattoreElisir = false;
    private bool compratoPrimoLivelloContenitoreElisir = false;
    private bool compratoPrimoLivelloProduzioneMetallo = false;
    private bool compratoPrimoLivelloContenitoreMetallo = false;
    private bool compratoPrimoLivelloProduzioneMunizioni = false;
    private bool compratoPrimoLivelloContenitoreMunizioni = false;
    
    private bool compratoSecondoLivelloNuovoLivello = false;
    private bool compratoSecondoLivelloSpawn = false;
    private bool compratoSecondoLivelloEstrattoreElisir = false;
    private bool compratoSecondoLivelloContenitoreElisir = false;
    private bool compratoSecondoLivelloProduzioneMetallo = false;
    private bool compratoSecondoLivelloContenitoreMetallo = false;
    private bool compratoSecondoLivelloProduzioneMunizioni = false;
    private bool compratoSecondoLivelloContenitoreMunizioni = false;
    private bool compratoSecondoLivelloTorretta = false;

    private bool compratoTerzoLivelloNuovoLivello = false;
    private bool compratoTerzoLivelloSpawn = false;
    private bool compratoTerzoLivelloEstrattoreElisir = false;
    private bool compratoTerzoLivelloContenitoreElisir = false;
    private bool compratoTerzoLivelloProduzioneMetallo = false;
    private bool compratoTerzoLivelloContenitoreMetallo = false;
    private bool compratoTerzoLivelloProduzioneMunizioni = false;
    private bool compratoTerzoLivelloContenitoreMunizioni = false;
    private bool compratoTerzoLivelloTorretta = false;

    private bool compratoQuartoLivelloNuovoLivello = false;
    private bool compratoQuartoLivelloSpawn = false;
    private bool compratoQuartoLivelloEstrattoreElisir = false;
    private bool compratoQuartoLivelloContenitoreElisir = false;
    private bool compratoQuartoLivelloProduzioneMetallo = false;
    private bool compratoQuartoLivelloContenitoreMetallo = false;
    private bool compratoQuartoLivelloProduzioneMunizioni = false;
    private bool compratoQuartoLivelloContenitoreMunizioni = false;
    private bool compratoQuartoLivelloTorretta = false;

    private bool compratoQuintoLivelloSpawn = false;
    private bool compratoQuintoLivelloEstrattoreElisir = false;
    private bool compratoQuintoLivelloContenitoreElisir = false;
    private bool compratoQuintoLivelloProduzioneMetallo = false;
    private bool compratoQuintoLivelloContenitoreMetallo = false;
    private bool compratoQuintoLivelloProduzioneMunizioni = false;
    private bool compratoQuintoLivelloContenitoreMunizioni = false;
    private bool compratoQuintoLivelloTorretta = false;
   
    public bool CompratoPrimoLivelloNuovoLivello { get => compratoPrimoLivelloNuovoLivello; set => compratoPrimoLivelloNuovoLivello = value; }
    public bool CompratoPrimoLivelloSpawn { get => compratoPrimoLivelloSpawn; set => compratoPrimoLivelloSpawn = value; }
    public bool CompratoPrimoLivelloEstrattoreElisir { get => compratoPrimoLivelloEstrattoreElisir; set => compratoPrimoLivelloEstrattoreElisir = value; }
    public bool CompratoPrimoLivelloContenitoreElisir { get => compratoPrimoLivelloContenitoreElisir; set => compratoPrimoLivelloContenitoreElisir = value; }
    public bool CompratoPrimoLivelloProduzioneMetallo { get => compratoPrimoLivelloProduzioneMetallo; set => compratoPrimoLivelloProduzioneMetallo = value; }
    public bool CompratoPrimoLivelloContenitoreMetallo { get => compratoPrimoLivelloContenitoreMetallo; set => compratoPrimoLivelloContenitoreMetallo = value; }
    public bool CompratoPrimoLivelloProduzioneMunizioni { get => compratoPrimoLivelloProduzioneMunizioni; set => compratoPrimoLivelloProduzioneMunizioni = value; }
    public bool CompratoPrimoLivelloContenitoreMunizioni { get => compratoPrimoLivelloContenitoreMunizioni; set => compratoPrimoLivelloContenitoreMunizioni = value; }
    public bool CompratoSecondoLivelloNuovoLivello { get => compratoSecondoLivelloNuovoLivello; set => compratoSecondoLivelloNuovoLivello = value; }
    public bool CompratoSecondoLivelloSpawn { get => compratoSecondoLivelloSpawn; set => compratoSecondoLivelloSpawn = value; }
    public bool CompratoSecondoLivelloEstrattoreElisir { get => compratoSecondoLivelloEstrattoreElisir; set => compratoSecondoLivelloEstrattoreElisir = value; }
    public bool CompratoSecondoLivelloContenitoreElisir { get => compratoSecondoLivelloContenitoreElisir; set => compratoSecondoLivelloContenitoreElisir = value; }
    public bool CompratoSecondoLivelloProduzioneMetallo { get => compratoSecondoLivelloProduzioneMetallo; set => compratoSecondoLivelloProduzioneMetallo = value; }
    public bool CompratoSecondoLivelloContenitoreMetallo { get => compratoSecondoLivelloContenitoreMetallo; set => compratoSecondoLivelloContenitoreMetallo = value; }
    public bool CompratoSecondoLivelloProduzioneMunizioni { get => compratoSecondoLivelloProduzioneMunizioni; set => compratoSecondoLivelloProduzioneMunizioni = value; }
    public bool CompratoSecondoLivelloContenitoreMunizioni { get => compratoSecondoLivelloContenitoreMunizioni; set => compratoSecondoLivelloContenitoreMunizioni = value; }
    public bool CompratoSecondoLivelloTorretta { get => compratoSecondoLivelloTorretta; set => compratoSecondoLivelloTorretta = value; }
    public bool CompratoTerzoLivelloNuovoLivello { get => compratoTerzoLivelloNuovoLivello; set => compratoTerzoLivelloNuovoLivello = value; }
    public bool CompratoTerzoLivelloSpawn { get => compratoTerzoLivelloSpawn; set => compratoTerzoLivelloSpawn = value; }
    public bool CompratoTerzoLivelloEstrattoreElisir { get => compratoTerzoLivelloEstrattoreElisir; set => compratoTerzoLivelloEstrattoreElisir = value; }
    public bool CompratoTerzoLivelloContenitoreElisir { get => compratoTerzoLivelloContenitoreElisir; set => compratoTerzoLivelloContenitoreElisir = value; }
    public bool CompratoTerzoLivelloProduzioneMetallo { get => compratoTerzoLivelloProduzioneMetallo; set => compratoTerzoLivelloProduzioneMetallo = value; }
    public bool CompratoTerzoLivelloContenitoreMetallo { get => compratoTerzoLivelloContenitoreMetallo; set => compratoTerzoLivelloContenitoreMetallo = value; }
    public bool CompratoTerzoLivelloProduzioneMunizioni { get => compratoTerzoLivelloProduzioneMunizioni; set => compratoTerzoLivelloProduzioneMunizioni = value; }
    public bool CompratoTerzoLivelloContenitoreMunizioni { get => compratoTerzoLivelloContenitoreMunizioni; set => compratoTerzoLivelloContenitoreMunizioni = value; }
    public bool CompratoTerzoLivelloTorretta { get => compratoTerzoLivelloTorretta; set => compratoTerzoLivelloTorretta = value; }
    public bool CompratoQuartoLivelloNuovoLivello { get => compratoQuartoLivelloNuovoLivello; set => compratoQuartoLivelloNuovoLivello = value; }
    public bool CompratoQuartoLivelloSpawn { get => compratoQuartoLivelloSpawn; set => compratoQuartoLivelloSpawn = value; }
    public bool CompratoQuartoLivelloEstrattoreElisir { get => compratoQuartoLivelloEstrattoreElisir; set => compratoQuartoLivelloEstrattoreElisir = value; }
    public bool CompratoQuartoLivelloContenitoreElisir { get => compratoQuartoLivelloContenitoreElisir; set => compratoQuartoLivelloContenitoreElisir = value; }
    public bool CompratoQuartoLivelloProduzioneMetallo { get => compratoQuartoLivelloProduzioneMetallo; set => compratoQuartoLivelloProduzioneMetallo = value; }
    public bool CompratoQuartoLivelloContenitoreMetallo { get => compratoQuartoLivelloContenitoreMetallo; set => compratoQuartoLivelloContenitoreMetallo = value; }
    public bool CompratoQuartoLivelloProduzioneMunizioni { get => compratoQuartoLivelloProduzioneMunizioni; set => compratoQuartoLivelloProduzioneMunizioni = value; }
    public bool CompratoQuartoLivelloContenitoreMunizioni { get => compratoQuartoLivelloContenitoreMunizioni; set => compratoQuartoLivelloContenitoreMunizioni = value; }
    public bool CompratoQuartoLivelloTorretta { get => compratoQuartoLivelloTorretta; set => compratoQuartoLivelloTorretta = value; }
    public bool CompratoQuintoLivelloSpawn { get => compratoQuintoLivelloSpawn; set => compratoQuintoLivelloSpawn = value; }
    public bool CompratoQuintoLivelloEstrattoreElisir { get => compratoQuintoLivelloEstrattoreElisir; set => compratoQuintoLivelloEstrattoreElisir = value; }
    public bool CompratoQuintoLivelloContenitoreElisir { get => compratoQuintoLivelloContenitoreElisir; set => compratoQuintoLivelloContenitoreElisir = value; }
    public bool CompratoQuintoLivelloProduzioneMetallo { get => compratoQuintoLivelloProduzioneMetallo; set => compratoQuintoLivelloProduzioneMetallo = value; }
    public bool CompratoQuintoLivelloContenitoreMetallo { get => compratoQuintoLivelloContenitoreMetallo; set => compratoQuintoLivelloContenitoreMetallo = value; }
    public bool CompratoQuintoLivelloProduzioneMunizioni { get => compratoQuintoLivelloProduzioneMunizioni; set => compratoQuintoLivelloProduzioneMunizioni = value; }
    public bool CompratoQuintoLivelloContenitoreMunizioni { get => compratoQuintoLivelloContenitoreMunizioni; set => compratoQuintoLivelloContenitoreMunizioni = value; }
    public bool CompratoQuintoLivelloTorretta { get => compratoQuintoLivelloTorretta; set => compratoQuintoLivelloTorretta = value; }

    //fine pulsantiComprati
    #endregion

    #region livello oggetti
    //LIVELLO OGGETTI
    private int livelloPrimoLivelloVelocitaSpawn = 1;
    private int livelloPrimoLivelloQuantitaEstrattoreElisir = 1;
    private int livelloPrimoLivelloCapienzaContenitoreElisir = 1;
    private int livelloPrimoLivelloQuantitaProduzioneMetallo = 1;
    private int livelloPrimoLivelloCapienzaProduzioneMetallo = 1;
    private int livelloPrimoLivelloQuantitaProduzioneMunizioni = 1;
    private int livelloPrimoLivelloCapienzaContenitoreMunizioni = 1;

    private int livelloSecondoLivelloVelocitaSpawn = 1;
    private int livelloSecondoLivelloDannoMitraglietta = 1;
    private int livelloSecondoLivelloQuantitaEstrattoreElisir = 1;
    private int livelloSecondoLivelloCapienzaContenitoreElisir = 1;
    private int livelloSecondoLivelloQuantitaProduzioneMetallo = 1;
    private int livelloSecondoLivelloCapienzaProduzioneMetallo = 1;
    private int livelloSecondoLivelloQuantitaProduzioneMunizioni = 1;
    private int livelloSecondoLivelloCapienzaContenitoreMunizioni = 1;

    private int livelloTerzoLivelloVelocitaSpawn = 1;
    private int livelloTerzoLivelloDannoMitraglietta = 1;
    private int livelloTerzoLivelloQuantitaEstrattoreElisir = 1;
    private int livelloTerzoLivelloCapienzaContenitoreElisir = 1;
    private int livelloTerzoLivelloQuantitaProduzioneMetallo = 1;
    private int livelloTerzoLivelloCapienzaProduzioneMetallo = 1;
    private int livelloTerzoLivelloQuantitaProduzioneMunizioni = 1;
    private int livelloTerzoLivelloCapienzaContenitoreMunizioni = 1;

    private int livelloQuartoLivelloVelocitaSpawn = 1;
    private int livelloQuartoLivelloDannoMitraglietta = 1;
    private int livelloQuartoLivelloQuantitaEstrattoreElisir = 1;
    private int livelloQuartoLivelloCapienzaContenitoreElisir = 1;
    private int livelloQuartoLivelloQuantitaProduzioneMetallo = 1;
    private int livelloQuartoLivelloCapienzaProduzioneMetallo = 1;
    private int livelloQuartoLivelloQuantitaProduzioneMunizioni = 1;
    private int livelloQuartoLivelloCapienzaContenitoreMunizioni = 1;

    private int livelloQuintoLivelloVelocitaSpawn = 1;
    private int livelloQuintoLivelloDannoMitraglietta = 1;
    private int livelloQuintoLivelloQuantitaEstrattoreElisir = 1;
    private int livelloQuintoLivelloCapienzaContenitoreElisir = 1;
    private int livelloQuintoLivelloQuantitaProduzioneMetallo = 1;
    private int livelloQuintoLivelloCapienzaProduzioneMetallo = 1;
    private int livelloQuintoLivelloQuantitaProduzioneMunizioni = 1;
    private int livelloQuintoLivelloCapienzaContenitoreMunizioni = 1;

    public int LivelloPrimoLivelloVelocitaSpawn { get => livelloPrimoLivelloVelocitaSpawn; set => livelloPrimoLivelloVelocitaSpawn = value; }
    public int LivelloPrimoLivelloQuantitaEstrattoreElisir { get => livelloPrimoLivelloQuantitaEstrattoreElisir; set => livelloPrimoLivelloQuantitaEstrattoreElisir = value; }
    public int LivelloPrimoLivelloCapienzaContenitoreElisir { get => livelloPrimoLivelloCapienzaContenitoreElisir; set => livelloPrimoLivelloCapienzaContenitoreElisir = value; }
    public int LivelloPrimoLivelloQuantitaProduzioneMetallo { get => livelloPrimoLivelloQuantitaProduzioneMetallo; set => livelloPrimoLivelloQuantitaProduzioneMetallo = value; }
    public int LivelloPrimoLivelloCapienzaProduzioneMetallo { get => livelloPrimoLivelloCapienzaProduzioneMetallo; set => livelloPrimoLivelloCapienzaProduzioneMetallo = value; }
    public int LivelloPrimoLivelloQuantitaProduzioneMunizioni { get => livelloPrimoLivelloQuantitaProduzioneMunizioni; set => livelloPrimoLivelloQuantitaProduzioneMunizioni = value; }
    public int LivelloPrimoLivelloCapienzaContenitoreMunizioni { get => livelloPrimoLivelloCapienzaContenitoreMunizioni; set => livelloPrimoLivelloCapienzaContenitoreMunizioni = value; }
    public int LivelloSecondoLivelloVelocitaSpawn { get => livelloSecondoLivelloVelocitaSpawn; set => livelloSecondoLivelloVelocitaSpawn = value; }
    public int LivelloSecondoLivelloDannoMitraglietta { get => livelloSecondoLivelloDannoMitraglietta; set => livelloSecondoLivelloDannoMitraglietta = value; }
    public int LivelloSecondoLivelloQuantitaEstrattoreElisir { get => livelloSecondoLivelloQuantitaEstrattoreElisir; set => livelloSecondoLivelloQuantitaEstrattoreElisir = value; }
    public int LivelloSecondoLivelloCapienzaContenitoreElisir { get => livelloSecondoLivelloCapienzaContenitoreElisir; set => livelloSecondoLivelloCapienzaContenitoreElisir = value; }
    public int LivelloSecondoLivelloQuantitaProduzioneMetallo { get => livelloSecondoLivelloQuantitaProduzioneMetallo; set => livelloSecondoLivelloQuantitaProduzioneMetallo = value; }
    public int LivelloSecondoLivelloCapienzaProduzioneMetallo { get => livelloSecondoLivelloCapienzaProduzioneMetallo; set => livelloSecondoLivelloCapienzaProduzioneMetallo = value; }
    public int LivelloSecondoLivelloQuantitaProduzioneMunizioni { get => livelloSecondoLivelloQuantitaProduzioneMunizioni; set => livelloSecondoLivelloQuantitaProduzioneMunizioni = value; }
    public int LivelloSecondoLivelloCapienzaContenitoreMunizioni { get => livelloSecondoLivelloCapienzaContenitoreMunizioni; set => livelloSecondoLivelloCapienzaContenitoreMunizioni = value; }
    public int LivelloTerzoLivelloVelocitaSpawn { get => livelloTerzoLivelloVelocitaSpawn; set => livelloTerzoLivelloVelocitaSpawn = value; }
    public int LivelloTerzoLivelloDannoMitraglietta { get => livelloTerzoLivelloDannoMitraglietta; set => livelloTerzoLivelloDannoMitraglietta = value; }
    public int LivelloTerzoLivelloQuantitaEstrattoreElisir { get => livelloTerzoLivelloQuantitaEstrattoreElisir; set => livelloTerzoLivelloQuantitaEstrattoreElisir = value; }
    public int LivelloTerzoLivelloCapienzaContenitoreElisir { get => livelloTerzoLivelloCapienzaContenitoreElisir; set => livelloTerzoLivelloCapienzaContenitoreElisir = value; }
    public int LivelloTerzoLivelloQuantitaProduzioneMetallo { get => livelloTerzoLivelloQuantitaProduzioneMetallo; set => livelloTerzoLivelloQuantitaProduzioneMetallo = value; }
    public int LivelloTerzoLivelloCapienzaProduzioneMetallo { get => livelloTerzoLivelloCapienzaProduzioneMetallo; set => livelloTerzoLivelloCapienzaProduzioneMetallo = value; }
    public int LivelloTerzoLivelloQuantitaProduzioneMunizioni { get => livelloTerzoLivelloQuantitaProduzioneMunizioni; set => livelloTerzoLivelloQuantitaProduzioneMunizioni = value; }
    public int LivelloTerzoLivelloCapienzaContenitoreMunizioni { get => livelloTerzoLivelloCapienzaContenitoreMunizioni; set => livelloTerzoLivelloCapienzaContenitoreMunizioni = value; }
    public int LivelloQuartoLivelloVelocitaSpawn { get => livelloQuartoLivelloVelocitaSpawn; set => livelloQuartoLivelloVelocitaSpawn = value; }
    public int LivelloQuartoLivelloDannoMitraglietta { get => livelloQuartoLivelloDannoMitraglietta; set => livelloQuartoLivelloDannoMitraglietta = value; }
    public int LivelloQuartoLivelloQuantitaEstrattoreElisir { get => livelloQuartoLivelloQuantitaEstrattoreElisir; set => livelloQuartoLivelloQuantitaEstrattoreElisir = value; }
    public int LivelloQuartoLivelloCapienzaContenitoreElisir { get => livelloQuartoLivelloCapienzaContenitoreElisir; set => livelloQuartoLivelloCapienzaContenitoreElisir = value; }
    public int LivelloQuartoLivelloQuantitaProduzioneMetallo { get => livelloQuartoLivelloQuantitaProduzioneMetallo; set => livelloQuartoLivelloQuantitaProduzioneMetallo = value; }
    public int LivelloQuartoLivelloCapienzaProduzioneMetallo { get => livelloQuartoLivelloCapienzaProduzioneMetallo; set => livelloQuartoLivelloCapienzaProduzioneMetallo = value; }
    public int LivelloQuartoLivelloQuantitaProduzioneMunizioni { get => livelloQuartoLivelloQuantitaProduzioneMunizioni; set => livelloQuartoLivelloQuantitaProduzioneMunizioni = value; }
    public int LivelloQuartoLivelloCapienzaContenitoreMunizioni { get => livelloQuartoLivelloCapienzaContenitoreMunizioni; set => livelloQuartoLivelloCapienzaContenitoreMunizioni = value; }
    public int LivelloQuintoLivelloVelocitaSpawn { get => livelloQuintoLivelloVelocitaSpawn; set => livelloQuintoLivelloVelocitaSpawn = value; }
    public int LivelloQuintoLivelloDannoMitraglietta { get => livelloQuintoLivelloDannoMitraglietta; set => livelloQuintoLivelloDannoMitraglietta = value; }
    public int LivelloQuintoLivelloQuantitaEstrattoreElisir { get => livelloQuintoLivelloQuantitaEstrattoreElisir; set => livelloQuintoLivelloQuantitaEstrattoreElisir = value; }
    public int LivelloQuintoLivelloCapienzaContenitoreElisir { get => livelloQuintoLivelloCapienzaContenitoreElisir; set => livelloQuintoLivelloCapienzaContenitoreElisir = value; }
    public int LivelloQuintoLivelloQuantitaProduzioneMetallo { get => livelloQuintoLivelloQuantitaProduzioneMetallo; set => livelloQuintoLivelloQuantitaProduzioneMetallo = value; }
    public int LivelloQuintoLivelloCapienzaProduzioneMetallo { get => livelloQuintoLivelloCapienzaProduzioneMetallo; set => livelloQuintoLivelloCapienzaProduzioneMetallo = value; }
    public int LivelloQuintoLivelloQuantitaProduzioneMunizioni { get => livelloQuintoLivelloQuantitaProduzioneMunizioni; set => livelloQuintoLivelloQuantitaProduzioneMunizioni = value; }
    public int LivelloQuintoLivelloCapienzaContenitoreMunizioni { get => livelloQuintoLivelloCapienzaContenitoreMunizioni; set => livelloQuintoLivelloCapienzaContenitoreMunizioni = value; }

    // FINE LIVELLI
    #endregion


    #region valore dei livelli
    //VALORE LIVELLI
    Dictionary<int, int> primoLivelloProduzione = new Dictionary<int, int>()
    {
        {1,1},
        {2,2},
        {3,3},
        {4,4},
        {5,5},
        {6,6},
        {7,7},
        {8,8},
        {9,9},
        {10,10}
    };

    Dictionary<int, int> primoLivelloContenitore = new Dictionary<int, int>()
    {
        {1,10},
        {2,20},
        {3,30},
        {4,40},
        {5,50},
        {6,60},
        {7,70},
        {8,80},
        {9,90},
        {10,100}
    };

    Dictionary<int, float> primoLivelloSpawn = new Dictionary<int, float>()
    {
        {1,7f},
        {2,6f},
        {3,5f},
        {4,4f},
        {5,3f}
    };


    Dictionary<int, int> secondoLivelloProduzione = new Dictionary<int, int>()
    {
        {1,2},
        {2,4},
        {3,6},
        {4,8},
        {5,10},
        {6,12},
        {7,14},
        {8,16},
        {9,18},
        {10,20}
    };

    Dictionary<int, int> secondoLivelloContenitore = new Dictionary<int, int>()
    {
        {1,100},
        {2,200},
        {3,300},
        {4,400},
        {5,500},
        {6,600},
        {7,700},
        {8,800},
        {9,900},
        {10,1000}
    };

    Dictionary<int, float> secondoLivelloSpawn = new Dictionary<int, float>()
    {
        {1,9f},
        {2,8f},
        {3,7f},
        {4,6f},
        {5,5f}
    };

    Dictionary<int, int> secondoLivelloTorretta = new Dictionary<int, int>()
    {
        {1,10},
        {2,15},
        {3,20},
        {4,30},
        {5,40}
    };

    Dictionary<int, int> terzoLivelloProduzione = new Dictionary<int, int>()
    {
        {1,3},
        {2,6},
        {3,9},
        {4,12},
        {5,15},
        {6,18},
        {7,21},
        {8,24},
        {9,27},
        {10,30}
    };

    Dictionary<int, int> terzoLivelloContenitore = new Dictionary<int, int>()
    {
        {1,1000},
        {2,2000},
        {3,3000},
        {4,4000},
        {5,5000},
        {6,6000},
        {7,7000},
        {8,8000},
        {9,9000},
        {10,10000}
    };

    Dictionary<int, float> terzoLivelloSpawn = new Dictionary<int, float>()
    {
        {1,11f},
        {2,10f},
        {3,9f},
        {4,8f},
        {5,7f}
    };

    Dictionary<int, int> terzoLivelloTorretta = new Dictionary<int, int>()
    {
        {1,20},
        {2,25},
        {3,30},
        {4,40},
        {5,50}
    };

    Dictionary<int, int> quartoLivelloProduzione = new Dictionary<int, int>()
    {
        {1,4},
        {2,8},
        {3,12},
        {4,16},
        {5,20},
        {6,24},
        {7,28},
        {8,32},
        {9,36},
        {10,40}
    };

    Dictionary<int, int> quartoLivelloContenitore = new Dictionary<int, int>()
    {
        {1,10000},
        {2,20000},
        {3,30000},
        {4,40000},
        {5,50000},
        {6,60000},
        {7,70000},
        {8,80000},
        {9,90000},
        {10,100000}
    };

    Dictionary<int, float> quartoLivelloSpawn = new Dictionary<int, float>()
    {
        {1,13f},
        {2,12f},
        {3,11f},
        {4,10f},
        {5,9f}
    };

    Dictionary<int, int> quartoLivelloTorretta = new Dictionary<int, int>()
    {
        {1,20},
        {2,30},
        {3,40},
        {4,50},
        {5,65}
    };

    Dictionary<int, int> quintoLivelloProduzione = new Dictionary<int, int>()
    {
        {1,5},
        {2,10},
        {3,15},
        {4,20},
        {5,25},
        {6,30},
        {7,35},
        {8,40},
        {9,45},
        {10,50}
    };

    Dictionary<int, int> quintoLivelloContenitore = new Dictionary<int, int>()
    {
        {1,100000},
        {2,200000},
        {3,300000},
        {4,400000},
        {5,500000},
        {6,600000},
        {7,700000},
        {8,800000},
        {9,900000},
        {10,1000000}
    };

        Dictionary<int, float> quintoLivelloSpawn = new Dictionary<int, float>()
    {
        {1,15f},
        {2,14f},
        {3,13f},
        {4,12f},
        {5,11f}
    };

    Dictionary<int, int> quintoLivelloTorretta = new Dictionary<int, int>()
    {
        {1,30},
        {2,40},
        {3,50},
        {4,60},
        {5,75}
    };

    public Dictionary<int, int> PrimoLivelloProduzione { get => primoLivelloProduzione; }
    public Dictionary<int, int> PrimoLivelloContenitore { get => primoLivelloContenitore; }
    public Dictionary<int, float> PrimoLivelloSpawn { get => primoLivelloSpawn; set => primoLivelloSpawn = value; }
    public Dictionary<int, int> SecondoLivelloProduzione { get => secondoLivelloProduzione; }
    public Dictionary<int, int> SecondoLivelloContenitore { get => secondoLivelloContenitore; }
    public Dictionary<int, float> SecondoLivelloSpawn { get => secondoLivelloSpawn; set => secondoLivelloSpawn = value; }
    public Dictionary<int, int> SecondoLivelloTorretta { get => secondoLivelloTorretta; set => secondoLivelloTorretta = value; }
    public Dictionary<int, int> TerzoLivelloProduzione { get => terzoLivelloProduzione; }
    public Dictionary<int, int> TerzoLivelloContenitore { get => terzoLivelloContenitore; }
    public Dictionary<int, float> TerzoLivelloSpawn { get => terzoLivelloSpawn; set => terzoLivelloSpawn = value; }
    public Dictionary<int, int> TerzoLivelloTorretta { get => terzoLivelloTorretta; set => terzoLivelloTorretta = value; }
    public Dictionary<int, int> QuartoLivelloProduzione { get => quartoLivelloProduzione; }
    public Dictionary<int, int> QuartoLivelloContenitore { get => quartoLivelloContenitore; }
    public Dictionary<int, float> QuartoLivelloSpawn { get => quartoLivelloSpawn; set => quartoLivelloSpawn = value; }
    public Dictionary<int, int> QuartoLivelloTorretta { get => quartoLivelloTorretta; set => quartoLivelloTorretta = value; }
    public Dictionary<int, int> QuintoLivelloProduzione { get => quintoLivelloProduzione; }
    public Dictionary<int, int> QuintoLivelloContenitore { get => quintoLivelloContenitore; }
    public Dictionary<int, float> QuintoLivelloSpawn { get => quintoLivelloSpawn; set => quintoLivelloSpawn = value; }
    public Dictionary<int, int> QuintoLivelloTorretta { get => quintoLivelloTorretta; set => quintoLivelloTorretta = value; }

    //FINE

    #endregion



    #region prezzi per gli upgrade
    //PREZZO UPGRADE

    Dictionary<int, int> primoLivelloProduzioneEContenitoreSoldi = new Dictionary<int, int>()
    {
        
        {2,50},
        {3,100},
        {4,150},
        {5,200},
        {6,250},
        {7,300},
        {8,350},
        {9,400},
        {10,500}
    };

    public Dictionary<int, int> PrimoLivelloProduzioneEContenitoreSoldi { get => primoLivelloProduzioneEContenitoreSoldi; }

    Dictionary<int, int> primoLivelloSpawnEDannoSoldi = new Dictionary<int, int>()
    {
        {2,150},
        {3,300},
        {4,500},
        {5,750}
    };

    public Dictionary<int, int> PrimoLivelloSpawnEDannoSoldi { get => primoLivelloSpawnEDannoSoldi; set => primoLivelloSpawnEDannoSoldi = value; }




    Dictionary<int, int> secondoLivelloProduzioneEContenitoreSoldi = new Dictionary<int, int>()
    {

        {2,750},
        {3,1000},
        {4,1250},
        {5,1500},
        {6,1750},
        {7,2000},
        {8,2250},
        {9,2500},
        {10,5000}
    };
    public Dictionary<int, int> SecondoLivelloProduzioneEContenitoreSoldi { get => secondoLivelloProduzioneEContenitoreSoldi;}

    Dictionary<int, int> secondoLivelloSpawnEDannoSoldi = new Dictionary<int, int>()
    {
        {2,1750},
        {3,3250},
        {4,5000},
        {5,7500}
    };

    public Dictionary<int, int> SecondoLivelloSpawnEDannoSoldi { get => secondoLivelloSpawnEDannoSoldi; set => secondoLivelloSpawnEDannoSoldi = value; }


    Dictionary<int, int> terzoLivelloProduzioneEContenitoreSoldi = new Dictionary<int, int>()
    {

        {2,6500},
        {3,8000},
        {4,9500},
        {5,11000},
        {6,12500},
        {7,14000},
        {8,15500},
        {9,17000},
        {10,25000}
    };
    public Dictionary<int, int> TerzoLivelloProduzioneEContenitoreSoldi { get => terzoLivelloProduzioneEContenitoreSoldi;}

    Dictionary<int, int> terzoLivelloSpawnEDannoSoldi = new Dictionary<int, int>()
    {
        {2,13500},
        {3,20500},
        {4,28000},
        {5,37500}
    };

    public Dictionary<int, int> TerzoLivelloSpawnEDannoSoldi { get => terzoLivelloSpawnEDannoSoldi; set => terzoLivelloSpawnEDannoSoldi = value; }


    Dictionary<int, int> quartoLivelloProduzioneEContenitoreSoldi = new Dictionary<int, int>()
    {

        {2,28000},
        {3,31000},
        {4,34000},
        {5,37000},
        {6,40000},
        {7,43000},
        {8,46000},
        {9,49000},
        {10,50000}
    };

    public Dictionary<int, int> QuartoLivelloProduzioneEContenitoreSoldi { get => quartoLivelloProduzioneEContenitoreSoldi;}

    Dictionary<int, int> quartoLivelloSpawnEDannoSoldi = new Dictionary<int, int>()
    {
        {2,45000},
        {3,52500},
        {4,60000},
        {5,75000}
    };

    public Dictionary<int, int> QuartoLivelloSpawnEDannoSoldi { get => quartoLivelloSpawnEDannoSoldi; set => quartoLivelloSpawnEDannoSoldi = value; }

    Dictionary<int, int> quintoLivelloProduzioneEContenitoreSoldi = new Dictionary<int, int>()
    {

        {2,52500},
        {3,55000},
        {4,57500},
        {5,60000},
        {6,62500},
        {7,65000},
        {8,67500},
        {9,70000},
        {10,75000}
    };
    public Dictionary<int, int> QuintoLivelloProduzioneEContenitoreSoldi { get => quintoLivelloProduzioneEContenitoreSoldi;}

    Dictionary<int, int> quintoLivelloSpawnEDannoSoldi = new Dictionary<int, int>()
    {
        {2,80000},
        {3,85000},
        {4,90000},
        {5,100000}
    };

    public Dictionary<int, int> QuintoLivelloSpawnEDannoSoldi { get => quintoLivelloSpawnEDannoSoldi; set => quintoLivelloSpawnEDannoSoldi = value; }


    //FINE PREZZI UPGRADE
    #endregion

    public float Moneta { get => moneta; set => moneta = value; }
    public float Metallo { get => metallo; set => metallo = value; }
    public float Munizione { get => munizione; set => munizione = value; }
    public float Elisir { get => elisir; set => elisir = value; }
    

    public void addMoneta(float cerv)
    {
        moneta += cerv;
       
    }

    public void addElisir(float el)
    {
        elisir += el;
    }

    public void addMetallo(float met)
    {
        metallo += met;
    }

    public void addMunizione(float mun)
    {
        munizione += mun;
    }

    public void removeMoneta(float cerv)
    {
        moneta -= cerv;
       
    }
    public void removeElisir(float el)
    {
        elisir -= el;
    }

    public void removeMetallo(float met)
    {
        metallo -= met;
    }

    public void removeMunizione(float mun)
    {
        munizione -= mun;
    }


    //CONTENITORI QUANTITA'

    private int primoLivelloContenitoreElisir = 0;
    private int secondoLivelloContenitoreElisir = 0;
    private int terzoLivelloContenitoreElisir = 0;
    private int quartoLivelloContenitoreElisir = 0;
    private int quintoLivelloContenitoreElisir = 0;

    private int quantitaLivelloContenitoreElisir = 0;
    public int PrimoLivelloContenitoreElisir { get => primoLivelloContenitoreElisir; set => primoLivelloContenitoreElisir = value; }
    public int SecondoLivelloContenitoreElisir { get => secondoLivelloContenitoreElisir; set => secondoLivelloContenitoreElisir = value; }
    public int TerzoLivelloContenitoreElisir { get => terzoLivelloContenitoreElisir; set => terzoLivelloContenitoreElisir = value; }
    public int QuartoLivelloContenitoreElisir { get => quartoLivelloContenitoreElisir; set => quartoLivelloContenitoreElisir = value; }
    public int QuintoLivelloContenitoreElisir { get => quintoLivelloContenitoreElisir; set => quintoLivelloContenitoreElisir = value; }
   

    public void aggiornamentoContenitoreElisir()
    {
        quantitaLivelloContenitoreElisir = PrimoLivelloContenitoreElisir + SecondoLivelloContenitoreElisir + TerzoLivelloContenitoreElisir + QuartoLivelloContenitoreElisir + QuintoLivelloContenitoreElisir;

    }

    public float getContenitoreElisir()
    {
        return quantitaLivelloContenitoreElisir;
    }

    private int primoLivelloContenitoreMetallo = 0;
    private int secondoLivelloContenitoreMetallo = 0;
    private int terzoLivelloContenitoreMetallo = 0;
    private int quartoLivelloContenitoreMetallo = 0;
    private int quintoLivelloContenitoreMetallo = 0;

    private int quantitaLivelloContenitoreMetallo = 0;

    public int PrimoLivelloContenitoreMetallo { get => primoLivelloContenitoreMetallo; set => primoLivelloContenitoreMetallo = value; }
    public int SecondoLivelloContenitoreMetallo { get => secondoLivelloContenitoreMetallo; set => secondoLivelloContenitoreMetallo = value; }
    public int TerzoLivelloContenitoreMetallo { get => terzoLivelloContenitoreMetallo; set => terzoLivelloContenitoreMetallo = value; }
    public int QuartoLivelloContenitoreMetallo { get => quartoLivelloContenitoreMetallo; set => quartoLivelloContenitoreMetallo = value; }
    public int QuintoLivelloContenitoreMetallo { get => quintoLivelloContenitoreMetallo; set => quintoLivelloContenitoreMetallo = value; }
   

    public void aggiornamentoContenitoreMetallo()
    {
        quantitaLivelloContenitoreMetallo = PrimoLivelloContenitoreMetallo + SecondoLivelloContenitoreMetallo + TerzoLivelloContenitoreMetallo + QuartoLivelloContenitoreMetallo + QuintoLivelloContenitoreMetallo;
    }

    public float getContenitoreMetallo()
    {
        return quantitaLivelloContenitoreMetallo;
    }

    private int primoLivelloContenitoreMunizioni = 0;
    private int secondoLivelloContenitoreMunizioni = 0;
    private int terzoLivelloContenitoreMunizioni = 0;
    private int quartoLivelloContenitoreMunizioni = 0;
    private int quintoLivelloContenitoreMunizioni = 0;

    private int quantitaLivelloContenitoreMunizioni = 0;

    public int PrimoLivelloContenitoreMunizioni { get => primoLivelloContenitoreMunizioni; set => primoLivelloContenitoreMunizioni = value; }
    public int SecondoLivelloContenitoreMunizioni { get => secondoLivelloContenitoreMunizioni; set => secondoLivelloContenitoreMunizioni = value; }
    public int TerzoLivelloContenitoreMunizioni { get => terzoLivelloContenitoreMunizioni; set => terzoLivelloContenitoreMunizioni = value; }
    public int QuartoLivelloContenitoreMunizioni { get => quartoLivelloContenitoreMunizioni; set => quartoLivelloContenitoreMunizioni = value; }
    public int QuintoLivelloContenitoreMunizioni { get => quintoLivelloContenitoreMunizioni; set => quintoLivelloContenitoreMunizioni = value; }


    public void aggiornamentoContenitoreMunizioni()
    {
        quantitaLivelloContenitoreMunizioni = PrimoLivelloContenitoreMunizioni + SecondoLivelloContenitoreMunizioni + TerzoLivelloContenitoreMunizioni + QuartoLivelloContenitoreMunizioni + QuintoLivelloContenitoreMunizioni;
    }

    public float getContenitoreMunizioni()
    {
        return quantitaLivelloContenitoreMunizioni;
    }


    //FINE CONTENITORI


    //ARMI COMPRATE

    private bool compratoArma1 = true;
    private bool compratoArma2 = false;
    private bool compratoArma3 = false;
    private bool compratoArma4 = false;
    private bool compratoArma5 = false;

    public bool CompratoArma1 { get => compratoArma1; set => compratoArma1 = value; }
    public bool CompratoArma2 { get => compratoArma2; set => compratoArma2 = value; }
    public bool CompratoArma3 { get => compratoArma3; set => compratoArma3 = value; }
    public bool CompratoArma4 { get => compratoArma4; set => compratoArma4 = value; }
    public bool CompratoArma5 { get => compratoArma5; set => compratoArma5 = value; }

    //ARMI SELEZIONATA

    private bool selezionatoArma1 = true;
    private bool selezionatoArma2 = false;
    private bool selezionatoArma3 = false;
    private bool selezionatoArma4 = false;
    private bool selezionatoArma5 = false;

    public bool SelezionatoArma1 { get => selezionatoArma1; set => selezionatoArma1 = value; }
    public bool SelezionatoArma2 { get => selezionatoArma2; set => selezionatoArma2 = value; }
    public bool SelezionatoArma3 { get => selezionatoArma3; set => selezionatoArma3 = value; }
    public bool SelezionatoArma4 { get => selezionatoArma4; set => selezionatoArma4 = value; }
    public bool SelezionatoArma5 { get => selezionatoArma5; set => selezionatoArma5 = value; }

    //PERSONAGGI COMPRATI

    private bool compratoPersonaggio1 = true;
    private bool compratoPersonaggio2 = false;
    private bool compratoPersonaggio3 = false;

    public bool CompratoPersonaggio1 { get => compratoPersonaggio1; set => compratoPersonaggio1 = value; }
    public bool CompratoPersonaggio2 { get => compratoPersonaggio2; set => compratoPersonaggio2 = value; }
    public bool CompratoPersonaggio3 { get => compratoPersonaggio3; set => compratoPersonaggio3 = value; }
    

    //PERSONAGGI SELEZIONATI

    private bool selezionatoPersonaggio1 = true;
    private bool selezionatoPersonaggio2 = false;
    private bool selezionatoPersonaggio3 = false;
    
    public bool SelezionatoPersonaggio1 { get => selezionatoPersonaggio1; set => selezionatoPersonaggio1 = value; }
    public bool SelezionatoPersonaggio2 { get => selezionatoPersonaggio2; set => selezionatoPersonaggio2 = value; }
    public bool SelezionatoPersonaggio3 { get => selezionatoPersonaggio3; set => selezionatoPersonaggio3 = value; }
   

    //CLICCATO L'ABILITA'

    private bool abilitaCliccataArma = false;
    private bool abilitaCliccataEroe = false;
    public bool AbilitaCliccataArma { get => abilitaCliccataArma; set => abilitaCliccataArma = value; }
    public bool AbilitaCliccataEroe { get => abilitaCliccataEroe; set => abilitaCliccataEroe = value; }

    //USATA ABILITA'
    private bool abilitaUsataArma = true;
    private bool abilitaUsataEroe = true;

    public bool AbilitaUsataArma { get => abilitaUsataArma; set => abilitaUsataArma = value; }
    public bool AbilitaUsataEroe { get => abilitaUsataEroe; set => abilitaUsataEroe = value; }
    //

   

    //UID GIOCATORE
    private string id;
    public string Id { get => id; set => id = value; }


    private bool morteGiocatoreDungeon = false;
    public bool MorteGiocatoreDungeon { get => morteGiocatoreDungeon; set => morteGiocatoreDungeon = value; }

    #region menu

    //LINGUA: it -> italiano, en -> inglese
    private string lingua = "en";
    public string Lingua { get => lingua; set => lingua = value; }

    //MUSICA
    private float musica = 1.0f;
    public float Musica { get => musica; set => musica = value; }

    //SUONI
    private float suono = 0.4f;
    public float Suono { get => suono; set => suono = value; }

    #endregion


    #region tutorial
    //TUTORIAL
    private bool escaTutorial = false;
    private bool torrettaTutorial = false;
    private bool muroTutorial = false;
    private bool mostroTutorial = false;
    private bool colpoTutorial = false;
    private bool risorseTutorial = false;

    public bool EscaTutorial { get => escaTutorial; set => escaTutorial = value; }
    public bool TorrettaTutorial { get => torrettaTutorial; set => torrettaTutorial = value; }
    public bool MuroTutorial { get => muroTutorial; set => muroTutorial = value; }
    public bool MostroTutorial { get => mostroTutorial; set => mostroTutorial = value; }
    public bool ColpoTutorial { get => colpoTutorial; set => colpoTutorial = value; }
    public bool RisorseTutorial { get => risorseTutorial; set => risorseTutorial = value; }


    #endregion


    #region ads

    private bool ads1 = false;
    private bool ads2 = false;
    private bool ads3 = false;

    public bool Ads1 { get => ads1; set => ads1 = value; }
    public bool Ads2 { get => ads2; set => ads2 = value; }
    public bool Ads3 { get => ads3; set => ads3 = value; }
    


    #endregion


    private int mostriLivello1 = 0;
    private int mostriLivello2 = 0;
    private int mostriLivello3 = 0;
    private int mostriLivello4 = 0;
    private int mostriLivello5 = 0;

    public int MostriLivello1 { get => mostriLivello1; set => mostriLivello1 = value; }
    public int MostriLivello2 { get => mostriLivello2; set => mostriLivello2 = value; }
    public int MostriLivello3 { get => mostriLivello3; set => mostriLivello3 = value; }
    public int MostriLivello4 { get => mostriLivello4; set => mostriLivello4 = value; }
    public int MostriLivello5 { get => mostriLivello5; set => mostriLivello5 = value; }

    private string ultimoAccesso = "";
    public string UltimoAccesso { get => ultimoAccesso; set => ultimoAccesso = value; }
  
    private double moneteGuadagnateOffline = 0;
    public double MoneteGuadagnateOffline { get => moneteGuadagnateOffline; set => moneteGuadagnateOffline = value; }


   


    /* private bool salvare = false;
 public bool Salvare { get => salvare; set => salvare = value; }*/




    // Opzionale: puoi aggiungere metodi e variabili per gestire il comportamento del singleton
}
