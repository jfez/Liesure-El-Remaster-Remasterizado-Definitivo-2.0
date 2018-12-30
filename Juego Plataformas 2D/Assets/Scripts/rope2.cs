using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rope2 : MonoBehaviour {

    public float vertSpeed = 6;
    public PlayerController2 player;

    private float v;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        v = Input.GetAxis("Vertical");
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" && (Input.GetKey(KeyCode.W) || v > 0))
        {
            col.GetComponent<Rigidbody2D>().velocity = new Vector2(0, vertSpeed);
            player.hold = true;
        }

        else if (col.gameObject.tag == "Player" && (Input.GetKey(KeyCode.S) || v < 0))
        {
            col.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -vertSpeed);
            player.hold = true;
        }

        else if (col.gameObject.tag == "Player")
        {
            col.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0.38f);
            player.hold = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            player.hold = false;
        }
    }
}
