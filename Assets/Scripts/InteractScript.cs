using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractScript : MonoBehaviour
{
    // transform of player
    [SerializeField] private Transform player;

    [SerializeField] private Transform lookAt;

    // transform of this interactable object (door, chair, hand sanitizer)
    private Transform thisTrn;

    // player rigidbody
    [SerializeField] private Rigidbody2D rb;

    // layer of this interactable object
    [SerializeField] int layer;

    public bool isSittingInChair = false;
    public bool isHandSanitizing = false;

    public YouLoseScript loseScript;
    public GameObject eventManager;


    public Animator playerAnimator;

    // Start is called before the first frame update
    private void Start()
    {
        // configuration
        thisTrn = GetComponent<Transform>();
        layer = gameObject.layer;
        eventManager = GameObject.FindWithTag("EventManager");
        loseScript = eventManager.GetComponent<YouLoseScript>();
       
    }

    // Update is called once per frame
    private void Update()
    {
        if (layer == 8)
        {
            // this happens if this object is the chair
            if (Input.GetKeyDown(KeyCode.E) && Vector2.Distance(player.position, thisTrn.position) <= 5f && !isSittingInChair && !loseScript.lost)
            {
                // position player, lock player position
                Debug.Log("Chair interaction");
                rb.isKinematic = true;
                rb.velocity = Vector2.zero;
                rb.angularVelocity = 0;


                playerAnimator.SetBool("isWalking", false);
                playerAnimator.SetBool("isSitting", true);
                playerAnimator.SetBool("isIdle", false);

                player.position = new Vector3(2.33f, -1.95f, -3);

                player.localScale = new Vector3(0.7f, player.localScale.y, player.localScale.z);
                
                isSittingInChair = true;

            }

            if (isSittingInChair && Input.GetKeyDown(KeyCode.R) && !loseScript.lost)
            {
                // unlock player position, exit interaction
                rb.isKinematic = false;
                isSittingInChair = false;

                playerAnimator.SetBool("isSitting", false);
                playerAnimator.SetBool("isIdle", true);

                player.position = new Vector3(6.5f, player.position.y, -3);

             

            }
        } else if (layer == 7)
        {
            // this happens if this object is a door
            if (Input.GetKeyDown(KeyCode.E) && Vector2.Distance(player.position, thisTrn.position) <= 5f && !loseScript.lost)
            {
                Scene current = SceneManager.GetActiveScene();
                Debug.Log("Door interaction");

                // load either cafeteria or classroom scene depending on the current scene
                if (current.buildIndex == 1)
                {
                    SceneManager.LoadScene(2);
                } else
                {
                    SceneManager.LoadScene(1);
                }
                
                

            }
        } else
        {
            // this happens if this object is the hand sanitizer dispenser
            if (Input.GetKeyDown(KeyCode.E) && Vector2.Distance(player.position, thisTrn.position) <= 3f && !isHandSanitizing && !loseScript.lost)
            {
                // position player, lock player position
                Debug.Log("Stress reducer interaction");
                rb.isKinematic = true;
                rb.velocity = Vector2.zero;
                rb.angularVelocity = 0;
                player.position = new Vector3(6.67f, -3.22f, -3);
                player.localScale = new Vector3(0.7f, player.localScale.y, player.localScale.z);
                isHandSanitizing = true;

                // animator
                playerAnimator.SetBool("isIdle", true);

            }

            if (isHandSanitizing && Input.GetKeyDown(KeyCode.R) && !loseScript.lost)
            {
                // unlock player position, exit interaction
                rb.isKinematic = false;
                isHandSanitizing = false;
                player.position = new Vector3(6.5f, player.position.y, -3);

            }
        }
        
    }
}

