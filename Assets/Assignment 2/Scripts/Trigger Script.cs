using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{

    //Start and end position of the trigger.
    Vector2 triggerStartPos;
    Vector2 triggerPullPos;

    //Is the trigger being depressed?
    bool depressTrigger = false;

    //The sprite for the trigger.
    [SerializeField] SpriteRenderer triggerSprite;

    // Start is called before the first frame update
    void Start()
    {

        //Sets the start and end position of the trigger.
        triggerStartPos = transform.position;

        Vector2 trigPullPos = transform.position;
        trigPullPos.x -= 0.25f;

        triggerPullPos = trigPullPos;
        
        
    }

    // Update is called once per frame
    void Update()
    {

        //Gets the mouse position relative to the screen.
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);       

        if (Input.GetMouseButton(0)) //If LMB is held down...
        {

            if(triggerSprite.bounds.Contains(mousePos)) //And the mouse is in the bounds of the trigger sprite.
            {

                //Set the trigger as being depressed.
                Debug.Log("Click!");
                depressTrigger = true;

            }

        }
        else //Otherwise the trigger is not depressed if the mouse is not held down on it.
        {

            depressTrigger = false;

        }

        if (depressTrigger) //Moves the trigger back to its end position if depressed.
        {

            transform.position = triggerPullPos;

        }
        else { //Moves the trigger to its starting position when not being held down.

            transform.position = triggerStartPos;

        }

    }
}
