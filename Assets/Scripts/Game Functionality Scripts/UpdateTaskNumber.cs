using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UpdateTaskNumber : MonoBehaviour
{
    [SerializeField] private ListManager listManager;

    // Update is called once per frame
    void Update()
    {
        // updates number of tasks to be completed in the text
        GetComponent<TMP_Text>().text = "Number of tasks: " + listManager.numTasks;
    }
}
