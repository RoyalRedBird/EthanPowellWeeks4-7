using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltScript : MonoBehaviour
{

    Vector2 boltDirection;

    float gravity = 0.1f;

    float xVelocity;
    float yVelocity;
    float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 boltPos = transform.position;
        Vector3 boltSpin = transform.eulerAngles;

        boltPos.x -= xVelocity;
        boltPos.y += yVelocity;

        boltSpin.z += rotationSpeed;

        yVelocity -= gravity;

        transform.position = boltPos;
        transform.eulerAngles = boltSpin;
        
    }

    public void BoltPhysSetup()
    {

        xVelocity = Random.Range(0.1f, 0.9f);
        yVelocity = Random.Range(1f, 2f);

        rotationSpeed = Random.Range(20f, 30f);

    }

}
