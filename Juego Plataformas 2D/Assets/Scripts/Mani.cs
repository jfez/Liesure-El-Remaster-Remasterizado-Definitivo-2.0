using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mani : MonoBehaviour {

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

        frases.Add("Señor esto está muy aburrido.");
        frases.Add("Mi mamá no me deja salir fuera, dice que hay muchísima gente y que algunos están borrachos, que puede ser peligroso…");
        frases.Add("No entiendo por qué gritan no sé qué de unas nuevas calificaciones.");
        frases.Add("¡Pero nadie ha hecho ningún examen!");
        frases.Add("Mamá dice que son cosas de mayores.");
        frases.Add("¡Pero yo me aburro mucho! ¿puede jugar conmigo?");
        frases.Add("1: No puedo, chico, estoy trabajando. \n2: Supongo que esto también contará como horas de trabajo...");
        frases.Add("Y yo que pensaba que las vacaciones eran para pasárselo bien…");
        frases.Add("Hay muy poco que hacer aquí dentro… ¡Dígaselo a sus superiores!");
        frases.Add("Hmm, a ver si alguien juega conmigo a las carreras... ¡O puedo fastidiar a la gente en el ascensor!");
        frases.Add("¡Eso es! ¡Tengo una idea!");
        frases.Add("Escóndase bien y cuando vaya con mi madre al restaurante iré a buscarle, jiji.");
        frases.Add("Si le encuentro antes ¡pierde!");
        frases.Add("¡Descuide, que nos veremos muy pronto, jejeje!");
        frases.Add("");

        //msgText.text = "¡Hey, tú, novato! Ven aquí que te explique lo que debes hacer.";
        msgTextAux.text = "MANI";
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
            if (inside == true && index < 14 && decision == false && player.pause == false && player.canInteract && (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.JoystickButton2) || Input.GetKeyDown(KeyCode.Return)))
            {

                if (player.canMove)
                {
                    player.canMove = false;
                    player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                    player.transform.localPosition = new Vector3(-7.81f, -4.683063f, 0f);
                    player.transform.localScale = new Vector3(0.48016f, 0.48016f, 0.48016f);
                    transform.localScale = new Vector3(-1f, 1f, 0.2f);
                }


                if (index == 9)
                {
                    index = 13;
                    msgText.text = frases[index];
                    msgTextAux.text = "MANI";
                    msgPanel.SetActive(true);
                    msgPanelAux.SetActive(true);
                }

                else
                {
                    index++;
                    msgText.text = frases[index];
                    msgTextAux.text = "MANI";
                    msgPanel.SetActive(true);
                    msgPanelAux.SetActive(true);
                }

            }
        }

        else
        {
            if (inside == true && player.pause == false && player.canInteract && (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.JoystickButton2) || Input.GetKeyDown(KeyCode.Return)))
            {
                msgText.text = frases[13]; //despedida
                msgTextAux.text = "MANI";
                msgPanel.SetActive(true);
                msgPanelAux.SetActive(true);
            }

        }

        if (index == 6)
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
                msgTextAux.text = "MANI";
                msgPanel.SetActive(true);
                msgPanelAux.SetActive(true);
                decision = false;

                recompensa = PlayerPrefs.GetInt("recompensa0");
                PlayerPrefs.SetInt("recompensa0", recompensa - 10);

            }

            else if (inside == true && player.pause == false && player.canInteract && (Input.GetKeyDown(KeyCode.Alpha2)) || (Input.GetKeyDown(KeyCode.Keypad2)) || (Input.GetKeyDown(KeyCode.JoystickButton5)))
            {
                index = 10;
                msgText.text = frases[index];
                msgTextAux.text = "MANI";
                msgPanel.SetActive(true);
                msgPanelAux.SetActive(true);
                decision = false;

                recompensa = PlayerPrefs.GetInt("recompensa0");
                PlayerPrefs.SetInt("recompensa0", recompensa + 30);

            }
        }


        if (index == 14)
        {
            msgPanel.SetActive(false);
            msgPanelAux.SetActive(false);
            player.canMove = true;
            talk = true;
            index = 13;
            transform.localScale = new Vector3(1f, 1f, 0.2f);
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
