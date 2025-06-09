using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class YouLoseScript : MonoBehaviour
{
    // bool to check whether the game has lost yet currently
    public bool lost;

    // player stats
    int productivity;
    int stress;

    // references
    [SerializeField] private statusBar statusScript;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject loseText;
    [SerializeField] private Transform playerTransform;
    public Transform bar1;
    public Transform bar2;
    [SerializeField] private GameObject timerText;
    Timer timer;

    // bool meant to make sure needed actions aren't taken more than once (e.g. restarting the game)
    public bool trigger;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    private void Start()
    {

        trigger = false;

        // first scene load ONLY
        rb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();

        bar1 = GameObject.FindGameObjectWithTag("Bar1").GetComponent<Transform>();
        bar2 = GameObject.FindGameObjectWithTag("Bar2").GetComponent<Transform>();

        // subscribes OnSceneLoaded so it gets called when event happens
        SceneManager.sceneLoaded += OnSceneLoaded;

        // the game hasn't lost yet
        lost = false;

        loseText = GameObject.FindWithTag("LoseTextParent");
        statusScript = (statusBar) FindObjectOfType(typeof(statusBar));
        timer = (Timer)FindObjectOfType(typeof(Timer));

        loseText.SetActive(false);


        timerText = GameObject.FindWithTag("TimerText");


    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // find player's rigidbody in current scene
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if(player != null)
        {
            rb = player.GetComponent<Rigidbody2D>();
        }
        
        
        
    }

    // Update is called once per frame
    private void Update()
    {
        productivity = statusScript.productivityLevel;
        stress = statusScript.stressLevel;

        // if productivity is too low or stress is too high, end the game, disallow player movement
        if (productivity == 0 || stress == 500)
        {
            loseText.SetActive(true);
            rb.isKinematic = true;
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0;
            lost = true;
        }

        // restarts game
        if(lost && Input.GetKeyDown(KeyCode.Return))
        {
            productivity = 500;
            stress = 0;
            trigger = true;
            statusScript.productivityLevel = 500;
            statusScript.stressLevel = 0;
            statusScript.speedFactor = 1;
            bar2.localScale = new Vector2(1, 1);
            bar1.localScale = new Vector2(0.01f, 1);
            bar1.localPosition = new Vector2(-35.26f, -35.15f);
            bar2.localPosition = new Vector2(-50f, -50.09f);
            lost = false;

         
            SceneManager.LoadScene(1);
            trigger = false;
            loseText.SetActive(false);
            timerText.GetComponent<TMP_Text>().text = "00:00";



        }

        // save highest score/time
        if (lost)
        {
            int bestMin = PlayerPrefs.GetInt("Minute");
            int bestSecond = PlayerPrefs.GetInt("Second");
            if ((timer.minute > bestMin) || (timer.second >= bestSecond && timer.minute == bestMin))
            {
               
                PlayerPrefs.SetInt("Minute", timer.minute);
                PlayerPrefs.SetInt("Second", timer.second);
                PlayerPrefs.Save();

                Debug.Log("Best minute after save: " + PlayerPrefs.GetInt("Minute"));
                Debug.Log("Best second after save: " + PlayerPrefs.GetInt("Second"));
                   
            }
        }


    }

}
