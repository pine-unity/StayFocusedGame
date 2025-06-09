using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// show best time in title screen
public class BestTimeTitle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // shows best time all the time
        int bestMin = PlayerPrefs.GetInt("Minute");
        int bestSecond = PlayerPrefs.GetInt("Second");

        // code to show the time in the UI
        string minuteString = bestMin < 10 ? "0" + bestMin : bestMin + "";
        string secondString = bestSecond < 10 ? "0" + bestSecond : bestSecond + "";

        GetComponent<TMP_Text>().text = "" + minuteString + ":" + secondString;
    }

}
