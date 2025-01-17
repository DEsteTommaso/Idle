using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pulsantiArmi : MonoBehaviour
{
    public GameObject[] oggetti;
    public Button pulsanteSX;
    public Button pulsanteDX;

    private int num = 0;
    // Start is called before the first frame update
    void Start()
    {
        pulsanteSX.onClick.AddListener(HandleButtonClickSX);
        pulsanteDX.onClick.AddListener(HandleButtonClickDX);
        oggetti[0].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void HandleButtonClickSX()
    {
        num -= 1;
        if (num < 0)
            num = 4;

        foreach (var item in oggetti)
        {
            item.SetActive(false);
        }

        switch (num)
        {
            case 0:
                oggetti[0].SetActive(true);
                break;

            case 1:
                oggetti[1].SetActive(true);
                break;

            case 2:
                oggetti[2].SetActive(true);
                break;

            case 3:
                oggetti[3].SetActive(true);
                break;

            case 4:
                oggetti[4].SetActive(true);
                break;

            default:

                break;
        }
    }

    private void HandleButtonClickDX()
    {

        num += 1;
        if (num > 4)
            num = 0;

        foreach (var item in oggetti)
        {
            item.SetActive(false);
        }

        switch (num)
        {
            case 0:
                oggetti[0].SetActive(true);
                break;

            case 1:
                oggetti[1].SetActive(true);
                break;

            case 2:
                oggetti[2].SetActive(true);
                break;

            case 3:
                oggetti[3].SetActive(true);
                break;

            case 4:
                oggetti[4].SetActive(true);
                break;

            default:

                break;
        }
    }
}
