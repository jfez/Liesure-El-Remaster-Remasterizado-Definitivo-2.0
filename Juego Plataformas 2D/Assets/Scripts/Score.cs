using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {

    public int recompensa1;
    public int recompensa2;
    public int recompensa;
    public int pausas;

    public Timer timer;
    public int scene;

    private static Score score;

    // Use this for initialization
    void Start () {
        if(scene == 0)      //recompensa TOTAL
        {
            recompensa = 0;
            recompensa1 = 0;
            recompensa2 = 0;
            pausas = 0;

            PlayerPrefs.SetInt("recompensa0", recompensa);
            PlayerPrefs.SetInt("recompensa1", recompensa1);
            PlayerPrefs.SetInt("recompensa2", recompensa2);
            PlayerPrefs.SetInt("pausas", pausas);
        }
        
        else if (scene == 1)    //recompensa nivel 1
        {
            if (PlayerPrefs.HasKey("recompensa0"))
            {
                recompensa = PlayerPrefs.GetInt("recompensa0");
            }

            recompensa1 = 0;

            PlayerPrefs.SetInt("recompensa1", recompensa1);


        }

        else if (scene == 2)        //recompensa nivel 2
        {
            if (PlayerPrefs.HasKey("recompensa0"))
            {
                recompensa = PlayerPrefs.GetInt("recompensa0");
            }

            if (PlayerPrefs.HasKey("recompensa1"))
            {
                recompensa1 = PlayerPrefs.GetInt("recompensa1");
            }

            //recompensa2 = 0;
            //PlayerPrefs.SetInt("recompensa2", recompensa2);

        }
        
    }

	
	// Update is called once per frame
	void Update () {
        //Debug.Log(PlayerPrefs.GetInt("recompensa" + scene.ToString()));
        Debug.Log("0: " + PlayerPrefs.GetInt("recompensa0"));
        Debug.Log("1: " + PlayerPrefs.GetInt("recompensa1"));
        Debug.Log("2: " + PlayerPrefs.GetInt("recompensa2"));
        Debug.Log("pausas: " + PlayerPrefs.GetInt("pausas"));



        if (scene == 1)    //recompensa nivel 1
        {
            recompensa1 = timer.recompensa * 10;
            PlayerPrefs.SetInt("recompensa" + scene.ToString(), recompensa1);
        }

        /*else if (scene == 2)        //recompensa nivel 2
        {
            recompensa1 = timer.recompensa * 10;
            PlayerPrefs.SetInt("recompensa" + scene.ToString(), recompensa1);
        }*/ //la actualización del PlayerPrefs ha de hacerse en el script Comanda (al entregar las bandejas) --> no dependerá del tiempo

    }
}
