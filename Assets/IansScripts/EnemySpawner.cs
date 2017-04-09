﻿using System.Collections;
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


    // Use this for initialization
    void Start()
    {
        maxEnemies = 5; //max of 5 enemies per spawner

    }

    // Update is called once per frame
    void Update()
    {
        float randx = Random.Range(-50, 50); //spawn the enemy within 5 of the spawner
        float randz = Random.Range(-50, 50); //spawn the enemy winith 5 of the spawner
        position = new Vector3(randx, 1, randz);
        if (enemyCount < maxEnemies &&  Time.time - timer >= 10)
        {
            Instantiate(enemy, position, Quaternion.identity);  //should spawn the enemy as a child of the spawner
            timer = Time.time;
            enemyCount++;
            Debug.Log("SpawnEnemy");
        }
    }
}