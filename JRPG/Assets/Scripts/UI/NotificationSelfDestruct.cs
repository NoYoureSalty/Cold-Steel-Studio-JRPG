using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotificationSelfDestruct : MonoBehaviour {

    public float destroyTime;
    public UINotificationManager.NotificationType type;

	private void Update()
	{
	    
	}
	public void OnCreation(){
        Destroy(this.gameObject, destroyTime);
    }
}
