using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MagazineScript : MonoBehaviour
{

    //The GameObjects for the three magTypes.
    [SerializeField] GameObject stalkerMag;
    [SerializeField] GameObject autoMag;
    [SerializeField] GameObject rifleMag;

    //The start and end positions for the magazine swapping animation.
    Vector2 magStartPoint;
    Vector2 magEndPoint;

    //Set to true whenever the magazine is being swapped.
    bool swappingMag = false;

    bool magFullDown = false; //Set to true when the mag has reached magEndPoint.
    bool magGoingUp = false; //Set to true when the mag is going up from the magEndPoint.

    float waitTimer = 1.0f; //The delay between the mag hitting the end point and going back up.

    int activeMag = 0; //The active mag being used.
    [SerializeField] [Range(0,2)] int newMag = 0; //The new mag being swapped in, used alongside the drop down.

    // Start is called before the first frame update
    void Start()
    {

        //Sets the start point of the mag as the current position on start.
        //Sets the end point of the mag animation as 6 units below the start point.
        magStartPoint = transform.position;

        Vector2 endPoint = transform.position;
        endPoint.y -= 6f;

        magEndPoint = endPoint;
        
    }

    // Update is called once per frame
    void Update()
    {

        //If the magazine is being swapped...
        if(swappingMag)
        {

            SwappingCurrentMag(); //Do the animation.

        }
        
    }

    //Starts the mag swapping sequence.
    public void StartMagSwap()
    {

        swappingMag = true;

    }

    //Sets the newMag to the selected option in the drop down menu and starts the mag swap.
    public void SwitchMag(int mag)
    {

        newMag = mag;
        StartMagSwap();

    }

    //Goes through the sequence of swapping the current mag.
    void SwappingCurrentMag()
    {

        //Gets the current position of the magazine.
        Vector2 magPos = transform.position;

        if(!magFullDown && (magPos.y > magEndPoint.y)) { //If the mag has not reached or started at the bottom...

            magPos.y -= 0.075f; //Send the mag down.
        
        }

        if (magPos.y <= magEndPoint.y) //When the mag gets to the end point...
        {

            magFullDown = true; //Flag the mag as being fully down.

        }

        if(magFullDown) { //If the mag is fully down...
        
            waitTimer -= Time.deltaTime; //Start the wait timer.
        
        }

        if(waitTimer <= 0) //When the wait timer is over...
        {

            SwitchMagType(); //Switch the mag type or reload if the mag is the same.
            magGoingUp = true; //Set the mag as going up.

        }

        if (magGoingUp) //If the mag is set as going up...
        {

            magPos.y += 0.075f; //The mag goes up.

        }

        if(magGoingUp && magPos.y >= magStartPoint.y) //If the mag makes it back to its starting point...
        {

            //Set the mag pos to the start pos and reset everything for the next time.
            magPos.y = magStartPoint.y;
            swappingMag = false;
            magGoingUp = false;
            magFullDown = false;
            waitTimer = 1.0f;

        }

        //Apply transform.
        transform.position = magPos;

    }

    //Toggles which mag type is visible depending on which one has been selected.
    //0 for the rifle mag, 1 for the Stalker mag, 2 for the Auto mag.
    void SwitchMagType()
    {

        if(newMag == 0)
        {

            stalkerMag.SetActive(false);
            autoMag.SetActive(false);
            rifleMag.SetActive(true);

        }

        if (newMag == 1)
        {

            stalkerMag.SetActive(true);
            autoMag.SetActive(false);
            rifleMag.SetActive(false);

        }

        if (newMag == 2)
        {

            stalkerMag.SetActive(false);
            autoMag.SetActive(true);
            rifleMag.SetActive(false);

        }

    }

}
