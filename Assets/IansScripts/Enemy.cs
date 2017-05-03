using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField]
    GameObject player;
    [SerializeField]
    Animator anim;
    bool dead;
    float speed;
    float radius;

    void Start()
    {
        
	    speed = 3;
        radius = 1.2f;
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
        anim.SetBool("isAlive", true);
    }

    // Update is called once per frame
    void Update()
    {
       Arrive();
    }

    void animate()
    {
        if(!dead)
        {
            anim.Play("running");
        }
    }

    void OnDestory()
    {
       
        anim.SetBool("isAlive", false);
    }
    void Seek()
    {
        Vector3 target = player.transform.position;

        Vector3 desiredVel = Vector3.Normalize(target - transform.position) * speed * Time.deltaTime;
        transform.position = transform.position + desiredVel;

    }


    void Arrive() {
        Vector3 target = player.transform.position;
        target.y = 1f;
        Vector3 desVel;
        float distance = Vector3.Distance(transform.position, target);

        if (distance < radius) {
            desVel = Vector3.zero;
        }
        else
            desVel = Vector3.Normalize(target - transform.position) * speed * Time.deltaTime;


        if(desVel != Vector3.zero)
        {
            anim.SetBool("isMoving", true);
        }
        else
        {
            anim.SetBool("isMoving", false);
        }
        
        transform.position += desVel;
        transform.LookAt(target);

    }
}
