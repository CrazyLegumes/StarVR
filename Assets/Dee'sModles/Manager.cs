using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {

    public static bool Starto;
    public static bool MainGame;
	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);
        Starto = false;
        MainGame = false;
	}
	
	// Update is called once per frame
	void Update () {
        
		
	}
}
