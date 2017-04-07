using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField]
    GameObject player;
    float speed;

    void Start()
    {
        speed = 5;
        player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        Seek();
    }



    void Seek()
    {
        Vector3 target = player.transform.position;

        Vector3 desiredVel = Vector3.Normalize(target - transform.position) * speed * Time.deltaTime;
        transform.position = transform.position + desiredVel;
    }
}
