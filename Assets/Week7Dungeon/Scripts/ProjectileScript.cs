using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{

    float projectileXSpeed;
    float projectileYSpeed;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 projPos = transform.position;

        projPos.x += projectileXSpeed;
        projPos.y += projectileYSpeed;

        transform.position = projPos;
        
    }

    public void InitializeProjectile(float xSpeed, float ySpeed)
    {

        projectileXSpeed = xSpeed;
        projectileYSpeed = ySpeed;

    }

}
