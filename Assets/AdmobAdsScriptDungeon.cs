using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class AdmobAdsScriptDungeon : MonoBehaviour
{

    private string appId = "ca-app-pub-7877336133027826~7566683223"; //"ca-app-pub-3940256099942544~3347511713";

    string rewaredId = "ca-app-pub-7877336133027826/4009462036"; //"ca-app-pub-3940256099942544/5224354917";

    RewardedAd rewardedAd;

    //identifico i pulsanti per poter poi assegnare le ricompense

    private codicePersonaggio personaggio;

    public Button pulsanteRinascita;
    public GameObject pannelloRinascita;
    private bool pulsanteRinascitaBool = false;

    public Button pulsanteColpi;
    public GameObject pannelloColpi;
    private bool pulsanteColpiBool = false;

    public Button exitRinascita;
    public Button exitColpi;

    public GameObject spawnMostri;

    public GameObject pannelloAds1;
    public GameObject pannelloAds2;
    
    singleton singleton;



    // Start is called before the first frame update
    void Start()
    {
        singleton = singleton.Instance;

        pulsanteRinascita.onClick.AddListener(p1);
        pulsanteColpi.onClick.AddListener(p2);
        exitRinascita.onClick.AddListener(exitR);
        exitColpi.onClick.AddListener(exitC);

        MobileAds.RaiseAdEventsOnUnityMainThread = true;
        MobileAds.Initialize(initStatus => {
            print("Ads Initialised!");
        });
    }

     #region assegnazioneRicompense
    private void p1()
    {
        pulsanteRinascitaBool = true;
        pulsanteColpiBool = false;
    }

    private void p2()
    {
        pulsanteRinascitaBool = false;
        pulsanteColpiBool = true;

    }

    private void exitR()
    {

        pannelloRinascita.SetActive(false);
        singleton.AbilitaCliccataArma = false;
        singleton.AbilitaCliccataEroe = false;
        singleton.AbilitaUsataEroe = true;
        singleton.AbilitaUsataArma = true;
        singleton.MorteGiocatoreDungeon = false;

        //se preme x ritorna indietro
        Screen.orientation = ScreenOrientation.Portrait;
        SceneManager.LoadScene("Spawn");
    }
    private void exitC()
    {
        pannelloColpi.SetActive(false);
        Time.timeScale = 1;
        //spawnMostri.SetActive(true);

    }

    #endregion


    #region Rewarded

    public void LoadRewardedAd()
    {

        pannelloAds1.SetActive(true);
        pannelloAds2.SetActive(true);

        if (rewardedAd != null)
        {
            rewardedAd.Destroy();
            rewardedAd = null;
        }
        var adRequest = new AdRequest();
        adRequest.Keywords.Add("unity-admob-sample");

        RewardedAd.Load(rewaredId, adRequest, (RewardedAd ad, LoadAdError error) =>
        {
            if (error != null || ad == null)
            {
                print("Rewarded failed to load " + error);

                pannelloAds1.SetActive(false);
                pannelloAds2.SetActive(false);

                return;
            }

            print("Rewarded ad loaded !!");
            rewardedAd = ad;
            RewarderAdEvents(rewardedAd);

            pannelloAds1.SetActive(false);
            pannelloAds2.SetActive(false);

            //carico subito il video che è stato caricato
            ShowRewarderAd();
        });
    }

    private void destroyEnemies()
    {
        // Trova tutti i GameObject con il tag "nemico"
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("nemico");

        // Distruggi ciascun nemico
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }
    }

    public void ShowRewarderAd()
    {
        if (rewardedAd != null && rewardedAd.CanShowAd())
        {
            rewardedAd.Show((Reward reward) => {
                print("Give reward to player !!");

                //inserisco la ricompensa

                if (pulsanteColpiBool)
                {
                    //se accettato distruggo tutti i nemici
                    destroyEnemies();
                    

                    //assegnare 200 colpi
                    singleton.addMunizione(200);
                    pannelloColpi.SetActive(false);
                    //spawnMostri.SetActive(true);
                    Time.timeScale = 1;
                }
                else if (pulsanteRinascitaBool)
                {
                    //se accettato distruggo tutti i nemici
                    destroyEnemies();

                    //assegnare rinascita e +100 colpi
                    singleton.addMunizione(100);
                    personaggio = GameObject.FindGameObjectWithTag("personaggioAttivo").GetComponent<codicePersonaggio>();
                    personaggio.aggiungiVita(500);
                    pannelloRinascita.SetActive(false);
                }

                pulsanteRinascitaBool = false;
                pulsanteColpiBool = false;


            });
        }
        else
        {
            print("Rewarded ad not ready");
        }
    }

    public void RewarderAdEvents(RewardedAd ad)
    {
        // Raised when the ad is estimated to have earned money.
        ad.OnAdPaid += (AdValue adValue) =>
        {
            Debug.Log("Rewarded ad paid {0} {1}." +
                adValue.Value +
                adValue.CurrencyCode);
        };
        // Raised when an impression is recorded for an ad.
        ad.OnAdImpressionRecorded += () =>
        {
            Debug.Log("Rewarded ad recorded an impression.");
        };
        // Raised when a click is recorded for an ad.
        ad.OnAdClicked += () =>
        {
            Debug.Log("Rewarded ad was clicked.");
        };
        // Raised when an ad opened full screen content.
        ad.OnAdFullScreenContentOpened += () =>
        {
            Debug.Log("Rewarded ad full screen content opened.");
        };
        // Raised when the ad closed full screen content.
        ad.OnAdFullScreenContentClosed += () =>
        {
            Debug.Log("Rewarded ad full screen content closed.");
        };
        // Raised when the ad failed to open full screen content.
        ad.OnAdFullScreenContentFailed += (AdError error) =>
        {
            Debug.LogError("Rewarded ad failed to open full screen content " +
                           "with error : " + error);
        };
    }


    #endregion





}
