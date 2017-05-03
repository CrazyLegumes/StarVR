using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserProjectile : MonoBehaviour
{

    bool reflected;
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


    void OnTriggerEnter(Collider col) {
        if (reflected && (col.tag == "Enemy" || col.tag == "turret")) {
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
    }
    void Update()
    {
        timeLived += Time.deltaTime;
        if (timeLived >= lifetime)
            Destroy(gameObject);

        transform.position += desiredVelocity * 20 * Time.deltaTime;

        if (Vector3.Distance(transform.position, Vector3.zero) > 400)
            Destroy(gameObject);
    }


    public void GetVeloc()
    {
        desiredVelocity = Vector3.Normalize(target - transform.position);
        transform.LookAt(target);
    }


    public void Reflect()
    {
        if (!reflected)
        {
            reflected = true;
            desiredVelocity *= -1;
            timeLived = 0;
        }


    }

}
