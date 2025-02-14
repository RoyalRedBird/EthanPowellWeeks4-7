using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagReleaseScript : MonoBehaviour
{

    Vector2 releaseStartPos;
    Vector2 releaseEndPos;

    bool releaseInUse = false;
    bool releaseFullDown = false;

    bool releaseGoingDown = false;
    bool releaseGoingUp = false;

    bool releaseKickoff = false;

    float resetTimer = 1.1f;

    [SerializeField] MagazineScript magScript;

    [SerializeField] SpriteRenderer magReleaseSprite;

    // Start is called before the first frame update
    void Start()
    {

        releaseStartPos = transform.position;
        Vector2 endPos = transform.position;

        endPos.y = releaseEndPos.y - 0.7f;

        releaseEndPos = endPos;
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if(Input.GetMouseButtonDown(0))
        {

            if (magReleaseSprite.bounds.Contains(mousePos))
            {

                if(!releaseInUse)
                {

                    releaseInUse = true;

                    Debug.Log("Slide!");
                    magScript.StartMagSwap();

                }           

            }

        }

        if(releaseInUse)
        {

            CycleSlideRelease();

        }
        else
        {

            transform.position = releaseStartPos;

        }

    }

    public void CycleSlideRelease()
    {

        Vector2 currentSlidePos = transform.position;

        if (!releaseKickoff)
        {

            releaseGoingDown = true;
            releaseKickoff = true;

        }

        if (releaseGoingDown)
        {

            currentSlidePos.y -= 0.01f;

        }

        if (releaseGoingDown && (currentSlidePos.y <= releaseEndPos.y))
        {

            releaseGoingDown = false;
            releaseFullDown = true;

        }

        if (releaseFullDown)
        {

            resetTimer -= Time.deltaTime;

        }

        if (resetTimer <= 0)
        {

            releaseGoingUp = true;
            releaseFullDown = false;

        }

        if (releaseGoingUp)
        {

            currentSlidePos.y += 0.01f;

        }      

        if (releaseGoingUp && (currentSlidePos.y >= releaseStartPos.y))
        {

            releaseGoingUp = false;
            releaseInUse = false;
            releaseKickoff = false;

            resetTimer = 1.1f;

            Debug.Log("Mag release is ready.");

        }

        transform.position = currentSlidePos;

    }

}
