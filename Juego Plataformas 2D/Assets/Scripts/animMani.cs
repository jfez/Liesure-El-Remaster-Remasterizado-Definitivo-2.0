using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animMani : MonoBehaviour {

    public bool running;
    public int scene;

    private Animator anim;


    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();

        if (scene == 0)         //Hall 0.2 --> idle
        {
            running = false;
        }

        else if (scene == 1)    //Level2 --> correr
        {
            running = true;
        }
    }
	
	// Update is called once per frame
	void Update () {
        anim.SetBool("Running", running);
    }
}
