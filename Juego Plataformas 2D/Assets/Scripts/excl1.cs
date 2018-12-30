using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class excl1 : MonoBehaviour {

    public Renderer rend;
    public Timer2 timer;
    public bool on;
    public Counter counter;
    public float auxTime;
    public Comanda mesa;
    public AudioSource audio;
    public GameObject player;

    public AudioClip ding;


    public int divisor;
    //divisor = 5 en el primer ejemplo
    public int espera;
    //tiempo de espera para que salga de nuevo la exclamación

    private float distancia;
    



    // Use this for initialization
    void Start () {
        rend.enabled = false;
        on = false;
        auxTime = 0.0f;
        audio = GetComponent<AudioSource>();

    }
	
	// Update is called once per frame
	void Update () {
        //print(auxTime);
        distancia = Mathf.Abs(player.transform.position.magnitude - transform.position.magnitude);
        //print("distancia: " + distancia);
        if (timer.inicio)
        {
            auxTime += Time.deltaTime;
        }

        if (Mathf.FloorToInt(timer.time) % divisor == 0 && Mathf.FloorToInt(timer.time) < 120 && timer.inicio == true && rend.enabled == false && auxTime>espera && mesa.buffet == false)
        {
            on = true;
            if(distancia > 15)
            {
                audio.PlayOneShot(ding, 0.2f);
            }
            else if (distancia > 10)
            {
                audio.PlayOneShot(ding, 0.7f);
            }
            else if (distancia > 8)
            {
                audio.PlayOneShot(ding, 1.2f);
            }
            else if (distancia > 6)
            {
                audio.PlayOneShot(ding, 1.7f);
            }
            else if (distancia > 4)
            {
                audio.PlayOneShot(ding, 2.2f);
            }
            else if (distancia > 2)
            {
                audio.PlayOneShot(ding, 2.7f);
            }
            else
            {
                audio.PlayOneShot(ding, 3.2f);
            }

            counter.contador++;
        }

        if (on)
        {
            rend.enabled = true;


        }

        else if (!on)
        {
            rend.enabled = false;
        }
    }
}
