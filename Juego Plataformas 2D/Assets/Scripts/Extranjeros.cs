using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Extranjeros : MonoBehaviour {

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

        frases.Add("Hey you!");
        frases.Add("Here, bring us some drinks!");
        frases.Add("1: Sorry, mi dont espik inglish. \n2: You may excuse me but I haven’t been assigned to drinking duties.");
        frases.Add("How’s that? You don’t understand us?");
        frases.Add("Aren’t you supposed to attend us?");
        frases.Add("Oh my god, for real?");
        frases.Add("That’s how you treat a customer?");
        frases.Add("This people…");
        frases.Add("This whole place is standing ‘cause of us, the foreign tourists and they don’t even try to serve us!");
        frases.Add("Leave, we’ll find someone more useful than you. Now GO!");
        frases.Add("");

        //msgText.text = "¡Hey, tú, novato! Ven aquí que te explique lo que debes hacer.";
        msgTextAux.text = "EXTRANJEROS";
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
            if (inside == true && index < 10 && decision == false && player.pause == false && player.canInteract && (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.JoystickButton2) || Input.GetKeyDown(KeyCode.Return)))
            {

                if (player.canMove)
                {
                    player.canMove = false;
                    player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                    player.transform.localPosition = new Vector3(10.81f, -4.683063f, 0f);
                    player.transform.localScale = new Vector3(-0.48016f, 0.48016f, 0.48016f);
                    transform.localScale = new Vector3(-0.4f, 0.4f, 0.11201f);
                }


                if (index == 4)
                {
                    index = 7;
                    msgText.text = frases[index];
                    msgTextAux.text = "EXTRANJEROS";
                    msgPanel.SetActive(true);
                    msgPanelAux.SetActive(true);
                }

                else
                {
                    index++;
                    msgText.text = frases[index];
                    msgTextAux.text = "EXTRANJEROS";
                    msgPanel.SetActive(true);
                    msgPanelAux.SetActive(true);
                }

            }
        }

        else
        {
            if (inside == true && player.pause == false && player.canInteract && (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.JoystickButton2) || Input.GetKeyDown(KeyCode.Return)))
            {
                msgText.text = frases[9]; //despedida
                msgTextAux.text = "EXTRANJEROS";
                msgPanel.SetActive(true);
                msgPanelAux.SetActive(true);
            }

        }

        if (index == 2)
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
                msgTextAux.text = "EXTRANJEROS";
                msgPanel.SetActive(true);
                msgPanelAux.SetActive(true);
                decision = false;
                recompensa = PlayerPrefs.GetInt("recompensa0");
                PlayerPrefs.SetInt("recompensa0", recompensa - 30);
            }

            else if (inside == true && player.pause == false && player.canInteract && (Input.GetKeyDown(KeyCode.Alpha2)) || (Input.GetKeyDown(KeyCode.Keypad2)) || (Input.GetKeyDown(KeyCode.JoystickButton5)))
            {
                index = 5;
                msgText.text = frases[index];
                msgTextAux.text = "EXTRANJEROS";
                msgPanel.SetActive(true);
                msgPanelAux.SetActive(true);
                decision = false;
                recompensa = PlayerPrefs.GetInt("recompensa0");
                PlayerPrefs.SetInt("recompensa0", recompensa - 10);
            }
        }


        if (index == 10)
        {
            msgPanel.SetActive(false);
            msgPanelAux.SetActive(false);
            player.canMove = true;
            talk = true;
            index = 9;
            transform.localScale = new Vector3(0.4f, 0.4f, 0.11201f);
            timer.conversaciones++;


            //recompensa = PlayerPrefs.GetInt("recompensa0");
            //PlayerPrefs.SetInt("recompensa0", recompensa + 50);
            //print(PlayerPrefs.GetInt("recompensa0"));
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
