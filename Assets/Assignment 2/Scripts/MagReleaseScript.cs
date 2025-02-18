using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagReleaseScript : MonoBehaviour
{

    //I AM NO LONGER HUMAN.
    //I AM A WRETCHED FAE CREATURE.
    
    //The start and end position of the mag release.
    Vector2 releaseStartPos;
    Vector2 releaseEndPos;

    bool releaseInUse = false; //Is the release in use and the mag currently being swapped?
    bool releaseFullDown = false; //Is the release fully down?

    bool releaseGoingDown = false; //Is the release going down?
    bool releaseGoingUp = false; //Is the release going up?

    bool releaseKickoff = false; //Has the mag release process been started?

    float resetTimer = 1.1f; //Time until the release goes back up.

    [SerializeField] MagazineScript magScript; //The magazine script, used to start the reloading process for the mag.

    [SerializeField] SpriteRenderer magReleaseSprite; //The sprite of the mag release.

    // Start is called before the first frame update
    void Start()
    {

        //Sets the start and end pos of the mag release animation.
        releaseStartPos = transform.position;
        Vector2 endPos = transform.position;

        endPos.y = releaseEndPos.y - 0.7f;

        releaseEndPos = endPos;
        
    }

    // Update is called once per frame
    void Update()
    {

        //Gets the mouse position relative to the screen.
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //If LMB has been clicked.
        if(Input.GetMouseButtonDown(0))
        {

            //And the mouse is within the bounds of the sprite...
            if (magReleaseSprite.bounds.Contains(mousePos))
            {

                //And the mag release currently isn't being used...
                if(!releaseInUse)
                {

                    //Start the mag release animation and start the reloading sequence for the magazine.
                    releaseInUse = true;

                    Debug.Log("Slide!");
                    magScript.StartMagSwap();

                }           

            }

        }

        if(releaseInUse) //If the release is in use...
        {

            CycleSlideRelease(); //Run the animation.

        }
        else //Otherwise keep the mag release in its starting position.
        {

            transform.position = releaseStartPos;

        }

    }

    //Runs the animation.
    public void CycleSlideRelease()
    {

        //Gets the current position of the mag release.
        Vector2 currentSlidePos = transform.position;

        //If the animation hasn't been kicked off...
        if (!releaseKickoff)
        {

            //Send the release down and flag the animation as having started.
            releaseGoingDown = true;
            releaseKickoff = true;

        }

        //If the release is going down...
        if (releaseGoingDown)
        {

            //Decrement the y pos.
            currentSlidePos.y -= 0.01f;

        }

        //If the release is going down and has reached the end pos...
        if (releaseGoingDown && (currentSlidePos.y <= releaseEndPos.y))
        {

            //Flag the release as having gone fully down and no longer going down.
            releaseGoingDown = false;
            releaseFullDown = true;

        }

        //If the release is fully down...
        if (releaseFullDown)
        {

            //Decrement the reset timer by delta time.
            resetTimer -= Time.deltaTime;

        }

        //If the reset timer is out...
        if (resetTimer <= 0)
        {

            //Send the release up and flag it as no longer fully down.
            releaseGoingUp = true;
            releaseFullDown = false;

        }

        //If the release is going up.
        if (releaseGoingUp)
        {

            //Inmcrement y position.
            currentSlidePos.y += 0.01f;

        }      

        //If the release has made it back to the starting position...
        if (releaseGoingUp && (currentSlidePos.y >= releaseStartPos.y))
        {

            //Reset all the flags to prepare for the next time the mag release is pressed.
            releaseGoingUp = false;
            releaseInUse = false;
            releaseKickoff = false;

            resetTimer = 1.1f;

            Debug.Log("Mag release is ready.");

        }

        //Apply transform.
        transform.position = currentSlidePos;

    }

}
