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
    public GameObject UIobj;
    public GameObject ColorPick;
    public GameObject lightSaber;

    public LayerMask canPoint;
    bool pointing;
    bool canStart;
    bool startWaves;
    bool pickingcolor;
    GameObject colorChange;
    

	// Use this for initialization
	void Start () {
        UIobj.SetActive(false);
		
	}
	
	// Update is called once per frame
	void Update () {
        OvrAvatarDriver.PoseFrame pose;
        driver.GetCurrentPose(out pose);
        CheckPointer(pose.controllerLeftPose);


        if(canStart && OVRInput.GetDown(OVRInput.Button.One))
        {
            SceneManager.LoadScene(1, LoadSceneMode.Single);
            SceneManager.activeSceneChanged += SceneManager_activeSceneChanged;
        }

        if(startWaves && OVRInput.GetDown(OVRInput.Button.One))
        {
            Manager.Starto = true;
            Manager.MainGame = false;
            UIobj.SetActive(false);
        }
        if(pickingcolor && OVRInput.GetDown(OVRInput.Button.One) && colorChange != null)
        {
            Material switcher = colorChange.GetComponent<Renderer>().material;
            lightSaber.GetComponent<Renderer>().material = switcher;
        }
        if (Manager.MainGame)
            UIobj.SetActive(true);
		
	}

    private void SceneManager_activeSceneChanged(Scene arg0, Scene arg1)
    {
        Manager.MainGame = true;
        Manager.Starto = false;
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
            startWaves = false;
            pickingcolor = false;
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

            if (hit.transform.name == "Start Game")
            {
                startWaves = true;
                
            }
            if (hit.transform.name.Contains("Color"))
            {
                pickingcolor = true;
                colorChange = hit.transform.gameObject;

            }
            
        }
        else
        {
            canStart = false;
            startWaves = false;
            pickingcolor = false;
        }
    }


}
