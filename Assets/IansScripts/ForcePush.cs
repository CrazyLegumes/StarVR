using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForcePush : MonoBehaviour
{

    [SerializeField]
    float power;
    Vector3 centerOfBox;
    [SerializeField]
    GameObject player;


    void Start()
    {
        centerOfBox = transform.position;

    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        RaycastHit hit;
        if (Input.GetKeyDown(KeyCode.Space)) //temporary way to activate the force push

        {
            Debug.Log("space is pressed");
            if (Physics.BoxCast(centerOfBox, new Vector3(1, 5, 2), Vector3.forward, out hit, new Quaternion(), 10))
            {
                Debug.Log("what is working?");
            }

        }

    }
}
