using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {

    
    public Spawner spawn;
    public GameObject sprite;





    // Use this for initialization
    void Start () {
        
        
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log("Destroy"+spawn.player.carry);
       
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "MainGround")
        {
            sprite.GetComponent<Renderer>().enabled = false;
            Destroy(gameObject, 0.9f);

        }

        /*if (col.gameObject.tag == "Player")
        {
            if (spawn.player.carry == true)
            {
                
                spawn.player.carry = false;
                punch.Play();
                sprite.GetComponent<Renderer>().enabled = false;
            }

            else
            {
                
                punch.Play();
                sprite.GetComponent<Renderer>().enabled = false;
                
            }

            
            Destroy(gameObject, 0.9f);
            
            
        }*/
    }
}
