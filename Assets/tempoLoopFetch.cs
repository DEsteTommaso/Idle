using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using UnityEngine.Networking;
using System;

public class tempoLoopFetch : MonoBehaviour
{
    // Start is called before the first frame update
    singleton singleton;
    void Start()
    {
        singleton = singleton.Instance;
        StartCoroutine(GetRealDateTimeFromAPI());
    }


    struct TimeData
    {

        public string datetime;

    }

    IEnumerator GetRealDateTimeFromAPI()
    {
        while (true)
        {

            UnityWebRequest webRequest = UnityWebRequest.Get("https://worldtimeapi.org/api/ip");

            yield return webRequest.SendWebRequest();

            if (webRequest.isNetworkError)
            {
                Debug.Log("Fetch data error");
            }
            else
            {
                TimeData timeData = JsonUtility.FromJson<TimeData>(webRequest.downloadHandler.text);

                //conversione
                string date = Regex.Match(timeData.datetime, @"^\d{4}-\d{2}-\d{2}").Value;
                string time = Regex.Match(timeData.datetime, @"\d{2}:\d{2}:\d{2}").Value;


                Debug.Log("Data: " + date);
                Debug.Log("Time: " + time);

                string dataString = string.Format("{0} {1}", date, time);

                singleton.UltimoAccesso = dataString;
            }
            Debug.Log("Fetch data");
            yield return new WaitForSeconds(60f);
        }

    }
}
