using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaberScript : MonoBehaviour {

    [SerializeField]
    AudioClip[] moveSounds;

   

    
    OVRInput.Controller right;
    public AudioSource movePlay;

   
    
    bool moveCooldown;
    

    
    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Enemy")
        {
           
        }
    }

	// Use this for initialization
	void Start () {
        right = OVRInput.Controller.RTrackedRemote;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 rightVeloc = OVRInput.GetLocalControllerVelocity(right);
        if (rightVeloc.magnitude > 1 && !moveCooldown)
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

    
}
