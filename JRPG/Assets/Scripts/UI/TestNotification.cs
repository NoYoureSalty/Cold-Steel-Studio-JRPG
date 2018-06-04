using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TestNotification : MonoBehaviour {
    public string text;
    public Sprite image;
    public float time;
    public UINotificationManager manager;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.T))
            manager.CreateNotification(text, image, time);
	}
}
