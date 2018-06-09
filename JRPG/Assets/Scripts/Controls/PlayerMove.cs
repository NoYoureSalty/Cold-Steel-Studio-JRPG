using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {
    public float walkspeed = 0;
    public float runspeed = 0;
    public float zmod;
    float speed;
    float speedmod = 1;
    bool walkToggle = false;
    Rigidbody rigid;
	// Use this for initialization
	void Start () {
        speed = runspeed;
        rigid = GetComponent<Rigidbody>();
	}
	//Physics subrutine
	private void FixedUpdate()
	{
        //movement
        rigid.velocity = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical") * zmod) * speed * speedmod;
	}
	// Update is called once per frame
	void Update () {
       
        //walk toggle
        if(Input.GetKeyDown(KeyCode.V))
            walkToggle = !walkToggle;
        if (walkToggle)
            speed = walkspeed;
        if (!walkToggle)
            speed = runspeed;
	}
}
