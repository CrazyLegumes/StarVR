using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaberScript : MonoBehaviour {

    [SerializeField]
    AudioClip[] moveSounds;

    [SerializeField]
    AudioClip[] collisions;

    
    OVRInput.Controller right;
    public AudioSource movePlay;

    public AudioSource hitPlay;
    
    bool moveCooldown;
    

    
    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Enemy")
        {
            PlayHit();
            Destroy(col.gameObject);
        }
    }

	// Use this for initialization
	void Start () {
        right = OVRInput.Controller.RTrackedRemote;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 rightVeloc = OVRInput.GetLocalControllerVelocity(right);
        if (rightVeloc.magnitude > 5 && !moveCooldown)
        {
            StartCoroutine(PlayMove());  
        }
		
	}

    IEnumerator PlayMove()
    {
        moveCooldown = true;
        movePlay.clip = moveSounds[Random.Range(0, moveSounds.Length)];
        movePlay.Play();
        moveCooldown = true;
        yield return new WaitForSeconds(.3f);
        moveCooldown = false;
    }

    void PlayHit()
    {
        hitPlay.clip = collisions[Random.Range(0, collisions.Length)];

        hitPlay.Play();

    }
}
