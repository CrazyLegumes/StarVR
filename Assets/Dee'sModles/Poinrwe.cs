using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Avatar;
using UnityEngine.SceneManagement;

public class Poinrwe : MonoBehaviour {


    OvrAvatarDriver.ControllerPose leftpose;
    public OvrAvatarHand lefthando;
    public OvrAvatarDriver driver;

    public GameObject pointer;

    public LayerMask canPoint;
    bool pointing;
    bool canStart;
    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        OvrAvatarDriver.PoseFrame pose;
        driver.GetCurrentPose(out pose);
        CheckPointer(pose.controllerLeftPose);


        if(canStart && OVRInput.GetDown(OVRInput.Button.One))
        {
            SceneManager.LoadScene(1, LoadSceneMode.Single);
        }
		
	}

    void CheckPointer(OvrAvatarDriver.ControllerPose hando)
    {

        if(hando.handTrigger >.5f && hando.indexTrigger == 0)
        {
            pointing = true;
            pointer.GetComponent<Renderer>().enabled = true;
            PointToIt();
        }
        else
        {
            pointing = false;
            canStart  =false;
            pointer.GetComponent<Renderer>().enabled = false;
        }

    }


    void PointToIt()
    {
        Quaternion ori = Quaternion.Euler(OVRInput.GetLocalControllerRotation(OVRInput.Controller.LTouch).eulerAngles + transform.parent.rotation.eulerAngles);
        Vector3 forwd = ori * Vector3.forward;

        Debug.DrawRay(lefthando.transform.position, forwd * 100000,Color.red,.002f);

        RaycastHit hit;
        if(Physics.Raycast(lefthando.transform.position, forwd, out hit, 1000000, canPoint))
        {
            if (hit.transform.name == "Starto")
                canStart = true;
        }
        else
        {
            canStart = false;
        }
    }


}
