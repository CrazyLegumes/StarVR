using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireLaser : MonoBehaviour {

    [SerializeField]
    GameObject laser;
    LaserProjectile mylaser;


	// Use this for initialization
	void Start () {

        InvokeRepeating("Fireit", 1, 2);
		
	}


    void Fireit()
    {
        mylaser = Instantiate(laser, transform.position, Quaternion.identity).GetComponent<LaserProjectile>();
        mylaser.target = GameObject.FindGameObjectWithTag("Player").transform.position;
        mylaser.GetVeloc();
    }

	
	// Update is called once per frame
	void Update () {
		
	}
}
