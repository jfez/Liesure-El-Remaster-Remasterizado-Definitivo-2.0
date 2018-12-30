using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOff : MonoBehaviour {

    public Material colorInicial;
    public float fadeSpeed;
    public float alpha;

    // Use this for initialization
    void Start () {
        
        alpha = 1.0f;
		
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.GetComponent<Renderer>().material = colorInicial;
        colorInicial.color = new Color(0, 0, 0, alpha);
        alpha -= fadeSpeed * Time.deltaTime;
        if (alpha < 0)
        {
            Destroy(this.gameObject);
        }
		
	}
}
