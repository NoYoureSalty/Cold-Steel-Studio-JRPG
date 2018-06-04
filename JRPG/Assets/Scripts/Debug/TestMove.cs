using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMove : MonoBehaviour {
    public float speed = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x >= 3 || transform.position.x <= -3)
            speed = -speed;
        transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
	}
}
