using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutoAlfredo : MonoBehaviour {

    public TimerHall timer;
    public Renderer rend;
    public PCH player;

    private bool inside;
    private bool talk;

    [SerializeField] GameObject msgPanel;
    [SerializeField] Text msgText;

    [SerializeField] GameObject msgPanelAux;
    [SerializeField]Text msgTextAux;


    private List<string> frases;
    private int index;
    private bool decision;
    


    // Use this for initialization
    void Start()
    {

        rend.enabled = true;

        index = -1;

        frases = new List<string>();

        frases.Add("Oh ¡Hola hijo! ¿Eres de la nueva remesa de empleados? Bienvenido al hotel.");
        frases.Add("Soy Alfredo, el gerente de empleados ya que soy el más veterano aquí, jeje.");
        frases.Add("Imagino que sabrás cómo moverte, puedes utilizar las flechitas del teclado o los sticks del mando.");
        frases.Add("No, no lo intentes ahora, mientras hables con gente en el hall, deberás mantener la compostura.");
        frases.Add("Para mostrarnos tus habilidades de salto puedes utilizar la barra espaciadora o el botón X/A del mando.");
        frases.Add("Por último, si quieres hablar con cualquiera de nosotros o recoger objetos, puedes utilizar la tecla INTRO o el botón del cuadrado/X.");
        frases.Add("No seas tímido y prueba a hablar con toda la gente que te encuentres y que tu tiempo de descanso te permita.");
        frases.Add("Piensa que siempre pueden darte algún consejo útil o contarte algo interesante.");
        frases.Add("Ten en cuenta que si haces algún tipo de pausa (con el botón ESC o START) se te restará del sueldo");
        frases.Add("¡Te permitirá descansar un rato, reiniciar el nivel o el juego y por tanto, tiene un precio!");
        frases.Add("También puedes decidir cómo tratar a tus interlocutores; no siempre vas a tener un buen día.");
        frases.Add("Para decidir entre las contestaciones puedes emplear el 1/LB/L1 o el 2/RB/R1.");
        frases.Add("¿Lo has entendido?");
        frases.Add("1: ¡Claro! \n2: No ¿podrías repetirlo?");
        frases.Add("¡Pues ale! Ya estás listo para trabajar por aquí.");
        frases.Add("1: Un placer, Alfredo. ¡Nos vemos! \n2: ¿Cómo es trabajar en el hotel?");
        frases.Add("A mi me resulta agradable y me siento realizado. ");
        frases.Add("Aunque, después de tantos años tomando esto como si fuera mi casa, manteniendo a raya el caos... ¡Y me quieren echar!");
        frases.Add("Todos los meses que llevo trabajando aquí siendo empleado del mes y ¡nada! Ni un centimito de más...");
        frases.Add("También es verdad que le robo un poquito al hotel en mis visitas al restaurante, jijiji.");
        frases.Add("1: Imagino que no sentará bien a los jefes… \n2: No será para tanto... ¡Con la de dinero que ganan!");
        frases.Add("¡Pero qué es la vida si no pequeñas alegrías!");
        frases.Add("¡Ay, qué simpático! No como el otro nuevo... ve con ojo por las habitaciones, le hemos mandado allí y se ve que no es muy diestro con las maletas");
        frases.Add("Bueno, he de seguir ya con la faena que pronto sacarán el menú en el comedor y no me lo quiero perder...");
        frases.Add("¡Hasta luego!");
        frases.Add("");

        //msgText.text = "¡Hey, tú, novato! Ven aquí que te explique lo que debes hacer.";
        msgTextAux.text = "ALFREDO";
        msgPanel.SetActive(false);
        msgPanelAux.SetActive(false);
        talk = false;
        decision = false;

    }

    // Update is called once per frame
    void Update()
    {

        if (talk == false)
        {
            if (inside == true && index < 25 && decision == false && player.pause == false && player.canInteract && (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.JoystickButton2) || Input.GetKeyDown(KeyCode.Return)))
            {
                if (player.canMove)
                {
                    player.canMove = false;
                }
                if (rend.enabled)
                {
                    rend.enabled = false;
                }

                if (index == 21)
                {
                    index = 23;
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
                msgText.text = frases[24]; //despedida
                msgPanel.SetActive(true);
                msgPanelAux.SetActive(true);
            }
            
        }

        if (index == 13)
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
                index = 10;
                msgText.text = frases[index];
                msgTextAux.text = "ALFREDO";
                msgPanel.SetActive(true);
                msgPanelAux.SetActive(true);
                decision = false;
            }
        }

        if (index == 15)
        {
            if (decision == false)
            {
                decision = true;
            }
            msgTextAux.text = "TÚ";

            if (inside == true && player.pause == false && player.canInteract && (Input.GetKeyDown(KeyCode.Alpha1)) || (Input.GetKeyDown(KeyCode.Keypad1)) || (Input.GetKeyDown(KeyCode.JoystickButton4)))
            {
                index = 23; //despedida
                msgText.text = frases[index];
                msgTextAux.text = "ALFREDO";
                msgPanel.SetActive(true);
                msgPanelAux.SetActive(true);
                decision = false;
            }

            else if (inside == true && player.pause == false && player.canInteract && (Input.GetKeyDown(KeyCode.Alpha2)) || (Input.GetKeyDown(KeyCode.Keypad2)) || (Input.GetKeyDown(KeyCode.JoystickButton5)))
            {
                index++;
                msgText.text = frases[index];
                msgTextAux.text = "ALFREDO";
                msgPanel.SetActive(true);
                msgPanelAux.SetActive(true);
                decision = false;
            }
        }

        if (index == 20)
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
                index=22;
                msgText.text = frases[index];
                msgTextAux.text = "ALFREDO";
                msgPanel.SetActive(true);
                msgPanelAux.SetActive(true);
                decision = false;
                //print(PlayerPrefs.GetInt("ayuda"));
                PlayerPrefs.SetInt("ayuda", 1);
                //print(PlayerPrefs.GetInt("ayuda"));
            }
        }

         if (index == 25)
         {
             msgPanel.SetActive(false);
             msgPanelAux.SetActive(false);
             player.canMove = true;
             talk = true;
            index = 24;
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
