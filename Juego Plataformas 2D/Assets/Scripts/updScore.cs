using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class updScore : MonoBehaviour {

    public int recompensa2;
    
    // Use this for initialization
	void Start () {
        recompensa2 = 0;
    }
	
	// Update is called once per frame
	void Update () {
        //Debug.Log("rec2: " + recompensa2);
        PlayerPrefs.SetInt("recompensa2", recompensa2);
    }
}
