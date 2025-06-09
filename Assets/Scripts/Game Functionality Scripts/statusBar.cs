using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class statusBar : MonoBehaviour
{
    // status bar transforms
    [SerializeField] private Transform bar1;
    [SerializeField] private Transform bar2;

    public int stressLevel = 0;
    public int productivityLevel = 500;

    // is the coroutine currently running to update stress/productivity levels over time?
    bool isRunning = false;

    public GameObject chair;
    public GameObject handSanitizer;

    public InteractScript interaction;
    public YouLoseScript loseScript;

    // speed to update the status bars
    public int speedFactor = 1;

    // is there an absence of interactable objects in the scene (excluding doors)?
    bool isInteractionNull;

    // Start is called before the first frame update
    private void Start()
    {

        StopAllCoroutines();
        loseScript = (YouLoseScript)FindObjectOfType(typeof(YouLoseScript));

        // this check occurs on the first classroom/cafeteria (depending on setup) scene load ONLY
        chair = GameObject.FindWithTag("Chair");
        handSanitizer = GameObject.FindWithTag("Sanitizer");

        // checking if there are interactables in the scene (excluding doors)
        if (chair == null && handSanitizer == null)
        {
            interaction = null;
            isInteractionNull = true;
        }
        else if(chair == null)
        {
            interaction = handSanitizer.GetComponent<InteractScript>();
            isInteractionNull = false;

        } else if(handSanitizer == null)
        {
            interaction = chair.GetComponent<InteractScript>();
            isInteractionNull = false;

        }

        // the OnSceneLoaded method is subscribed to the sceneLoaded, so it runs whenever a new scene is loaded
        SceneManager.sceneLoaded += OnSceneLoad;

        
    }

    // method to check if there are interactables in the scene (excluding doors) and initialize certain variables whose instances vary by scene
    void OnSceneLoad(Scene scene, LoadSceneMode mode)
    {
        loseScript = (YouLoseScript)FindObjectOfType(typeof(YouLoseScript));

        chair = GameObject.FindWithTag("Chair");
        handSanitizer = GameObject.FindWithTag("Sanitizer");
        if (chair == null && handSanitizer == null)
        {
            interaction = null;
            isInteractionNull = true;
        }
        else if (chair == null)
        {
            interaction = handSanitizer.GetComponent<InteractScript>();
            isInteractionNull = false;

        }
        else if (handSanitizer == null)
        {
            interaction = chair.GetComponent<InteractScript>();
            isInteractionNull = false;

        }

     
    }

    // FixedUpdate runs on set time intervals (rather than on every frame update like Update)
    void FixedUpdate()
    {
        if(!isRunning)
        {
            StartCoroutine(Wait());
        }

    }

    // method to update status bars over time, also based on the current interactions (if any), and the speed factor (increases w/ time so they update faster and faster)
    IEnumerator Wait()
    {
        isRunning = true;

        // if the game is still going/player hasn't lost yet
        if (!loseScript.lost)
        {
            if (bar1.localScale.x < 1 && isInteractionNull == true)
            {
                bar1.localScale = new Vector2(bar1.localScale.x + 0.01f, bar1.localScale.y);
                bar1.localPosition = new Vector2(bar1.localPosition.x - 0.15f, bar1.localPosition.y);

                stressLevel += 5;

            }

            if (bar2.localScale.x > 0.01 && isInteractionNull == true)
            {
                bar2.localScale = new Vector2(bar2.localScale.x - 0.01f, bar2.localScale.y);
                bar2.localPosition = new Vector2(bar2.localPosition.x + 0.15f, bar2.localPosition.y);
                productivityLevel -= 5;

            }

            if (interaction != null)
            {
                if (bar2.localScale.x > 0.01 && interaction.isSittingInChair == false)
                {
                    bar2.localScale = new Vector2(bar2.localScale.x - 0.01f, bar2.localScale.y);
                    bar2.localPosition = new Vector2(bar2.localPosition.x + 0.15f, bar2.localPosition.y);
                    productivityLevel -= 5;

                }


                if (bar2.localScale.x < 1 && interaction.isSittingInChair == true)
                {
                    bar2.localScale = new Vector2(bar2.localScale.x + 0.01f, bar2.localScale.y);
                    bar2.localPosition = new Vector2(bar2.localPosition.x - 0.15f, bar2.localPosition.y);
                    productivityLevel += 5;

                }

                if (bar1.localScale.x > 0.01 && interaction.isHandSanitizing == true)
                {
                    bar1.localScale = new Vector2(bar1.localScale.x - 0.01f, bar1.localScale.y);
                    bar1.localPosition = new Vector2(bar1.localPosition.x + 0.15f, bar1.localPosition.y);

                    stressLevel -= 5;

                }

                if (bar1.localScale.x < 1 && interaction.isHandSanitizing == false)
                {
                    bar1.localScale = new Vector2(bar1.localScale.x + 0.01f, bar1.localScale.y);
                    bar1.localPosition = new Vector2(bar1.localPosition.x - 0.15f, bar1.localPosition.y);

                    stressLevel += 5;

                }
            }
        }

        yield return new WaitForSeconds(0.5f / speedFactor);
        isRunning = false;
    }
}
