using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField]
    GameObject player;
    float speed;
    float radius;

    void Start()
    {
        speed = 10;
        radius = 3;
        player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        Arrive();
    }

    void Arrive() {
        Vector3 target = player.transform.position;
        Vector3 desVel;
        float distance = Vector3.Distance(transform.position, target);

        if (distance < radius) {
            desVel = Vector3.Normalize(target - transform.position) * speed * Time.deltaTime * (distance / radius);
        }
        else
            desVel = Vector3.Normalize(target - transform.position) * speed * Time.deltaTime;

        transform.position += desVel;
    }
}
