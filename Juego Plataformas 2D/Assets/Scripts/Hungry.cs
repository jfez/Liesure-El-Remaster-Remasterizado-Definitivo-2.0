using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Hungry : MonoBehaviour {

    public PlayerController2 player;
    public AudioSource audio;
    public AudioClip hambriento;

    // Use this for initialization
    void Start () {
        audio = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {

        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.gameObject.tag == "Player")
        {
            if (player.nBandeja != 0)
            {
                player.nBandeja = 0;
                audio.PlayOneShot(hambriento, 1.0f);

            }

        }
    }
}
