using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour {

	private PlayerController player;
    private Rigidbody2D rb2d;
    


    
    // Use this for initialization
	void Start ()
    {
        player = GetComponentInParent<PlayerController>(); //Poder acceder a las variables públicas de player
        rb2d = GetComponentInParent<Rigidbody2D>();
        
    }

    void OnCollisionEnter2D(Collision2D col)        //La primera vez que toca una plataforma
    {
        if (col.gameObject.tag == "Plataforma")
        {
            rb2d.velocity = new Vector3(0f, 0f, 0f);
            player.transform.parent = col.transform;
            player.grounded = true;
            
        }
    }
	
	void OnCollisionStay2D(Collision2D col)             //Comprobar el objeto contra el que se está colisionando
    {
        if(col.gameObject.tag == "Ground")
        {
            player.grounded = true;
            //Debug.Log("Hello");
        }

        if (col.gameObject.tag == "MainGround")
        {
            player.grounded = true;
        }

        if (col.gameObject.tag == "Plataforma")
        {
            player.transform.parent = col.transform;
            player.grounded = true;
        }

    }

    void OnCollisionExit2D (Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            player.grounded = false;
            
        }

        if (col.gameObject.tag == "MainGround")
        {
            player.grounded = false;
        }

        if (col.gameObject.tag == "Plataforma")
        {
            player.transform.parent = null;
            player.grounded = false;
        }
    }

}
