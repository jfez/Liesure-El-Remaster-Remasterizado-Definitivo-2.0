using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerHall : MonoBehaviour {

    //[SerializeField] GameObject msgPanelTime;
    //[SerializeField] Text msgTextTime;

    public float time;
    //public float auxiliarTime;
    //public PickUp carrito;
    public bool inicio;
    //public int recompensa;
    public PCH player;
    public bool timeDone;
    public GameObject pared;
    public int hall;
    public int conversaciones;

    public AudioSource audio;

    [SerializeField] GameObject msgPanel;
    [SerializeField] Text msgText;

    [SerializeField] GameObject msgPanelAux;
    [SerializeField] Text msgTextAux;

    private bool end;

    

    // Use this for initialization
    void Start()
    {
        if (hall == 0)
        {
            time = 0.0f;    //200 secs
        }

        else if (hall == 1)
        {
            time = 20.0f;    //180 secs
        }
        
        

        audio = GetComponent<AudioSource>();

        inicio = true;
        conversaciones = 0;
        end = false;

        //msgPanelTime.SetActive(false);
        msgPanel.SetActive(false);
        msgPanelAux.SetActive(false);
        timeDone = false;
        //panic = false;

        /*reloj1.enabled = true;
        reloj11.enabled = false;
        reloj2.enabled = false;
        reloj21.enabled = false;*/

        //end = false;
        //restart = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (inicio)
        {
            //msgPanelTime.SetActive(true);
            time += Time.deltaTime;
            //msgTextTime.text = time.ToString("f0");
        }

        if (time > 200)
        {
            if (timeDone == false)
            {
                timeDone = true;
                Destroy(pared);
            }
            player.transform.localScale = new Vector3(-0.48016f, 0.48016f, 0.48016f);
            player.canInteract = false;
            player.canMove = false;
            msgText.text = "¡Lo siento, he de irme, llego tarde!";
            msgTextAux.text = "TÚ";
            //msgPanelTime.SetActive(false);
            msgPanel.SetActive(true);
            msgPanelAux.SetActive(true);
            player.GetComponent<Rigidbody2D>().velocity = new Vector2(10, -10);
        }

        if (conversaciones > 2 && end == false)
        {
            time = 190.0f;
            end = true;
        }




        /*if (time < 1 && restart == false)
        {
            if (PantallaDeCarga.Instancia != null)
            {
                PantallaDeCarga.Instancia.CargarEscena("Level1");      //reiniciar el nivel
            }

            else
            {
                SceneManager.LoadScene("Level1");
            }
            restart = true;
        }

        if (time >= 10)
        {
            panic = false;
            audio.Stop();
        }

        if (time < 10 && panic == false)
        {
            audio.Play();
            panic = true;
        }

        if (player.pause)
        {
            audio.Pause();
            panic = false;
        }

        if (carrito.iList.Count == 0)
        {
            auxiliarTime += Time.deltaTime;
            if (auxiliarTime > 1 && end == false)
            {

                if (PantallaDeCarga.Instancia != null)
                {
                    PantallaDeCarga.Instancia.CargarEscena("Level2");      //reiniciar el nivel
                }

                else
                {
                    SceneManager.LoadScene("Level2");
                }
                end = true;
            }


        }*/
    }
}
