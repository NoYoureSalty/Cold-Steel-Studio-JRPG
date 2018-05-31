using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {
    public float speed = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector3(Input.GetAxis("Horizontal"),0.0f,Input.GetAxis("Vertical"))*speed*Time.deltaTime);
	}
}
