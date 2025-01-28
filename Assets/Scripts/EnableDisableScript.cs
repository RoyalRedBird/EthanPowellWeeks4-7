using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableDisableScript : MonoBehaviour
{

    public SpriteRenderer circleSprite;
    public EnableDisableScript script;
    public GameObject badUI;
    public AudioSource soundEmitter;

    public AudioClip soundByte;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0)) { 
        
            circleSprite.enabled = false;
            badUI.SetActive(false);
        
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {

            circleSprite.enabled = true;
            badUI.SetActive(true);

        }

        if (Input.GetKey(KeyCode.Space))
        {

            //soundEmitter.Play();

            if (!soundEmitter.isPlaying)
            {

                soundEmitter.PlayOneShot(soundByte);

            }

            Debug.Log(soundEmitter.clip.length);

        }

    }
}
