using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyScript : MonoBehaviour
{

    public int health = 100;
    public TextMeshPro healthText;
    public SpriteRenderer enemySprite;
    public AudioClip deathNoise;
    public AudioSource noiseMaker;

    public EnemySceneController thisSceneController;

    float deathNoiseLength;
    float deathTime = 0;
    bool doneDying = false;


    // Start is called before the first frame update
    void Start()
    {

        thisSceneController = GameObject.Find("GameController").GetComponent<EnemySceneController>();
        deathNoiseLength = deathNoise.length;

    }

    // Update is called once per frame
    void Update()
    {

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {

            if (enemySprite.bounds.Contains(mousePos))
            {

                health -= 10;

            }

        }

        healthText.text = "Health: " + health;

        if(health <= 0)
        {

            deathTime += Time.deltaTime;

            if (!noiseMaker.isPlaying)
            {

                noiseMaker.PlayOneShot(deathNoise);

            }

            if(deathTime >= deathNoiseLength)
            {

                thisSceneController.DestroyEnemy(gameObject);

            }   

        }

    }

}
