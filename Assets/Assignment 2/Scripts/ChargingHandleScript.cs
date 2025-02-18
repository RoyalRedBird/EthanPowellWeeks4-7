using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargingHandleScript : MonoBehaviour
{

    //My eyes have glazed over, as have my mind and soul.

    [SerializeField] SpriteRenderer chargingHandleSprite; //The sprite of the charging handle.
    [SerializeField] Transform EjectPoint; //The transform of the bolt ejection point.
    [SerializeField] GameObject BoltRound; //Bolt round prefab goes here.

    //The start and end positions of the charging handle.
    Vector2 chargingHandleStartPos;
    Vector2 chargingHandleEndPos;

    bool ShellEjected = false; //Has a shell been ejected?

    bool handleHeld; //Is the charging handle currently being moved around?

    // Start is called before the first frame update
    void Start()
    {
     
        //Sets the start and end position of the charging handle.
        chargingHandleStartPos = transform.position;

        Vector2 endPos = chargingHandleStartPos;
        endPos.x -= 1.8f;

        chargingHandleEndPos = endPos;

    }

    // Update is called once per frame
    void Update()
    {

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //Gets mouse position on the screen.
        Vector2 currentHandlePos = transform.position; //Gets the position of the charging handle.

        if (Input.GetMouseButton(0)) //If LMB is being held down...
        {           

            if (chargingHandleSprite.bounds.Contains(mousePos)) //And the mouse is in the sprite bounds of the charging handle...
            {

                handleHeld = true; //Flag the handle as being held.

                Debug.Log("Rack!");
                currentHandlePos.x = mousePos.x; //Set the position of the charging handle to the position of the mouse.

            }

        }

        if(Input.GetMouseButtonUp(0)) { //If LMB is released...


            handleHeld = false; //Flag the handle as not being held.
            
        }

        if (!handleHeld) //If the charging handle is not being held...
        {

            //Send the charging forward.
            currentHandlePos.x += 0.04f;

        }

        //If the charging handle is fully forward...
        if(currentHandlePos.x >= chargingHandleStartPos.x)
        {

            //Lock the charging handle at its start position, set the slide to idle and reset the ejection bool.
            currentHandlePos.x = chargingHandleStartPos.x;
            ShellEjected = false;
            


        }else if(currentHandlePos.x < chargingHandleEndPos.x) { //If the charging handle has been slid fully back...

            //Keep the charging handle from detatching from the gun.
            currentHandlePos.x = chargingHandleEndPos.x;

            //Run the EjectShell method.
            EjectShell();

        }

        //Apply transform.
        transform.position = currentHandlePos;

    }

    //Ejects a shell prefab from the chamber.
    void EjectShell()
    {

        if (!ShellEjected) //If a shell has not yet been ejected...
        {

            //Instantiate a new bolt round and assign it to the newBolt variable.
            GameObject newBolt = GameObject.Instantiate(BoltRound, EjectPoint);

            //Run the Bolt Physics setup script on the new bolt.
            newBolt.GetComponent<BoltScript>().BoltPhysSetup();

            //Set the shell ejected bool to true.
            ShellEjected = true;

        }

    }

}
