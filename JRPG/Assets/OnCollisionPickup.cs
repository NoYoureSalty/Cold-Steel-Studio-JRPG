using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionPickup : MonoBehaviour {
	// Use this for initialization
	void Start () {
     
	}
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collided");
        Inventory inv = collision.gameObject.GetComponent<Inventory>();
        if (inv != null) {
            inv.pickUp(this.gameObject,Inventory.InventoryModes.Normal);
        }
    }

}
