using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Google.Play.Review;

public class rManager : MonoBehaviour
{
    private ReviewManager _reviewManager;
    private PlayReviewInfo _playReviewInfo;
    int launchCourt;

    public GameObject pannello;

    // Start is called before the first frame update
    void Start()
    {
        launchCourt = PlayerPrefs.GetInt("TimesLaunched", 0);
        launchCourt = launchCourt + 1;
        PlayerPrefs.SetInt("TimesLaunched", launchCourt);
        Debug.Log("The app has been launched " + launchCourt + " times");

        if(launchCourt == 5 || launchCourt == 10)
        {
            pannello.SetActive(true);
        }
    }

    public void inviaRichiesta()
    {
        StartCoroutine(RequestReviews());
    }

    IEnumerator RequestReviews()
    {
        _reviewManager = new ReviewManager();

        Debug.Log("review");

        // Richiedi un oggetto ReviewInfo
        var requestFlowOperation = _reviewManager.RequestReviewFlow();
        yield return requestFlowOperation;
        if (requestFlowOperation.Error != ReviewErrorCode.NoError)
        {
            // Registra l'errore, ad esempio utilizzando requestFlowOperation.Error.ToString().
            yield break;
        }
        _playReviewInfo = requestFlowOperation.GetResult();

        // Avvia il flusso InApp Review
        var launchFlowOperation = _reviewManager.LaunchReviewFlow(_playReviewInfo);
        yield return launchFlowOperation;
        _playReviewInfo = null; // Resetta l'oggetto
        if (launchFlowOperation.Error != ReviewErrorCode.NoError)
        {
            // Registra l'errore, ad esempio utilizzando requestFlowOperation.Error.ToString().
            yield break;
        }
        // Il flusso è terminato. L'API non indica se l'utente ha recensito o meno, o se il dialogo della recensione è stato mostrato. Quindi, indipendentemente dal risultato, continuiamo il flusso della nostra app.


        pannello.SetActive(false);
    }
}
