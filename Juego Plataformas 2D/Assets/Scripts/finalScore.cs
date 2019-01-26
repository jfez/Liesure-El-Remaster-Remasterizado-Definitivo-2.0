using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class finalScore : MonoBehaviour {

    [SerializeField] GameObject msgPanel;
    [SerializeField] Text msgText;
    private List<string> frases;
    private int index;

    // Use this for initialization
    void Start()
    {
        
        
        index = 0;

        frases = new List<string>();

        frases.Add("Y ahora una buena siesta…");
        frases.Add("¡Oh, hola joven! ¿Qué tal todo? ¿Hoy te despides de nosotros? ");
        frases.Add("¿Que te vas de vacaciones? Y yo que pensaba que te habrías cansado de turistas…");
        frases.Add("¡Has hecho un muy buen trabajo este verano!"); //1
        frases.Add("Da gusto trabajar con muchachos tan aplicados como tú."); //2
        frases.Add("Aunque la chispa y la ilusión se pierden tan rápido… Una pena."); //3
        frases.Add("Pero bueno, vamos a lo que importa... tu sueldo.");
        frases.Add("Por el trabajo llevando maletas te han pagado " + PlayerPrefs.GetInt("recompensa1") + " euros.");
        frases.Add("No es mucho... pero bueno, tampoco esperarías hacerte rico ¿verdad?");
        frases.Add("Luego, por tu empleo como camarero has ganado " + PlayerPrefs.GetInt("recompensa2") *10 + " euros.");
        frases.Add("Que tampoco es una maravilla pero para ir tirando... ahí está.");
        frases.Add("Y haciendo un balance de las opiniones positivas y negativas de los huéspedes sobre ti, recibes " + PlayerPrefs.GetInt("recompensa0") + " euros en propinas."); //1
        frases.Add("Se nota que eres un buen chico.");//2
        frases.Add("Pero claro... a todo eso hay que descontarle " + PlayerPrefs.GetInt("pausas") * 10 + " euros por tus descansitos.");
        frases.Add("Así que se te queda en unos fantásticos " + Mathf.Max(PlayerPrefs.GetInt("recompensa0") + PlayerPrefs.GetInt("recompensa1") + PlayerPrefs.GetInt("recompensa2") * 10 - PlayerPrefs.GetInt("pausas") * 10, 0) + " euros por 3 meses trabajados.");
        frases.Add("Y da gracias que no eres tú el que paga por trabajar.");
        frases.Add("¡Espero verte manos a la obra de nuevo muy pronto!");
        frases.Add("Como si tuvieras otra opción...");
        frases.Add("¿Qué? Nada, nada, es que ya chocheo, no te preocupes.");
        frases.Add("¡Hasta muy pronto!");
        frases.Add("");

        msgPanel.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {

        if (index <= 19)
        {
            msgText.text = frases[index];
        }
        

        if ((Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.JoystickButton2) || Input.GetKeyDown(KeyCode.Return)))
        {
            index++;
        }

        if (index == 13 && PlayerPrefs.GetInt("pausas") == 0)
        {
            index = 14;
        }

        if (index == 19)
        {
            
            if (PantallaDeCarga.Instancia != null)
            {
                PantallaDeCarga.Instancia.CargarEscena("MenuInicial");
            }

            else
            {
                SceneManager.LoadScene("MenuInicial");
            }
            index++;
        }

    }
}
