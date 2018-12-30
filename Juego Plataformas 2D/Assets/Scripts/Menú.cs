using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menú : MonoBehaviour {

    public GameObject flecha, lista;
    int indice;
    private float v;
    private float v2;
    private bool up, down;
    private bool canInteract;
    private float secs;
    
    // Use this for initialization
	void Start () {
        indice = 0;

        Dibujar();

        canInteract = true;
        secs = 0.0f;

        Time.timeScale = 1;
    }

    void FixedUpdate()
    {
        
    }

    // Update is called once per frame
    void Update () {
        

        v = Input.GetAxis("Vertical");
        v2 = Input.GetAxis("DPadY");
        secs += Time.deltaTime;

        if (secs > 0.3)
        {
            canInteract = true;
        }

        if ((v > 0 || v2 > 0) && canInteract)
        {
            if (indice > 0)
            {
                indice--;
                canInteract = false;
                secs = 0;
            }
        }

        if ((v < 0 || v2 < 0) && canInteract)
        {
            if (indice < lista.transform.childCount - 1)
            {
                indice++;
                canInteract = false;
                secs = 0;
            }
        }


        if (v != 0 || v2 != 0)
        {
            Dibujar();
        }

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.JoystickButton0))
        {
            Accion();
        }

        

        
    }

    void Dibujar ()
    {
        Transform opcion = lista.transform.GetChild(indice);
        flecha.transform.position = opcion.position;
    }

    void Accion()
    {
        Transform opcion = lista.transform.GetChild(indice);
        if (opcion.gameObject.name == "salir")
        {
            print("saliendo del juego");
            Application.Quit();
        }
        else {
            //SceneManager.LoadScene(opcion.gameObject.name);
            PantallaDeCarga.Instancia.CargarEscena(opcion.gameObject.name);
        }
        
    }
}
