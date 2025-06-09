using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    // current minute and second
    public int minute = 0;
    public int second = 0;

    // boolean to check if the coroutine is currently running now
    bool isRunning = false;

    // text to show minutes and seconds
    public string returnText;
    string minuteString;
    string secondString;

    [SerializeField] YouLoseScript loseScript;
    [SerializeField] statusBar statusBarScript;


    // Start is called before the first frame update
    private void Start()
    {
        Debug.Log("Best minute start: " + PlayerPrefs.GetInt("Minute"));
        Debug.Log("Best second start: " + PlayerPrefs.GetInt("Second"));

        loseScript = (YouLoseScript) FindObjectOfType(typeof(YouLoseScript));
        statusBarScript = (statusBar)FindObjectOfType(typeof(statusBar));
    }

    // Update is called once per frame
    private void Update()
    {

        // if no coroutine is in progress and the game is still going, start coroutine to count
        if (!isRunning && !loseScript.lost)
        {
            StartCoroutine(countBySecond());
        }

        // stop counting when the game is lost
        if (loseScript.lost)
        {
            StopAllCoroutines();
            isRunning = false;
            minute = 0;
            second = 0;

        }

        // add a minute at 60 seconds and start the next minute
        if (second > 59)
        {
            second = 0;
            minute++;
        }

        // code to show the time in the UI
        minuteString = minute < 10 ? "0" + minute : minute + "";
        secondString = second < 10 ? "0" + second : second + "";

        if (!loseScript.lost)
        {
            // update text
            returnText = "" + minuteString + ":" + secondString;
            GetComponent<TMP_Text>().text = returnText;
        }

    }

    // count up by 1 second
    IEnumerator countBySecond()
    {
        isRunning = true;
        yield return new WaitForSeconds(1f);
        second++;

        // make stats go down/up faster every ten seconds, to add challenge
        if (second % 10 == 0 && second != 0)
        {
            statusBarScript.speedFactor++;
            Debug.Log("Speed factor has been increased to " + statusBarScript.speedFactor);
        }


        isRunning = false;
    }


}
