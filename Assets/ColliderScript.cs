using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderScript : MonoBehaviour {

    // Use this for initialization


    [SerializeField]
    AudioClip[] collisions;
    public AudioSource hitPlay;


    void PlayHit() {
        int rand = Random.Range(0, collisions.Length);
        Debug.Log(rand);
        hitPlay.clip = collisions[rand];

        hitPlay.Play();

    }


    void  OnTriggerEnter(Collider col) {
        Debug.Log("HIT SOMETHING");
        if(col.tag == "Enemy") {
            PlayHit();
            Destroy(col.gameObject);
        }
        if(col.tag == "Laser")
        {
            Debug.Log("Doot");
            LaserProjectile l = col.GetComponent<LaserProjectile>();
            l.Reflect();
        }
    }
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
