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

    void Start()
    {

    }


    void Update()
    {
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
        pushThese = Physics.OverlapBox(new Vector3(transform.position.x + 5, transform.position.y, transform.position.z),
            new Vector3(10f, 2, 2), Quaternion.identity, layers);
        if (pushThese.Length > 0)
        {
            foreach (Collider a in pushThese)
            {
                Debug.Log("pushing this guy: " + a);
                a.GetComponent<Rigidbody>().AddForce(-(player.transform.position - a.transform.position) * intensity*2);
            }
        }
    }
    void forcePull()
    {
        pullThese = Physics.OverlapBox(new Vector3(transform.position.x + 10, transform.position.y, transform.position.z),
            new Vector3(15f, 2, 2), Quaternion.identity, layers);
        if (pullThese.Length > 0)
        {
            foreach (Collider a in pullThese)
            {
                Debug.Log("pulling this guy: " + a);
                a.GetComponent<Rigidbody>().AddForce((player.transform.position - a.transform.position) * intensity / 2);
            }
        }
    }
}
