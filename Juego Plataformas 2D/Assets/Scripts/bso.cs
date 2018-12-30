using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bso : MonoBehaviour {

    public Timer time;
    public AudioSource music;
    public PlayerController player;
    public bool started;




    // Use this for initialization
    void Start () {
        music = GetComponent<AudioSource>();
        started = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (started == false && time.inicio == true)
        {
            music.Play();
            started = true;
        }

		
	}
}
