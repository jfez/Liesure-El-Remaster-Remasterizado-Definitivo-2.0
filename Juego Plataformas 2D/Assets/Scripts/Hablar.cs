using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Hablar : MonoBehaviour {

    public Timer timer;
    public PlayerController player;
    public Renderer rend;

    private bool inside;
    private bool talk;

    [SerializeField] GameObject msgPanel;
    [SerializeField] Text msgText;

    [SerializeField] GameObject msgPanelAux;

    private List<string> frases;
    private int index;


    // Use this for initialization
    void Start () {

        rend.enabled = true;

        index = -1;

        frases = new List<string>();

        frases.Add("Coge las maletas del carrito y déjalas en las habitaciones correspondientes.");
        frases.Add("¡Mucho ojo! ¡Que no se te acabe el tiempo!");
        frases.Add("Cuanto mejor lo hagas, más tiempo tendrás");
        frases.Add("Ten cuidado con las maletas que caen o perderás la que lleves encima.");
        frases.Add("");

        msgText.text = "¡Hey, tú, novato! Ven aquí que te explique lo que debes hacer.";
        msgPanel.SetActive(true);
        msgPanelAux.SetActive(true);

    }
	
	// Update is called once per frame
	void Update () {

        if (timer.inicio == false && index > 3)
        {
            timer.inicio = true;
            talk = true;
            msgPanel.SetActive(false);
            msgPanelAux.SetActive(false);
            rend.enabled = false;
        }

        if (inside == true && player.pause == false && (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.JoystickButton2) || Input.GetKeyDown(KeyCode.Return)))
        {
            if (talk == false)
            {
                index++;
                //talk = true;
                msgText.text = frases[index];
                msgPanel.SetActive(true);
                msgPanelAux.SetActive(true);
            }

            else
            {
                msgText.text = "¡Vamos! ¡Date prisa! ¡El tiempo no se detiene!";
                msgPanel.SetActive(true);
                msgPanelAux.SetActive(true);
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
            /*if (talk)
            {
                timer.inicio = true;
            }*/
                
            

        }
    }
}
