using Firebase.Auth;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class google : MonoBehaviour
{
    singleton singleton;
    public ottenereDati db;
    public GameObject erroreTesto;

    public GameObject pannelloInglese;
    public GameObject pannelloItaliano;
    public GameObject gameObjectPulsanteIngleseDx;
    public GameObject gameObjectPulsanteItalianoSx;
    public Button pulsanteIngleseDx;
    public Button pulsanteItalianoSx;


    private void clickIngleseDx()
    {
        pannelloInglese.SetActive(false);
        pannelloItaliano.SetActive(true);

        gameObjectPulsanteIngleseDx.SetActive(false);
        gameObjectPulsanteItalianoSx.SetActive(true);

    }

    private void clickItalianoSx()
    {
        pannelloInglese.SetActive(true);
        pannelloItaliano.SetActive(false);

        gameObjectPulsanteIngleseDx.SetActive(true);
        gameObjectPulsanteItalianoSx.SetActive(false);
    }

    void Start()
    {
       
        singleton = singleton.Instance;

        pulsanteIngleseDx.onClick.AddListener(clickIngleseDx);
        pulsanteItalianoSx.onClick.AddListener(clickItalianoSx);

        // Controlla la connessione di rete
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            ShowErrorMessage("Nessuna connessione di rete disponibile");
            return;
        }

        PlayGamesPlatform.Instance.Authenticate(status =>
        {
          
            if (status == SignInStatus.Success)
            {
               
                PlayGamesPlatform.Instance.RequestServerSideAccess(true, code =>
                {
                  
                    FirebaseAuth auth = FirebaseAuth.DefaultInstance;
                    Credential credential = PlayGamesAuthProvider.GetCredential(code);
                    auth.SignInWithCredentialAsync(credential).ContinueWith(task =>
                    {
                       
                        if (task.IsCanceled)
                        {
                            // Errore di cancellazione
                            ShowErrorMessage("Accesso annullato");
                        }
                        else if (task.IsFaulted)
                        {
                            // Errore durante l'autenticazione
                            ShowErrorMessage("Errore durante l'autenticazione: " + task.Exception.Message);
                        }
                        else
                        {
                            FirebaseUser newUser = task.Result;
                            singleton.Id = newUser.UserId;

                            //CARICO LA SCENA DENTRO A DB DOPO CHE HA INSERITO CORRETTAMENTE I DATI
                            db.richiestaDati(newUser.UserId);

                        }
                    });
                });
            }
            else
            {
                // Errore durante l'autenticazione con Google Play
                ShowErrorMessage("Errore durante l'autenticazione con Google Play");
            }
        });
    }

    // Mostra il messaggio di errore e attiva il GameObject testoErrore
    private void ShowErrorMessage(string errorMessage)
    {
        Debug.Log(errorMessage);
        erroreTesto.SetActive(true);
    }
}
