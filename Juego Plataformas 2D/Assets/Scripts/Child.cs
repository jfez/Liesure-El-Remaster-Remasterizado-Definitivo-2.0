using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Child : MonoBehaviour {

    public Transform target;
    public float speed;
    public Rigidbody2D rb2d;

    private Vector3 start, end;
    private Vector2 left, right;
    private bool ida;

    public AudioSource audio;
    public AudioClip risa;

    // Use this for initialization
    void Start () {
        ida = true;
        audio = GetComponent<AudioSource>();
        if (target != null)
        {
            target.parent = null;
            start = transform.position;
            end = target.position;
            left = new Vector2(-1.0f, 1.0f);
            right = new Vector2(1.0f, 1.0f);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate()
    {
        if (target != null)
        {
            float fixedSpeed = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, fixedSpeed);
        }

        if (transform.position == target.position)
        {
            

        if (target.position == start)
            {
                target.position = end;
                transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                ida = true;
            }

        else
            {
                target.position = start;
                transform.localScale = new Vector3(-0.2f, 0.2f, 0.2f);
                ida = false;
            }
        }

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            audio.PlayOneShot(risa, 1.0f);
            if (ida)
            {
                rb2d.AddForce(left * 5, ForceMode2D.Impulse);
            }

            else
            {
                rb2d.AddForce(right * 5, ForceMode2D.Impulse);
            }

        }
    }
}


