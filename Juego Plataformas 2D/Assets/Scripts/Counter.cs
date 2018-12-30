using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour {

    public int contador;

    public AudioSource audio;
    public PlayerController2 player;

    private bool panic;

    // Use this for initialization
    void Start () {
        contador = 0;
        audio = GetComponent<AudioSource>();
        panic = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (contador < 3)
        {
            panic = false;
            audio.Stop();
        }

        if (contador > 2 && panic == false)
        {
            audio.Play();
            panic = true;
        }

        if (player.pause)
        {
            audio.Pause();
            panic = false;
        }
    }
}
