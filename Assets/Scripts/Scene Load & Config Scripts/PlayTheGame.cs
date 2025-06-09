using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayTheGame : MonoBehaviour
{
    // load the desired scene (to be used on a button press)
    public void LoadScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }
}
