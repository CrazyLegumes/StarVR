using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    int maxEnemies;
    int enemyCount;
    [SerializeField]
    GameObject enemy;
    float timer;
    Vector3 position;
    float timeLimit;


    // Use this for initialization
    void Start()
    {
        maxEnemies = 5; //max of 5 enemies per spawner
        enemyCount = 0;
        timeLimit = 3;      //wait 3 seconds to spawn first enemy

    }

    // Update is called once per frame
    void Update()
    {
        float randx = Random.Range(-50, 50); //spawn the enemy within 50 of the spawner
        float randz = Random.Range(-50, 50); //spawn the enemy winith 50 of the spawner
        position = new Vector3(randx, 1, randz);
        if (enemyCount < maxEnemies &&  Time.time - timer >= timeLimit)
        {
            Instantiate(enemy, position, Quaternion.identity); 
            timer = Time.time;
            enemyCount++;
            timeLimit = Random.Range(3, 10);
            Debug.Log("SpawnEnemy");
        }
    }
}
