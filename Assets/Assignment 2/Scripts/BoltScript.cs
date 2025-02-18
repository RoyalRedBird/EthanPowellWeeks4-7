using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltScript : MonoBehaviour
{

    //The gravity force placed on the bolt.
    float gravity = 0.001f/2;

    //The bolt's X and Y velocity as well as the speed of their rotation.
    float xVelocity;
    float yVelocity;
    float rotationSpeed;

    //Time until the bolt prefab is deleted.
    float killTimer = 3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //Gets the position and eulerAngles of the bolt.
        Vector2 boltPos = transform.position;
        Vector3 boltSpin = transform.eulerAngles;

        //Applies the X and Y velocity to the bolt's position.
        boltPos.x -= xVelocity;
        boltPos.y += yVelocity;

        //Applies the rotation speed to the rotation of the bolt.
        boltSpin.z += rotationSpeed;

        //Decreases the y velocity by the force of gravity.
        yVelocity -= gravity;

        //Apply transformation.
        transform.position = boltPos;
        transform.eulerAngles = boltSpin;

        //Decrement the kill timer.
        killTimer -= Time.deltaTime;

        //If the kill timer reaches zero...
        if(killTimer <= 0)
        {

            //Destroy this game object.
            GameObject.Destroy(gameObject);

        }
        
    }

    //Called by the ChargingHandle script when a bolt round is ejected from the chamber.
    //This function randomizes the x and y velocity of the bolt as well as how fast it spins.
    //Everything is divided by two because unity sped up the physics somehow and it was a quick fix.
    public void BoltPhysSetup()
    {

        xVelocity = (Random.Range(0.01f, 0.04f)) / 2;
        yVelocity = (Random.Range(0.05f, 0.015f)) / 2;

        rotationSpeed = (Random.Range(3f, 8f))/2;

    }

}
