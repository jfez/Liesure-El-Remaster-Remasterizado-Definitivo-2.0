using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Volver : MonoBehaviour {

    //private string nombre;

	// Use this for initialization
	void Start () {
        //nombre = "MenuInicial";
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.JoystickButton1) || Input.GetKeyDown(KeyCode.Escape))
        {
            //SceneManager.LoadScene(0); //Vuelta al menú inicial
            

            if (PantallaDeCarga.Instancia != null)
            {
                PantallaDeCarga.Instancia.CargarEscena("MenuInicial");
            }

            else
            {
                SceneManager.LoadScene("MenuInicial");
            }
        }
	}
}
