using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    // player's transform component
    [SerializeField] private Vector3 playerTransform;

    // player horizontal and vertical speed values (to be used for running/jumping)
    [SerializeField] private int speedX = 100;
    [SerializeField] private int speedY = 100;

    // player rigidbody components
    [SerializeField] private Rigidbody2D rb;

    // floor collider
    [SerializeField] private Collider2D floor;

    public Sprite standSprite;
    public Animator playerAnimator;


    // Start is called before the first frame update
    private void Start()
    {
        // configuration
        playerTransform = new Vector3(0, -2.4f, -2);
        transform.position = playerTransform;
        rb = GetComponent<Rigidbody2D>();

        // player is able to move
        rb.isKinematic = false;
    }

    // Update is called once per frame
    private void Update()
    {
        // move left
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            // if the player can move
            if (!rb.isKinematic)
            {
                // move left and point left
                rb.AddForce(Vector2.left * speedX * Time.deltaTime);
                transform.localScale = new Vector3(-0.7f, transform.localScale.y, transform.localScale.z);


                // animator

                playerAnimator.SetBool("isIdle", false);
                playerAnimator.SetBool("isWalking", true);


            }
            
            
            
        }

        // move right
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            // if the player can move
            if (!rb.isKinematic)
            {
                // move right and point right
                rb.AddForce(Vector2.right * speedX * Time.deltaTime);
                transform.localScale = new Vector3(0.7f, transform.localScale.y, transform.localScale.z);

                // animator
                playerAnimator.SetBool("isIdle", false);
                playerAnimator.SetBool("isWalking", true);

            }
            
            
        }

        // jump
        if (Input.GetKeyDown(KeyCode.Space) && Physics2D.IsTouchingLayers(floor))
        {
            // add force upwards
            rb.AddForce(new Vector2(0, speedY));
            
        }


        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            
             // animator
             playerAnimator.SetBool("isIdle", true);
            playerAnimator.SetBool("isWalking", false);
    

            
            


        }
    }

}
