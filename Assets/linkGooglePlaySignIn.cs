using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class linkGooglePlaySignIn : MonoBehaviour
{
    private string url = "https://support.google.com/googleplay/answer/9140426?hl=en";

    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OpenLink);
    }

    private void OpenLink()
    {
        Application.OpenURL(url);
    }

}
