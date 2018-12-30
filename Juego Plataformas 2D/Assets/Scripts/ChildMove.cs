using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildMove : MonoBehaviour {

    public Transform target;
    public float speed;

    private Vector3 start, end;

    // Use this for initialization
    void Start()
    {
        if (target != null)
        {
            target.parent = null;
            start = transform.position;
            end = target.position;
        }
    }

    // Update is called once per frame
    void Update()
    {

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
            //target.position = (target.position == start) ? end : start; //operador ternario que s epodría haber hecho en 2 ifs

            if (target.position == start)
            {
                target.position = end;
                transform.localScale = new Vector3(-0.1f, 0.1f, 0.1f);
                Debug.Log("hola");
            }

            else
            {
                target.position = start;
                transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                Debug.Log("adios");
            }
        }

    }
}
