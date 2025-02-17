using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltScript : MonoBehaviour
{

    Vector2 boltDirection;

    float gravity = 0.001f/2;

    float xVelocity;
    float yVelocity;
    float rotationSpeed;

    float killTimer = 3f;

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

        killTimer -= Time.deltaTime;

        if(killTimer <= 0)
        {

            GameObject.Destroy(gameObject);

        }
        
    }

    public void BoltPhysSetup()
    {

        xVelocity = (Random.Range(0.01f, 0.04f)) / 2;
        yVelocity = (Random.Range(0.05f, 0.015f)) / 2;

        rotationSpeed = (Random.Range(3f, 8f))/2;

    }

}
