using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menúPausa : MonoBehaviour {

    public GameObject flecha, lista;
    public PlayerController player;
    public PlayerController2 player2;
    public PCH player3;

    int indice;
    private float v;

    private float v2;
    //private bool up, down;
    private bool canInteract;
    private float secs;

    // Use this for initialization
    void Start()
    {
        indice = 0;

        Dibujar();

        canInteract = true;
        secs = 0.0f;

        //Time.timeScale = 1;
    }

    void FixedUpdate()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //print(Input.mousePosition.y);
        v = Input.GetAxis("Vertical");
        //print(v);
        v2 = Input.GetAxis("DPadY");
        secs += Time.unscaledDeltaTime;
        //print(secs);

        if (secs > 0.3)
        {
            canInteract = true;
        }

        if ((Input.GetKeyDown(KeyCode.UpArrow) || v2 > 0 || v > 0) && canInteract)
        {
            if (indice > 0)
            {
                indice--;
                //print("hola");
                canInteract = false;
                secs = 0;
            }
        }

        if ((Input.GetKeyDown(KeyCode.DownArrow) || v2 < 0 || v < 0) && canInteract)
        {
            if (indice < lista.transform.childCount - 1)
            {
                indice++;
                //print("adiós");
                canInteract = false;
                secs = 0;
            }
        }


        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || v2 != 0 || v != 0)
        {
            Dibujar();
        }

        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.JoystickButton7))
        {
            indice = 0;

            Dibujar();
        }

        


        if (player2 == null && player3 == null)
        {
            if (player.pause && (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.JoystickButton0)))
            {
                Accion();
            }
        }

        else if (player == null && player3 == null)
        {
            if (player2.pause && (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.JoystickButton0)))
            {
                Accion();
            }
        }

        else if (player == null && player2 == null)
        {
            if (player3.pause && (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.JoystickButton0)))
            {
                Accion();
            }
        }


        




    }

    void Dibujar()
    {
        Transform opcion = lista.transform.GetChild(indice);
        flecha.transform.position = opcion.position;
    }

    void Accion()
    {
        Transform opcion = lista.transform.GetChild(indice);
        /*if (opcion.gameObject.name == "salir")
        {
            print("saliendo del juego");
            Application.Quit();
        }*/


        //SceneManager.LoadScene(opcion.gameObject.name);

        if (PantallaDeCarga.Instancia != null)
        {
            if (opcion.gameObject.name == "inicial")
            {
                
                PantallaDeCarga.Instancia.CargarEscena("MenuInicial");
            }

            else if (opcion.gameObject.name == "1")
            {
                
                PantallaDeCarga.Instancia.CargarEscena("Level1");
            }

            else if (opcion.gameObject.name == "2")
            {
                PantallaDeCarga.Instancia.CargarEscena("Level2");
            }
        }

        else
        {
            if (opcion.gameObject.name == "inicial")
            {

                SceneManager.LoadScene("MenuInicial");
            }

            else if (opcion.gameObject.name == "1")
            {

                SceneManager.LoadScene("Level1");
            }

            else if (opcion.gameObject.name == "2")
            {
                SceneManager.LoadScene("Level2");
            }
        }

        
        
        

    }
}
