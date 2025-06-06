using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowBestTime : MonoBehaviour
{
    public YouLoseScript loseScript;
    public Timer timer;

    // Start is called before the first frame update
    private void Start()
    {
        loseScript = (YouLoseScript)FindObjectOfType(typeof(YouLoseScript));
    }

    // Update is called once per frame
    private void Update()
    {
        // show the all-time best time if the game is lost
        if (loseScript.lost)
        {
            int bestMin = PlayerPrefs.GetInt("Minute");
            int bestSecond = PlayerPrefs.GetInt("Second");

            // code to show the time in the UI
            string minuteString = bestMin < 10 ? "0" + bestMin : bestMin + "";
            string secondString = bestSecond < 10 ? "0" + bestSecond : bestSecond + "";
            
            GetComponent<TMP_Text>().text = "" + minuteString + ":" + secondString;
            


        }
    }
}
