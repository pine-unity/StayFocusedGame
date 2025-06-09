using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagementScript : MonoBehaviour
{
    [SerializeField] private GameObject prefabCanvas;
    [SerializeField] private GameObject prefabEvent;
    [SerializeField] private GameObject canvasCheck;
    [SerializeField] private GameObject eventCheck;
    
    private void Awake()
    {
        // makes sure the Canvas and EventSystem (needed for UI) only show up one time when scene is loaded (no duplicates from DontDestroyOnLoad)
        canvasCheck = GameObject.FindGameObjectWithTag("Canvas");
        eventCheck = GameObject.FindGameObjectWithTag("EventManager");

        // if no instances of the Canvas and EventSystem in the current scene, instantiate them
        if(canvasCheck == null && eventCheck == null)
        {
            Instantiate(prefabCanvas);
            Instantiate(prefabEvent);
        }
        

    }

}
