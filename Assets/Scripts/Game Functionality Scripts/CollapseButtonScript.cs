using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CollapseButtonScript : MonoBehaviour
{
    // is the list in the collapsed position?
    public bool isCollapsed = true;

    public Transform image;
    public Transform button;

    // image initial x & y position (hopefully to avoid issues on build)
    float x;
    float y;


    private void Start()
    {
        x = image.position.x;
        y = image.position.y;
        Debug.Log("x: " + x + ", y: " + y);
        image.position = new Vector2(x, y);

        // code so the (x, y) resets properly when a new game is loaded
        SceneManager.sceneLoaded += OnSceneLoad;
    }

    void OnSceneLoad(Scene scene, LoadSceneMode mode)
    {
        image.position = new Vector2(x, y);
        if (!isCollapsed)
        {
            // flips button orientation (point in opposite direction)
            button.localScale = new Vector2(button.localScale.x * -1, button.localScale.y);
            isCollapsed = true;
        }
        
    }

    // runs when button to collapse/expand is clicked
    public void ButtonClickCollapse()
    {
        // flips button orientation (point in opposite direction)
        button.localScale = new Vector2(button.localScale.x * -1, button.localScale.y);
        StartCoroutine(collapse());

        if (isCollapsed)
        {
            isCollapsed = false;
        }
        else
        {
            isCollapsed = true;
        }
    }

    // makes the list show/hide
    private IEnumerator collapse()
    {

        if (isCollapsed)
        {
            for (int i = 0;  i < 90; i++)
            {
                image.position = new Vector2(image.position.x + 5, image.position.y);
                yield return new WaitForSeconds(0.0045f);

            }
            
        }
        else
        {
            for (int i = 0; i < 90; i++)
            {
                image.position = new Vector2(image.position.x - 5, image.position.y);
                
                yield return new WaitForSeconds(0.0045f);
            }
            
        }
        
        
        
    }
}
