using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class AdmobAdsScript : MonoBehaviour
{

    string appId = "ca-app-pub-7877336133027826~7566683223"; //"ca-app-pub-3940256099942544~3347511713";

    string rewaredId = "ca-app-pub-7877336133027826/4009462036"; //"ca-app-pub-3940256099942544/5224354917";

    RewardedAd rewardedAd;

    //identifico i pulsanti per poter poi assegnare le ricompense

    //monete x2
    public Button pulsante1;
    private bool pulsanteBool1 = false;
    public GameObject timer1GameObject;
    public GameObject testo1;

    //colpi magici - tempo
    public Button pulsante2;
    private bool pulsanteBool2 = false;
    public GameObject timer2GameObject;
    public GameObject testo2;

    //+ produzione
    public Button pulsante3;
    private bool pulsanteBool3 = false;
    public GameObject timer3GameObject;
    public GameObject testo3;

    //x2 offline
    public GameObject pannelloOffline;
    public Button pulsante4;
    public Button pulsante4x2;

    public GameObject pannelloAds;


    singleton singleton;




    // Start is called before the first frame update
    void Start()
    {
        singleton = singleton.Instance;

        pulsante1.onClick.AddListener(p1);
        pulsante2.onClick.AddListener(p2);
        pulsante3.onClick.AddListener(p3);
        pulsante4x2.onClick.AddListener(p4);

        MobileAds.RaiseAdEventsOnUnityMainThread = true;
        MobileAds.Initialize(initStatus => {
            print("Ads Initialised!");
        });
    }

    #region assegnazioneRicompense
    private void p1()
    {
        pulsanteBool1 = true;
        pulsanteBool2 = false;
        pulsanteBool3 = false;
    }

    private void p2()
    {
        pulsanteBool1 = false;
        pulsanteBool2 = true;
        pulsanteBool3 = false;
    }

    private void p3()
    {
        pulsanteBool1 = false;
        pulsanteBool2 = false;
        pulsanteBool3 = true;
    }

    private void p4()
    {
        pulsante4.GetComponent<Image>().color = Color.gray;
        pulsante4x2.GetComponent<Image>().color = Color.gray;
        pulsante4.enabled = false;
        pulsante4x2.enabled = false;

    }

    #endregion

    #region timer60Secondi
    IEnumerator timer1()
    {
        yield return new WaitForSeconds(60f);

        pulsante1.enabled = true;
        pulsante1.GetComponent<Image>().color = Color.white;

        //disattivo bool pubblicità 1
        singleton.Ads1 = false;
    }

    IEnumerator timer2()
    {
        yield return new WaitForSeconds(60f);

        pulsante2.enabled = true;
        pulsante2.GetComponent<Image>().color = Color.white;

        //disattivo bool pubblicità 2
        singleton.Ads2 = false;
    }


    IEnumerator timer3()
    {
        yield return new WaitForSeconds(60f);

        pulsante3.enabled = true;
        pulsante3.GetComponent<Image>().color = Color.white;

        //disattivo bool pubblicità 3
        singleton.Ads3 = false;
    }
    #endregion


    #region Rewarded

    public void LoadRewardedAd()
    {
        //apro il pannello pubblicità
        //pannelloAds.SetActive(true);

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
                pannelloAds.SetActive(false);

                //in caso di errore di caricamento della pubblicità vengono riattivati i pulsanti (offline x2)
                pulsante4.enabled = true;
                pulsante4x2.enabled = true;
                pulsante4.GetComponent<Image>().color = Color.white;
                pulsante4x2.GetComponent<Image>().color = Color.white;

                return;
            }


            print("Rewarded ad loaded !!");
            rewardedAd = ad;
            RewarderAdEvents(rewardedAd);

            //chiudo il pannello pubblicità dopo che ha caricato la pubblicità
            pannelloAds.SetActive(false);

            //carico subito il video che è stato caricato
            ShowRewarderAd();
        });
    }

    public void ShowRewarderAd()
    {
        if (rewardedAd != null && rewardedAd.CanShowAd())
        {
            rewardedAd.Show((Reward reward) => {
                print("Give reward to player !!");

                //inserisco la ricompensa

                if (pulsanteBool1)
                {

                    pulsante1.enabled = false;
                    pulsante1.GetComponent<Image>().color = Color.gray;

                    //attivo bool della pubblicità
                    singleton.Ads1 = true;

                    //attivo timer visivo
                    timerAds t1 = testo1.GetComponent<timerAds>();
                    t1.resetTimer();
                    timer1GameObject.SetActive(true);
                    StartCoroutine(timer1());
                    //disattivo il pulsante per più di 60 secondi

                }
                else if (pulsanteBool2)
                {

                    pulsante2.enabled = false;
                    pulsante2.GetComponent<Image>().color = Color.gray;

                    //attivo bool della pubblicità
                    singleton.Ads2 = true;

                    //attivo timer visivo
                    timerAds t2 = testo2.GetComponent<timerAds>();
                    t2.resetTimer();
                    timer2GameObject.SetActive(true);
                    StartCoroutine(timer2());
                    //disattivo il pulsante per più di 60 secondi
                }
                else if (pulsanteBool3)
                {

                    pulsante3.enabled = false;
                    pulsante3.GetComponent<Image>().color = Color.gray;

                    //attivo bool della pubblicità
                    singleton.Ads3 = true;

                    //attivo timer visivo
                    timerAds t3 = testo3.GetComponent<timerAds>();
                    t3.resetTimer();
                    timer3GameObject.SetActive(true);
                    StartCoroutine(timer3());
                    //disattivo il pulsante per più di 60 secondi
                }
                else
                {
                    //vuol dire che è la x2 offline
                    singleton.addMoneta((float)singleton.MoneteGuadagnateOffline * 2);
                    pannelloOffline.SetActive(false);
                }


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
