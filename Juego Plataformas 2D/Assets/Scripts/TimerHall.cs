using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerHall : MonoBehaviour {

    [SerializeField] GameObject msgPanelTime;
    [SerializeField] Text msgTextTime;

    public float time;
    public float auxiliarTime;
    //public PickUp carrito;
    public bool inicio;
    //public int recompensa;
    public PCH player;

    public AudioSource audio;

    [SerializeField] GameObject msgPanel;
    [SerializeField] Text msgText;

    [SerializeField] GameObject msgPanelAux;
    [SerializeField] Text msgTextAux;

    /*public Renderer reloj1;
    public Renderer reloj11;
    public Renderer reloj2;
    public Renderer reloj21;*/



    /*private bool panic;
    private bool end;
    private bool restart;*/

    // Use this for initialization
    void Start()
    {
        time = 60.0f;    //60
        auxiliarTime = 0.0f;

        audio = GetComponent<AudioSource>();

        inicio = true;

        msgPanelTime.SetActive(false);
        msgPanel.SetActive(false);
        msgPanelAux.SetActive(false);
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
            msgPanelTime.SetActive(true);
            if (time > 0)
            {
                time -= Time.deltaTime;
            }
            //msgText.text = "Tiempo restante: " + time.ToString("f0");
            msgTextTime.text = time.ToString("f0");
            //recompensa = Mathf.RoundToInt(time);
            //Debug.Log(recompensa);

            /*if (Mathf.RoundToInt(time) % 2 == 0 && time >= 10)
            {
                reloj1.enabled = true;
                reloj11.enabled = false;
                reloj2.enabled = false;
                reloj21.enabled = false;

            }

            else if (Mathf.RoundToInt(time) % 2 != 0 && time >= 10)
            {
                reloj1.enabled = false;
                reloj11.enabled = true;
                reloj2.enabled = false;
                reloj21.enabled = false;

            }

            else if (Mathf.RoundToInt(time) % 2 == 0 && time < 10)
            {
                reloj1.enabled = false;
                reloj11.enabled = false;
                reloj2.enabled = true;
                reloj21.enabled = false;

            }

            else if (Mathf.RoundToInt(time) % 2 != 0 && time < 10)
            {
                reloj1.enabled = false;
                reloj11.enabled = false;
                reloj2.enabled = false;
                reloj21.enabled = true;

            }*/
        }

        if (time < 55)
        {
            player.canInteract = false;
            player.canMove = false;
            msgText.text = "¡Lo siento, he de irme, llego tarde!";
            msgTextAux.text = "TÚ";
            msgPanelTime.SetActive(false);
            msgPanel.SetActive(true);
            msgPanelAux.SetActive(true);
            player.GetComponent<Rigidbody2D>().velocity = new Vector2(10, 0);
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
