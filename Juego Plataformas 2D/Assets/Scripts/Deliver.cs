using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Deliver : MonoBehaviour {

    public PlayerController player;
    public PickUp carrito;
    public float nHab;
    public Timer timer;
    public AudioSource audio;

    public AudioClip tada;
    public AudioClip buzz;
    public AudioClip error;


    [SerializeField] GameObject msgPanel;
    [SerializeField] Text msgText;

    [SerializeField] GameObject msgPanelAux;

    private bool inside;
    //private float time;
    //private bool fin;

    // Use this for initialization
    void Start () {
        inside = false;

        audio = GetComponent<AudioSource>();

        msgPanel.SetActive(false);
        msgPanelAux.SetActive(false);



    }

    void Update()
    {
        //Debug.Log(carrito.iList.Count);
        //Debug.Log(time);
        //Debug.Log(fin);

        //time += Time.deltaTime;
        

        if (inside == true && player.pause == false && (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.JoystickButton2) || Input.GetKeyDown(KeyCode.Return)))
        {
            if (player != null)                             //Hay que tener cuidado con las referencias NULL
            {
                if (player.carry == true)
                {
                    if (player.nMaleta == nHab)
                    {
                        //Debug.Log("¡GENIAL! Has entregado la maleta " + player.nMaleta + " en la habitación " + nHab);
                        msgText.text = "¡GENIAL! Has entregado la maleta " + player.nMaleta + " en la habitación " + nHab;
                        msgPanel.SetActive(true);
                        msgPanelAux.SetActive(true);
                        timer.time += 10;
                        audio.PlayOneShot(tada, 1.0f);

                    }

                    else
                    {
                        //Debug.Log("¡OH NO! Has entregado la maleta " + player.nMaleta + " en la habitación " + nHab);
                        msgText.text = "¡OH NO! Has entregado la maleta " + player.nMaleta + " en la habitación " + nHab;
                        msgPanel.SetActive(true);
                        msgPanelAux.SetActive(true);
                        timer.time -= 10;
                        audio.PlayOneShot(buzz, 1.0f);
                    }

                    carrito.iList.Remove(player.nMaleta);
                    player.carry = false;
                    
                }

                else
                {
                    //Debug.Log("No tienes ninguna maleta encima");
                    msgText.text = "No tienes ninguna maleta encima";
                    msgPanel.SetActive(true);
                    msgPanelAux.SetActive(true);
                    audio.PlayOneShot(error, 1.0f);
                }
            }

        }

    }



    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            inside = true;

        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            inside = false;
            msgPanel.SetActive(false);
            msgPanelAux.SetActive(false);

        }
    }



}
