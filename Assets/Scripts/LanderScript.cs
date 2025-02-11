using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanderScript : MonoBehaviour
{

    float fuel = 100;
    float thrustForce = 2;
    float gravityForce = 3;

    GameObject lander;

    float landerRotation;
    float rotationSpeed;

    Transform leftLeg;
    Transform rightLeg;

    Transform landerTopLeft;
    Transform landerTopRight;
    Transform landerBottom;

    bool engineActive = false;
    Vector2 landerPosition;
    Vector2 landerSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.A))
        {

            landerRotation += rotationSpeed;

            if(landerRotation > 90)
            {

                landerRotation = 90;

            }

        }else if (Input.GetKey(KeyCode.D))
        {

            landerRotation -= rotationSpeed;

            if (landerRotation < -90)
            {

                landerRotation = -90;

            }

        }

        Vector2 landerPosWorking = landerPosition;

        

        landerPosition += landerSpeed;
        
    }
}
