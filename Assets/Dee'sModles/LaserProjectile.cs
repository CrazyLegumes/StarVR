using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserProjectile : MonoBehaviour {

    
    float lifetime;
    float timeLived;
    public Vector3 desiredVelocity;
    public Vector3 target;


    void Start()
    {
        lifetime = 6;
        timeLived = 0;
        //desiredVelocity = Vector3.zero;
    }


    void Update()
    {
        timeLived += Time.deltaTime;
        if (timeLived >= lifetime)
            Destroy(gameObject);

        transform.position += desiredVelocity * 20 * Time.deltaTime;
    }


    public void GetVeloc()
    {
        desiredVelocity = Vector3.Normalize(target - transform.position);
        transform.LookAt(target);
    }


    public void Reflect()
    {
        desiredVelocity *= -1;
        timeLived = 0;

    }

}
