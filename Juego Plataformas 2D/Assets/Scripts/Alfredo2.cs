using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Alfredo2 : MonoBehaviour {

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

        frases.Add("¿Ya has pasado por las habitaciones, hijo?");
        frases.Add("Te habrás encontrado con el chico nuevo, lo han mandado a las plantas de arriba.");
        frases.Add("¡Dicen que está armando un buen revuelo tirando maletas por doquier, jajaja!");
        frases.Add("...");
        frases.Add("Ay... juventud divino tesoro…");
        frases.Add("¡Aprovechad vosotros que aún tenéis tiempo y energías!");
        frases.Add("A mi edad, si me voy del hotel ya no sabré qué hacer…");
        frases.Add("1: ¡No sufra! Podrá hacer turismo, como el 99% de la gente aquí... \n2: Tiene razón, el hotel es un buen lugar.");
        frases.Add("Pero ya no podré volver al restaurante…");
        frases.Add("Qué bien me lo paso y qué buena está la comida...");
        frases.Add("Cuando tengas turno allí, ten en cuenta que la gente no suele quejarse si le traen la comida VIP del buffet.");
        frases.Add("Si preguntan los jefes, yo nunca habré dicho eso…");
        frases.Add("Pero igual te ayuda para salvarte de la ira de los clientes alguna vez.");
        frases.Add("Qué bien, chico, me encanta que te guste trabajar por aquí.");
        frases.Add("¡Por fin alguien que lo aprecia como yo!");
        frases.Add("Bueno, te dejo que enseguida abre el restaurante y esos bistecs no se van a gorronear solos… jejeje.");
        frases.Add("¡Hasta pronto!");
        frases.Add("");

        //msgText.text = "¡Hey, tú, novato! Ven aquí que te explique lo que debes hacer.";
        msgTextAux.text = "ALFREDO";
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
            if (inside == true && index < 17 && decision == false && player.pause == false && player.canInteract && (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.JoystickButton2) || Input.GetKeyDown(KeyCode.Return)))
            {

                if (player.canMove)
                {
                    player.canMove = false;
                    player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                    player.transform.localPosition = new Vector3(12.52f, -4.683063f, 0f);
                    player.transform.localScale = new Vector3(0.48016f, 0.48016f, 0.48016f);
                }


                if (index == 12)
                {
                    index = 15;
                    msgText.text = frases[index];
                    msgTextAux.text = "ALFREDO";
                    msgPanel.SetActive(true);
                    msgPanelAux.SetActive(true);
                }

                else
                {
                    index++;
                    msgText.text = frases[index];
                    msgTextAux.text = "ALFREDO";
                    msgPanel.SetActive(true);
                    msgPanelAux.SetActive(true);
                }

            }
        }

        else
        {
            if (inside == true && player.pause == false && player.canInteract && (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.JoystickButton2) || Input.GetKeyDown(KeyCode.Return)))
            {
                msgText.text = frases[16]; //despedida
                msgTextAux.text = "ALFREDO";
                msgPanel.SetActive(true);
                msgPanelAux.SetActive(true);
            }

        }

        if (index == 7)
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
                msgTextAux.text = "ALFREDO";
                msgPanel.SetActive(true);
                msgPanelAux.SetActive(true);
                decision = false;
                
            }

            else if (inside == true && player.pause == false && player.canInteract && (Input.GetKeyDown(KeyCode.Alpha2)) || (Input.GetKeyDown(KeyCode.Keypad2)) || (Input.GetKeyDown(KeyCode.JoystickButton5)))
            {
                index = 13;
                msgText.text = frases[index];
                msgTextAux.text = "ALFREDO";
                msgPanel.SetActive(true);
                msgPanelAux.SetActive(true);
                decision = false;
                
            }
        }


        if (index == 17)
        {
            msgPanel.SetActive(false);
            msgPanelAux.SetActive(false);
            player.canMove = true;
            talk = true;
            index = 16;
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
