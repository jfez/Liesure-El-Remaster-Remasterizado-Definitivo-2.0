using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endCredits : MonoBehaviour {

    private float time;
    private bool cargando;

    // Use this for initialization
    void Start () {
        time = 0.0f;
        cargando = false;
    }
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;

        if (time > 34.0f && cargando == false)
        {
            if (PantallaDeCarga.Instancia != null)
            {
                PantallaDeCarga.Instancia.CargarEscena("MenuInicial");
                cargando = true;
            }

            else
            {
                SceneManager.LoadScene("MenuInicial");
                cargando = true;
            }
        }
    }
}
