using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollapseButtonScript : MonoBehaviour
{
    // is the list in the collapsed position?
    public bool isCollapsed = true;

    public Transform image;
    public Transform button;

    public int initialX;


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

        initialX = (int)image.position.x;
    }

    // makes the list show/hide
    private IEnumerator collapse()
    {

        if (isCollapsed)
        {
            for (int i = 0;  i < 90; i++)
            {
                image.position = new Vector2(image.position.x + 5, image.position.y);
                yield return new WaitForSeconds(0.005f);

            }
            
        }
        else
        {
            for (int i = 0; i < 90; i++)
            {
                image.position = new Vector2(image.position.x - 5, image.position.y);
                
                yield return new WaitForSeconds(0.005f);
            }
            
        }
        
        
        
    }
}
