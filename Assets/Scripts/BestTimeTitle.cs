using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BestTimeTitle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // shows best time all the time
        int bestMin = PlayerPrefs.GetInt("BESTMIN");
        int bestSecond = PlayerPrefs.GetInt("BESTSEC");

        // code to show the time in the UI
        string minuteString = bestMin < 10 ? "0" + bestMin : bestMin + "";
        string secondString = bestSecond < 10 ? "0" + bestSecond : bestSecond + "";

        GetComponent<TMP_Text>().text = "" + minuteString + ":" + secondString;
    }

}
