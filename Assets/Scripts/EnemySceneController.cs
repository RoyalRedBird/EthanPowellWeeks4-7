using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySceneController : MonoBehaviour
{

    public GameObject enemyToSpawn;
    public GameObject spawnPoint;
    public int enemiesToSpawn;

    public List<GameObject> enemyArray;

    // Start is called before the first frame update
    void Start()
    {

        for(int i = 0; i < enemiesToSpawn; i++)
        {

            Vector3 spawnLocation = new Vector3(Random.Range(-7f, 7f), Random.Range(-3f, 3f), 0);
            GameObject workingObject = GameObject.Instantiate(enemyToSpawn);

            workingObject.transform.position = spawnLocation;

        }

        GameObject[] totalEnemyArray = GameObject.FindGameObjectsWithTag("enemy");

        foreach (GameObject enemy in totalEnemyArray)
        {

            enemyArray.Add(enemy);

        }

    }

    // Update is called once per frame
    void Update()
    {

        if (enemyArray.Count <= 0)
        {

            Debug.Log("You win!");

        }
        
    }

    public void DestroyEnemy(GameObject enemy)
    {

        enemyArray.Remove(enemy);
        Destroy(enemy);

    }

}
