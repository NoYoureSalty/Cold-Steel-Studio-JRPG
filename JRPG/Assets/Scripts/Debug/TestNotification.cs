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
        {
            int randSeed = Random.Range(0, 2);
            if(randSeed == 0)
                manager.CreateNotification(text, image, time, UINotificationManager.NotificationType.Text);
            if (randSeed == 1)
                manager.CreateNotification(text, image, time, UINotificationManager.NotificationType.Sprite);
        }
	}
}
