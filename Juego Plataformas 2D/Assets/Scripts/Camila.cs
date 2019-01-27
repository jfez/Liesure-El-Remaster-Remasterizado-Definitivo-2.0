using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Camila : MonoBehaviour {

    public TimerHall timer;
    public PCH player;

    private bool inside;
    private bool talk;

    [SerializeField] GameObject msgPanel;
    [SerializeField] Text msgText;

    [SerializeField] GameObject msgPanelAux;
    [SerializeField] Text msgTextAux;


    private List<string> frases;
    private int index;
    private bool decision;
    private int recompensa;



    // Use this for initialization
    void Start()
    {



        index = -1;

        frases = new List<string>();

        frases.Add("¡Hola! Eres nuevo por aquí ¿verdad?");
        frases.Add("Yo soy Camila, pero me llaman la Kelly…");
        frases.Add("¡¡La que limpia, jajajaja!!");
        frases.Add("Siempre me ha hecho mucha gracia ese juego de palabras y para nosotras es muy reivindicativo.");
        frases.Add("1: Encantado ¿Qué tal el trabajo? \n2: ¡Ingenioso! ¿Qué me deparará vivir aquí, tú cómo lo llevas?");
        frases.Add("Es un desastre con tanta maleta por el suelo.");
        frases.Add("¡Luego es a mi a quien le toca recoger bragas de abuela!");
        frases.Add("Ten cuidado con las bandejas si te toca turno en el restaurante, por favor te lo pido.");
        frases.Add("Prefiero hacer de canguro de ese niño repelente antes que limpiar otra mancha de tomate de la moqueta.");
        frases.Add("¡No puedo más!");
        frases.Add("Mi casero, que dice que me echa; que en una semana de alquilar el piso a turistas saca el doble de lo que le pago yo en un año.");
        frases.Add("No sé qué hacer…");
        frases.Add("Supongo que hoy haré turno doble.");
        frases.Add("Mi mamá se ha puesto enferma y necesito mandarle más dinero a Cuba para el medicamento.");
        frases.Add("Llevo tres meses sin cobrar las horas extra...");
        frases.Add("Pero si no me quedo, me echan a la calle.");
        frases.Add("No tengo elección, necesito el dinero…");
        frases.Add("Camila ¡basta de penurias y ponte manos a la obra!");
        frases.Add("¡¡Venga, no me entretengas más y sobre todo, no me pises lo fregado!!");
        frases.Add("");

        //msgText.text = "¡Hey, tú, novato! Ven aquí que te explique lo que debes hacer.";
        msgTextAux.text = "CAMILA";
        msgPanel.SetActive(false);
        msgPanelAux.SetActive(false);
        talk = false;
        decision = false;


        //print (PlayerPrefs.GetInt("recompensa0"));

    }

    // Update is called once per frame
    void Update()
    {

        if (talk == false)
        {
            if (inside == true && index < 19 && decision == false && player.pause == false && player.canInteract && (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.JoystickButton2) || Input.GetKeyDown(KeyCode.Return)))
            {

                if (player.canMove)
                {
                    player.canMove = false;
                    player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                    player.transform.localPosition = new Vector3(0.96f, -4.683063f, 0f);
                    player.transform.localScale = new Vector3(0.48016f, 0.48016f, 0.48016f);
                }


                if (index == 8)
                {
                    index = 12;
                    msgText.text = frases[index];
                    msgTextAux.text = "CAMILA";
                    msgPanel.SetActive(true);
                    msgPanelAux.SetActive(true);
                }

                else
                {
                    index++;
                    msgText.text = frases[index];
                    msgTextAux.text = "CAMILA";
                    msgPanel.SetActive(true);
                    msgPanelAux.SetActive(true);
                }

            }
        }

        else
        {
            if (inside == true && player.pause == false && player.canInteract && (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.JoystickButton2) || Input.GetKeyDown(KeyCode.Return)))
            {
                msgText.text = frases[18]; //despedida
                msgTextAux.text = "CAMILA";
                msgPanel.SetActive(true);
                msgPanelAux.SetActive(true);
            }

        }

        if (index == 4)
        {
            if (decision == false)
            {
                decision = true;
            }
            msgTextAux.text = "TÚ";

            if (inside == true && player.pause == false && player.canInteract && (Input.GetKeyDown(KeyCode.Alpha1)) || (Input.GetKeyDown(KeyCode.Keypad1)) || (Input.GetKeyDown(KeyCode.JoystickButton4)))
            {
                index++;
                msgText.text = frases[index];
                msgTextAux.text = "CAMILA";
                msgPanel.SetActive(true);
                msgPanelAux.SetActive(true);
                decision = false;

            }

            else if (inside == true && player.pause == false && player.canInteract && (Input.GetKeyDown(KeyCode.Alpha2)) || (Input.GetKeyDown(KeyCode.Keypad2)) || (Input.GetKeyDown(KeyCode.JoystickButton5)))
            {
                index = 9;
                msgText.text = frases[index];
                msgTextAux.text = "CAMILA";
                msgPanel.SetActive(true);
                msgPanelAux.SetActive(true);
                decision = false;

            }
        }


        if (index == 19)
        {
            msgPanel.SetActive(false);
            msgPanelAux.SetActive(false);
            player.canMove = true;
            talk = true;
            index = 18;
            timer.conversaciones++;


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
