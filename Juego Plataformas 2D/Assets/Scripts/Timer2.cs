using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer2 : MonoBehaviour {

    [SerializeField] GameObject msgPanel;
    [SerializeField] Text msgText;

    public float time;
    public float auxiliarTime;
    public bool inicio;
    public int recompensa;
    public Counter counter;

    public Renderer reloj1;
    public Renderer reloj11;
    public Renderer reloj2;
    public Renderer reloj21;

    private bool end;
    private bool restart;

    // Use this for initialization
    void Start()
    {
        time = 120.0f; //120
        auxiliarTime = 0.0f;

        inicio = false;

        msgPanel.SetActive(false);

        reloj1.enabled = true;
        reloj11.enabled = false;
        reloj2.enabled = false;
        reloj21.enabled = false;

        end = false;
        restart = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (inicio)
        {
            msgPanel.SetActive(true);
            if (time > 0)
            {
                time -= Time.deltaTime;
            }
            msgText.text = time.ToString("f0");
            recompensa = Mathf.RoundToInt(time);
            //Debug.Log(recompensa);

            if (Mathf.RoundToInt(time) % 2 == 0 && counter.contador < 3)
            {
                reloj1.enabled = true;
                reloj11.enabled = false;
                reloj2.enabled = false;
                reloj21.enabled = false;

            }

            else if (Mathf.RoundToInt(time) % 2 != 0 && counter.contador < 3)
            {
                reloj1.enabled = false;
                reloj11.enabled = true;
                reloj2.enabled = false;
                reloj21.enabled = false;

            }

            else if (Mathf.RoundToInt(time) % 2 == 0 && counter.contador >= 3)
            {
                reloj1.enabled = false;
                reloj11.enabled = false;
                reloj2.enabled = true;
                reloj21.enabled = false;

            }

            else if (Mathf.RoundToInt(time) % 2 != 0 && counter.contador >= 3)
            {
                reloj1.enabled = false;
                reloj11.enabled = false;
                reloj2.enabled = false;
                reloj21.enabled = true;

            }
        }


        if (counter.contador > 3)
        {
            auxiliarTime += Time.deltaTime;
            if (auxiliarTime > 1 && restart ==false)
            {
                

                if (PantallaDeCarga.Instancia != null)
                {
                    PantallaDeCarga.Instancia.CargarEscena("Level2");      //reiniciar el nivel
                }

                else
                {
                    SceneManager.LoadScene("Level2");
                }
                restart = true;
            }
            
        }

        if (time < 1 && end == false)
        {
            
            if (PantallaDeCarga.Instancia != null)
            {
                PantallaDeCarga.Instancia.CargarEscena("Level0.3_Hall");      //hemos ganado, pasar a la siguiente escena
            }

            else
            {
                SceneManager.LoadScene("Level0.3_Hall");
            }
            end = true;
        }

        if (Input.GetKeyDown(KeyCode.F9) && Input.GetKeyDown(KeyCode.F10))
        {
            if (PantallaDeCarga.Instancia != null)
            {
                PantallaDeCarga.Instancia.CargarEscena("Level0.3_Hall");      //se ha pasado el nivel
            }

            else
            {
                SceneManager.LoadScene("Level0.3_Hall");
            }
        }


    }
}
