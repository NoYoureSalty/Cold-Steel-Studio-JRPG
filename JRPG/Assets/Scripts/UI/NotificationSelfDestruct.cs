using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotificationSelfDestruct : MonoBehaviour {

    public float destroyTime;

    public void OnCreation(){
        Destroy(this.gameObject, destroyTime);
    }
}
