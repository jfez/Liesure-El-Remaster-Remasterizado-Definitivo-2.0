using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animAlfredo : MonoBehaviour {

    public bool eating;
    public int scene;

    private Animator anim;


    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();

        if (scene == 0)         //Halls --> idle
        {
            eating = false;
        }

        else if (scene == 1)    //Level2 --> comiendo
        {
            eating = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Eating", eating);
    }
}
