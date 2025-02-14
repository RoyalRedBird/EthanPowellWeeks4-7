using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagazineScript : MonoBehaviour
{

    [SerializeField] GameObject stalkerMag;
    [SerializeField] GameObject autoMag;
    [SerializeField] GameObject rifleMag;

    Vector2 magStartPoint;
    Vector2 magEndPoint;

    bool swappingMag = false;

    bool magFullDown = false;
    bool magGoingUp = false;

    float waitTimer = 1.0f;

    int activeMag = 1;
    [SerializeField] [Range(1,3)] int newMag = 1;

    int ammoMax = 24;
    int currentAmmo = 24;

    // Start is called before the first frame update
    void Start()
    {

        magStartPoint = transform.position;

        Vector2 endPoint = transform.position;
        endPoint.y -= 6f;

        magEndPoint = endPoint;
        
    }

    // Update is called once per frame
    void Update()
    {

        if(swappingMag)
        {

            SwappingCurrentMag();

        }
        
    }

    public void StartMagSwap()
    {

        swappingMag = true;

    }

    public void SwitchMag(int mag)
    {

        newMag = mag;
        StartMagSwap();

    }

    void SwappingCurrentMag()
    {

        Vector2 magPos = transform.position;

        if(!magFullDown && (magPos.y > magEndPoint.y)) {

            magPos.y -= 0.075f;
        
        }

        if (magPos.y <= magEndPoint.y)
        {

            magFullDown = true;

        }

        if(magFullDown) { 
        
            waitTimer -= Time.deltaTime;
        
        }

        if(waitTimer <= 0)
        {

            SwitchMagType();
            magGoingUp = true;

        }

        if (magGoingUp)
        {

            magPos.y += 0.075f;

        }

        if(magGoingUp && magPos.y >= magStartPoint.y)
        {

            magPos.y = magStartPoint.y;
            swappingMag = false;
            magGoingUp = false;
            magFullDown = false;
            waitTimer = 1.0f;

        }

        transform.position = magPos;

    }

    void SwitchMagType()
    {

        if(newMag == 1)
        {

            stalkerMag.SetActive(false);
            autoMag.SetActive(false);
            rifleMag.SetActive(true);

            ammoMax = 24;

        }

        if (newMag == 2)
        {

            stalkerMag.SetActive(true);
            autoMag.SetActive(false);
            rifleMag.SetActive(false);

            ammoMax = 12;

        }

        if (newMag == 3)
        {

            stalkerMag.SetActive(false);
            autoMag.SetActive(true);
            rifleMag.SetActive(false);

            ammoMax = 35;

        }

        currentAmmo = ammoMax;

    }

}
