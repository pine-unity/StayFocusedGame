using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ListManager : MonoBehaviour
{
    public statusBar statusBarScript;
    public YouLoseScript loseScript;

    // number to show index
    public int current = 1;

    // tasks to do
    List<string> list = new List<string>();

    // two trigger variables in order for tasks to only be added ONE time to the list
    public bool trigger1 = false;
    public bool trigger2 = false;

    // text to show the list of tasks to do
    string textStr = "";

    public int numTasks = 0;
    
    // Start is called before the first frame update
    private void Start()
    {
        StopAllCoroutines();
        statusBarScript = (statusBar)FindObjectOfType(typeof(statusBar));
        loseScript = (YouLoseScript)FindObjectOfType(typeof(YouLoseScript));

    }

    // Update is called once per frame
    private void Update()
    {
        // check if productivity level is too low and should be on the list as a task to address
        if (statusBarScript.productivityLevel < 250)
        {
            if (!trigger1)
            {
                list.Add("Sit in the desk and pay attention! (Classroom)");
                trigger1 = true;
                numTasks++;
                updateText();
                
            }
            
        } else
        {
            if (list.Contains("Sit in the desk and pay attention! (Classroom)"))
            {
                list.Remove("Sit in the desk and pay attention! (Classroom)");
                trigger1 = false;
                numTasks--;
                updateText();
            }
            
        }

        // check if stress level is too high and should be on the list as a task to address
        if (statusBarScript.stressLevel > 250)
        {
            if (!trigger2)
            {
                list.Add("Use hand sanitizer! (Cafeteria)");
                trigger2 = true;
                numTasks++;
                updateText();
                
            }
            
        } else
        {
            if (list.Contains("Use hand sanitizer! (Cafeteria)"))
            {
                list.Remove("Use hand sanitizer! (Cafeteria)");
                trigger2 = false;
                numTasks--;
                updateText();
                
            }
            
        }

        // set text in UI
        GetComponent<TMP_Text>().text = textStr;

        if (loseScript.trigger)
        {
            list.Clear();
            updateText();
        }
    }

    // update the text in the list to be shown in the UI
    void updateText()
    {
        textStr = "";
        current = 1;
        for(int i = 0; i < list.Count; i++)
        {
            textStr += "\n" + current + ". " + list[i];
            current++;
        }
    }
}
