using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{

    Vector2 triggerStartPos;
    Vector2 triggerPullPos;

    bool depressTrigger = false;

    [SerializeField] SpriteRenderer triggerSprite;

    // Start is called before the first frame update
    void Start()
    {

        triggerStartPos = transform.position;

        Vector2 trigPullPos = transform.position;
        trigPullPos.x -= 0.25f;

        triggerPullPos = trigPullPos;
        
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);       

        if (Input.GetMouseButton(0))
        {

            if(triggerSprite.bounds.Contains(mousePos))
            {

                Debug.Log("Click!");
                depressTrigger = true;
                transform.position = triggerPullPos;

            }

        }
        else
        {

            depressTrigger = false;

        }

        if (depressTrigger)
        {

            transform.position = triggerPullPos;

        }
        else {

            transform.position = triggerStartPos;

        }

    }
}
