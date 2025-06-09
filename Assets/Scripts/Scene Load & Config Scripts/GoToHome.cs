using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToHome : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        // loads home screen/main menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }
}
