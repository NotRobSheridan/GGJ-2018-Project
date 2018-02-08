using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLogo : MonoBehaviour {

    SpriteRenderer rend;
	// Use this for initialization
	void Start () {
        rend = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.up * -1);
        if (transform.rotation.x < -90)
            rend.flipX = true;
        else
            rend.flipX = false;
            
	}
}
