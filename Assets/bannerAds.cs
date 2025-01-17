using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bannerAds : MonoBehaviour
{
    public GameObject pannello;
    private bool isPanelActive = false;
    private float nextAppearanceTime;
    private float panelDisplayDuration = 10f;
    private float timeBetweenAppearances; 
    public Animator animazione;
    singleton singleton;

    // Start is called before the first frame update
    void Start()
    {
        singleton = singleton.Instance;
        timeBetweenAppearances = Random.Range(120f, 180f);         // Tra 2 e 3 minuti
        nextAppearanceTime = Time.time + timeBetweenAppearances;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPanelActive && Time.time >= nextAppearanceTime)
        {
            if (!singleton.Ads1 && !singleton.Ads2 && !singleton.Ads3)
            {
                pannello.SetActive(true);
                isPanelActive = true;
                StartCoroutine(HidePanelAfterDuration());
            }
        }
    }

    IEnumerator HidePanelAfterDuration()
    {
        yield return new WaitForSeconds(panelDisplayDuration);
        animazione.Play("ads banner close");
        yield return new WaitForSeconds(1f);
        pannello.SetActive(false);
        isPanelActive = false;
        nextAppearanceTime = Time.time + Random.Range(120f, 180f); // Calcola il prossimo intervallo di tempo
    }
}
