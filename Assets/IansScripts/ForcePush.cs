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

    void Start()
    {

    }


    void Update()
    {


        if (OVRInput.GetDown(OVRInput.RawButton.LHandTrigger))
        {
            Debug.Log("Left Hand Trigger!\nPUSH!!!");
            forcePush();
        }
        if(OVRInput.GetDown(OVRInput.RawButton.LShoulder))
        {
            Debug.Log("Left Shoulder!\nPULL!!!");
            forcePull();
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("the Spacebar still works");
            forcePush();
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            Debug.Log("the I key still works");
            forcePull();
        }

    }

    void FixedUpdate()
    {

    }

    void forcePush()
    {
        pushThese = Physics.OverlapBox(new Vector3(transform.position.x + 10, transform.position.y, transform.position.z),
            new Vector3(10f, 2, 2), Quaternion.identity, layers);
        foreach (Collider a in pushThese)
        {
            force = Vector3.Normalize(player.transform.position - a.transform.position);
            a.GetComponent<Rigidbody>().AddForce(force * intensity);
        }

    }
    void forcePull()
    {
        pullThese = Physics.OverlapBox(new Vector3(transform.position.x + 10, transform.position.y, transform.position.z),
            new Vector3(10f, 2, 2), Quaternion.identity, layers);
        foreach (Collider a in pullThese)
        {
            force = Vector3.Normalize(player.transform.position - a.transform.position);
            a.GetComponent<Rigidbody>().AddForce(-(force) * intensity);
        }
    }

}
