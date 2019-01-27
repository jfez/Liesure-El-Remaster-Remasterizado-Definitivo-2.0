using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mama : MonoBehaviour {

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

        frases.Add("¡Hola! No tienes pinta de llevar mucho tiempo trabajando por aquí..");
        frases.Add("¡Me recuerdas a mi cuando era más joven!");
        frases.Add("Yo trabajaba en la hostelería en verano para pagarme los estudios...");
        frases.Add("¡Qué duro era!");
        frases.Add("1: Tienes mala cara... \n2: ¡Oh, mira qué pequeñín! ¿Estás de vacaciones con mamá?");
        frases.Add("Uy, sí… no he pegado ojo esta noche porque mi niño no paraba de llorar…");
        frases.Add("Con todo el ruido y la de gente que hay por aquí...");
        frases.Add("¡Menuda idea lo de las vacaciones en familia!");
        frases.Add("La verdad es que mi niño está pasándolo genial este verano.");
        frases.Add("Desde que su padre nos dejó parecía un poco desanimado...");
        frases.Add("¡Pero mejor solos que mal acompañados!");
        frases.Add("Ay ¿Has probado la comida del restaurante?");
        frases.Add("¡No tienen casi nada para el pequeño!");
        frases.Add("El pobre está ya harto de los potitos de verduras variadas.");
        frases.Add("Vaya, me ha sentado muy bien la charla...");
        frases.Add("La necesitaba de verdad…");
        frases.Add("¡Me encargaré de que tus jefes sepan lo bien que me has tratado!");
        frases.Add("¡Ya nos veremos por aquí!");
        frases.Add("");

        //msgText.text = "¡Hey, tú, novato! Ven aquí que te explique lo que debes hacer.";
        msgTextAux.text = "MAMÁ";
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
            if (inside == true && index < 18 && decision == false && player.pause == false && player.canInteract && (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.JoystickButton2) || Input.GetKeyDown(KeyCode.Return)))
            {

                if (player.canMove)
                {
                    player.canMove = false;
                    player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                    player.transform.localPosition = new Vector3(2.67f, -4.683063f, 0f);
                    player.transform.localScale = new Vector3(-0.48016f, 0.48016f, 0.48016f);
                }
                

                if (index == 7)
                {
                    index = 11;
                    msgText.text = frases[index];
                    msgTextAux.text = "MAMÁ";
                    msgPanel.SetActive(true);
                    msgPanelAux.SetActive(true);
                }

                else
                {
                    index++;
                    msgText.text = frases[index];
                    msgTextAux.text = "MAMÁ";
                    msgPanel.SetActive(true);
                    msgPanelAux.SetActive(true);
                }

            }
        }

        else
        {
            if (inside == true && player.pause == false && player.canInteract && (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.JoystickButton2) || Input.GetKeyDown(KeyCode.Return)))
            {
                msgText.text = frases[17]; //despedida
                msgTextAux.text = "MAMÁ";
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
                msgTextAux.text = "MAMÁ";
                msgPanel.SetActive(true);
                msgPanelAux.SetActive(true);
                decision = false;
                recompensa = PlayerPrefs.GetInt("recompensa0");
                PlayerPrefs.SetInt("recompensa0", recompensa + 10);
            }

            else if (inside == true && player.pause == false && player.canInteract && (Input.GetKeyDown(KeyCode.Alpha2)) || (Input.GetKeyDown(KeyCode.Keypad2)) || (Input.GetKeyDown(KeyCode.JoystickButton5)))
            {
                index = 8;
                msgText.text = frases[index];
                msgTextAux.text = "MAMÁ";
                msgPanel.SetActive(true);
                msgPanelAux.SetActive(true);
                decision = false;
                recompensa = PlayerPrefs.GetInt("recompensa0");
                PlayerPrefs.SetInt("recompensa0", recompensa + 20);
            }
        }


        if (index == 18)
        {
            msgPanel.SetActive(false);
            msgPanelAux.SetActive(false);
            player.canMove = true;
            talk = true;
            index = 17;



            recompensa = PlayerPrefs.GetInt("recompensa0");
            PlayerPrefs.SetInt("recompensa0", recompensa+50);

            timer.conversaciones++;
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
