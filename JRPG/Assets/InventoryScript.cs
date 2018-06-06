using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScript : MonoBehaviour
{
    public Inventory inventory;
    public UINotificationManager notificationmanager;
    public GameObject inter;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            InventoryInterface itemdetails = inter.GetComponent<InventoryInterface>();
            int pOldCount = inventory.pInventory.Count;
            int bOldCount = inventory.bInventory.Count;
            inventory.pickUp(inter, Inventory.InventoryModes.Normal);
            if (pOldCount < inventory.pInventory.Count || bOldCount < inventory.bInventory.Count)
                notificationmanager.CreateNotification(itemdetails.itemName + " has been added to your inventory", null, 3);
        }
    }
}
