using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForcePush : MonoBehaviour
{
    [SerializeField]
    public GameObject player;
    public float intensity;
    Collider[] pushThese;
    Collider[] pullThese;
    public LayerMask layers;
    Vector3 force;
    double pushCooldownStart;
    double pullCooldownStart;

    OVRInput.Controller leftHand;

    void Start()
    {
        leftHand = OVRInput.Controller.LTrackedRemote;
    }


    void Update()
    {
        forcePowers();

        //if (OVRInput.GetDown(OVRInput.RawButton.X))
        //{
        //    Debug.Log("Left Hand Trigger!\nPUSH!!!");
        //    forcePush();
        //}
        //if (OVRInput.GetDown(OVRInput.RawButton.Y))
        //{
        //    Debug.Log("Left Shoulder!\nPULL!!!");
        //    forcePull();
        //}


        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    Debug.Log("the Spacebar still works");
        //    forcePush();
        //}
        //if (Input.GetKeyDown(KeyCode.I))
        //{
        //    Debug.Log("the I key still works");
        //    forcePull();
        //}

    }

    void forcePowers()
    {
        Vector3 leftVel = OVRInput.GetLocalControllerVelocity(leftHand);
        if(leftVel.x > .7 && Time.time - pushCooldownStart > 2.0f)
        {
            forcePush();
            Debug.Log("Force Push");
        }
        else if(leftVel.x < -.7 && Time.time - pullCooldownStart > 2.0f)
        {
            forcePull();
            Debug.Log("Force Pull");
        }
    }
    void forcePush()
    {
        pushCooldownStart = Time.time;
        pushThese = Physics.OverlapBox(new Vector3(transform.position.x, transform.position.y, transform.position.z),
            new Vector3(10f, 2, 10), Quaternion.identity, layers);
        foreach (Collider a in pushThese)
        {
            force = Vector3.Normalize(player.transform.position - a.transform.position);
            a.GetComponent<Rigidbody>().AddForce(force * intensity);
        }

    }
    void forcePull()
    {
        pullCooldownStart = Time.time;
        pullThese = Physics.OverlapBox(new Vector3(transform.position.x, transform.position.y, transform.position.z),
            new Vector3(10f, 2, 10), Quaternion.identity, layers);
        foreach (Collider a in pullThese)
        {
            force = Vector3.Normalize(player.transform.position - a.transform.position);
            a.GetComponent<Rigidbody>().AddForce(-(force) * intensity);
        }
    }

}
