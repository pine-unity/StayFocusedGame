using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowTime : MonoBehaviour
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
        // show the final time if the game is lost
        if (loseScript.lost)
        {
            GetComponent<TMP_Text>().text = timer.returnText;
     
        }
    }
}
