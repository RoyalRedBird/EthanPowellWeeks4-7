using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargingHandleScript : MonoBehaviour
{

    [SerializeField] SpriteRenderer chargingHandleSprite;

    Vector2 chargingHandleStartPos;
    Vector2 chargingHandleEndPos;

    bool SlideFullBack;
    bool SlideIdle;

    bool handleHeld;

    [SerializeField] AnimationCurve handleResetSpeed;
    float resetSpeedTimer;

    // Start is called before the first frame update
    void Start()
    {
        
        chargingHandleStartPos = transform.position;

        Vector2 endPos = chargingHandleStartPos;
        endPos.x -= 1.8f;

        chargingHandleEndPos = endPos;

    }

    // Update is called once per frame
    void Update()
    {

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 currentHandlePos = transform.position;

        if (Input.GetMouseButton(0))
        {

            resetSpeedTimer = 0;
            handleHeld = true;

            if (chargingHandleSprite.bounds.Contains(mousePos))
            {

                Debug.Log("Rack!");
                currentHandlePos.x = mousePos.x;

            }

        }

        if(Input.GetMouseButtonUp(0)) {

            //currentHandlePos.x = chargingHandleStartPos.x;

            handleHeld = false;
            
        }

        if (!handleHeld)
        {

            currentHandlePos.x += 0.04f;

        }

        if(currentHandlePos.x >= chargingHandleStartPos.x)
        {

            currentHandlePos.x = chargingHandleStartPos.x;
            SlideIdle = true;
            SlideFullBack = false;


        }else if(currentHandlePos.x < chargingHandleEndPos.x) {

            currentHandlePos.x = chargingHandleEndPos.x;
            SlideIdle = false;
            SlideFullBack = true;

        }

        transform.position = currentHandlePos;

    }
}
