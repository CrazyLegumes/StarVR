using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretspin : MonoBehaviour {


    [SerializeField]
    GameObject player;
	// Use this for initialization
	void Start () {
        Init();
	}
	void Init()
    {
        player = FindObjectOfType<OVRPlayerController>().gameObject;
        transform.parent.parent.LookAt(player.transform.position);
        transform.parent.parent.rotation = Quaternion.Euler(0, transform.parent.parent.rotation.y, 0);
        
    }
	// Update is called once per frame
	void Update () {
      
        Vector3 dir = player.transform.position - transform.position;
        Vector3 forwd = transform.forward;
        var localTar = transform.InverseTransformPoint(player.transform.position);

        var angle = Mathf.Atan2(localTar.x, localTar.z) * Mathf.Rad2Deg;

        var eulerangleVelocity = new Vector3(0, angle -90, 0);
        var rot = Quaternion.Euler(eulerangleVelocity * 10 * Time.deltaTime);
        GetComponent<Rigidbody>().MoveRotation(GetComponent<Rigidbody>().rotation * rot);


   


     

    }
    
}
