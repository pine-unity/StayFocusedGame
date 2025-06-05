using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMoveCam : MonoBehaviour
{
    // is the camera supposed to be moving right?
    bool isMovingRight = true;


    // Start is called before the first frame update
    void Start()
    {
        isMovingRight = true;
    }

    // FixedUpdate runs on set time intervals (rather than on every frame update like Update)
    void FixedUpdate()
    {
        if (isMovingRight)
        {
            // move to the right
            transform.position = new Vector3(transform.position.x + 0.01f, transform.position.y, transform.position.z);
        } else
        {
            // move to the left
            transform.position = new Vector3(transform.position.x - 0.01f, transform.position.y, transform.position.z);
        }

        // if camera reaches left bound
        if (transform.position.x <= -3226.06f)
        {
            isMovingRight = true;

            // if camera reaches right bound
        } else if (transform.position.x >= -3195.27f)
        {
            isMovingRight = false;
        }
    }
}
