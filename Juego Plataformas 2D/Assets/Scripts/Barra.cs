using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Barra : MonoBehaviour {

    public PlayerController2 player;
    public List<int> iList;
    public Timer2 timer;
    public Renderer rend;

    public AudioSource audio;
    public AudioClip cogerBandeja;
    public AudioClip mal;

    //private float time; 

    [SerializeField] GameObject msgPanel;
    [SerializeField] Text msgText;

    [SerializeField] GameObject msgPanelAux;
    [SerializeField] Text msgTextAux;



    private List<string> frases;
    private int index;
    private bool inside;
    private bool introduction;

    // Use this for initialization
    void Start()
    {
        inside = false;
        introduction = false;
        player.nBandeja = 0;
        rend.enabled = true;

        audio = GetComponent<AudioSource>();

        iList = new List<int>();


        iList.Add(-1);
        iList.Add(-2);
        iList.Add(-3);
        iList.Add(-4);
        iList.Add(-5);
        iList.Add(1);
        iList.Add(2);
        iList.Add(3);
        iList.Add(-6);
        iList.Add(-7);
        iList.Add(-1);
        iList.Add(-2);
        iList.Add(-3);
        iList.Add(-4);
        iList.Add(-5);
        iList.Add(1);
        iList.Add(2);
        iList.Add(3);
        iList.Add(-6);
        iList.Add(-7);
        iList.Add(-1);
        iList.Add(-2);
        iList.Add(-3);
        iList.Add(-4);
        iList.Add(-5);
        iList.Add(1);
        iList.Add(2);
        iList.Add(3);
        iList.Add(-6);
        iList.Add(-7);

        index = -1;

        frases = new List<string>();

        frases.Add("Recoge las comandas en la barra.");
        frases.Add("Las bandejas de plata son para las mesas que piden y las de oro para el buffet.");
        frases.Add("¡Cuidado con los hambrientos o te quedarás sin comanda!");
        frases.Add("Y recuerda: el servicio comienza lento pero se vuelve frenético.");
        frases.Add("");

        msgText.text = "¡Chico, ven aquí! El servicio está a punto de comenzar.";
        msgTextAux.text = "COCINA";
        msgPanel.SetActive(true);
        msgPanelAux.SetActive(true);

        //time = 0.0f;



    }

    void Update()
    {


        //print(player.nBandeja);
        //time += Time.deltaTime;

        if (introduction == true && timer.inicio == false && index > 3)
        {
            timer.inicio = true;
            msgPanel.SetActive(false);
            msgPanelAux.SetActive(false);
            rend.enabled = false;
        }

        if (timer.inicio == false)
        {
            if (inside == true && player.pause == false && (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.JoystickButton2) || Input.GetKeyDown(KeyCode.Return)))
            {
                index++;
                introduction = true;
                msgTextAux.text = "COCINA";
                msgText.text = frases[index];
                msgPanel.SetActive(true);
                msgPanelAux.SetActive(true);
            }
        }


        else if (timer.inicio)
        {
            if (inside == true && player.pause == false && (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.JoystickButton2) || Input.GetKeyDown(KeyCode.Return)))
            {
                if (player != null)                             //Hay que tener cuidado con las referencias NULL
                {
                    if (iList.Count > 0)
                    {
                        if (player.nBandeja == 0)
                        {
                            audio.PlayOneShot(cogerBandeja, 1.0f);
                            player.nBandeja = iList[Random.Range(0, iList.Count - 1)];
                            msgTextAux.text = "BARRA";
                            msgText.text = "Aquí tienes, a prisa";
                            msgPanel.SetActive(true);
                            msgPanelAux.SetActive(true);

                        }

                        else
                        {
                            //Debug.Log("Ya llevas encima la maleta " + player.nMaleta);
                            msgText.text = "¡Tienes 2 manos pero cabeza solo para 1 bandeja!";
                            msgTextAux.text = "BARRA";
                            msgPanel.SetActive(true);
                            msgPanelAux.SetActive(true);
                            audio.PlayOneShot(mal, 1.0f);

                        }
                    }

                    else
                    {
                        msgText.text = "¡¡Nos hemos quedado sin comida!!";
                        msgTextAux.text = "BARRA";
                        msgPanel.SetActive(true);
                        msgPanelAux.SetActive(true);
                    }
                }

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
            /*if (introduction == true && timer.inicio == false)
            {
                timer.inicio = true;
            }*/

            inside = false;
            msgPanel.SetActive(false);
            msgPanelAux.SetActive(false);

        }
    }
}
