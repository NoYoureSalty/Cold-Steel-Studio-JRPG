//If you break this I will kill you :b

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
    public Dictionary<int, InventoryInterface> pInventory = new Dictionary<int, InventoryInterface>();
    public Dictionary<int, InventoryInterface> bInventory = new Dictionary<int, InventoryInterface>();

    public PlayerSettings settings;
    public UINotificationManager notificationManager;

    public int pInventorySize = 0;
    public int bInventorySize = 0;
    public float pInventoryMaxVolume = 0;
    public float bInventoryMaxVolume = 0;
    public float pInventoryMaxWeight = 0;
    //public float bInventoryMaxWeight = 0;
    public float carryWeight;
    public float carryWeightLimit;

    //Keywords
    public enum InventoryModes : int {Slot = 0, Normal = 1};
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}
    //adds object to inventory
    public void AddToInventory(InventoryInterface inter, InventoryModes mode)
    {
        if (mode == InventoryModes.Slot)
        {
            if (pInventory.Count < pInventorySize)
            {
                for (int i = 1; i <= pInventorySize; i++)
                {
                    if (!pInventory.ContainsKey(i))
                    {
                        pInventory.Add(i, inter);
                        inter.added = true;
                        break;
                    }
                }

            }
            else if (bInventory.Count < bInventorySize)
            {
                for (int i = 1; i <= bInventorySize; i++)
                {
                    if (!bInventory.ContainsKey(i))
                    {
                        bInventory.Add(i, inter);
                        inter.added = true;
                        break;
                    }
                }
            }
            else
            {
                return;
            }
        }

        if (mode == InventoryModes.Normal)
        {
            //Weights and volumes
            float currentWeight = 0;
            float currentpVolume = 0;
            float currentbVolume = 0;
            float currentpWeight = 0;
            //only limiting factor is pInventoryMaxWeight, making below obs
            //float currentbWeight = 0;
            //determine current weights and volumes if in hardcore
            foreach (InventoryInterface inv in pInventory.Values)
            {
                currentWeight += inv.weight;
                currentpWeight += inv.weight;
                if (settings.hardcore)
                    currentpVolume += inv.volume;
            }
            foreach (InventoryInterface inv in bInventory.Values)
            {
                currentWeight += inv.weight;
                //only limiting factor is pInventoryMaxWeight, making below obs
                //currentbWeight += inv.weight
                if (settings.hardcore)
                    currentbVolume += inv.volume;
            }
            //determine if 
            if (currentWeight + inter.weight <= carryWeightLimit)
            {
                currentWeight += inter.weight;
                //hardcore rules
                if (settings.hardcore)
                {
                    //try to add to pInventory
                    if (currentpVolume + inter.volume <= pInventoryMaxVolume && currentpWeight + inter.weight <= pInventoryMaxWeight)
                    {
                        for (int i = 1; i <= pInventorySize; i++)
                        {
                            if (!pInventory.ContainsKey(i))
                            {
                                pInventory.Add(i, inter);
                                inter.added = true;
                                break;
                            }
                        }
                    }
                    //if fails, try to add to bInventory
                    else
                    {
                        if (currentbVolume + inter.volume <= bInventoryMaxVolume /*&& currentbWeight + inter.weight <= bInventoryMaxWeight*/)
                        {
                            for (int i = 1; i <= bInventorySize; i++)
                            {
                                if (!bInventory.ContainsKey(i))
                                {
                                    bInventory.Add(i, inter);
                                    inter.added = true;
                                    break;
                                }
                            }
                        }
                        //if fails, do nothing
                        else
                        {
                            return;
                        }
                    }
                }
                //normal rules
                else
                {
                    //try to add to pInventory
                    if (currentpWeight + inter.weight <= pInventoryMaxWeight)
                    {
                        
                        for (int i = 1; i <= pInventorySize; i++)
                        {
                            if (!pInventory.ContainsKey(i))
                            {
                                pInventory.Add(i, inter);
                                inter.added = true;
                                break;
                            }
                        }
                    }
                    //if fails, try to add to bInventory
                    else
                    {
                        //add to bInventory if possible (weight not currently factor so most is commented)
                        //if (currentbWeight + inter.weight <= bInventoryMaxWeight)
                        //{
                        for (int i = 1; i <= bInventorySize; i++)
                        {
                            if (!bInventory.ContainsKey(i))
                            {
                                bInventory.Add(i, inter);
                                inter.added = true;
                                break;
                            }
                        }
                        //}
                        //if fails, do nothing/
                        //else{
                        //return;
                        //}
                    }
                }
            }
            //update carryweight
            carryWeight = currentWeight;
        }
        Debug.Log("pInventory count:" + pInventory.Count);
        Debug.Log("bInventory count:" + bInventory.Count);
    }

    public void pickUp(GameObject item, InventoryModes addMode){
        
        InventoryInterface invItem = item.GetComponent<InventoryInterface>();
        AddToInventory(invItem, addMode);
        if (invItem.added)
        {
            notificationManager.CreateNotification(invItem.itemName + " has been added to your inventory", null, 3,UINotificationManager.NotificationType.Text);
            Destroy(item);
        }
    }

}