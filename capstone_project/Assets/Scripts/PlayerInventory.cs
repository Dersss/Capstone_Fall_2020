using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{

    public int[] inventory;
    public GameObject[] weaponSlot;

    // Start is called before the first frame update
    void Start()
    {
        weaponSlot = new GameObject[2];
        inventory = new int[2];

        weaponSlot[0] = GameObject.FindWithTag("GunSlot1");
        weaponSlot[1] = GameObject.FindWithTag("GunSlot2");
        inventory[0] = weaponSlot[0].transform.GetChild(0).transform.GetComponent<ItemID>().itemID;
        inventory[1] = weaponSlot[1].transform.GetChild(0).transform.GetComponent<ItemID>().itemID;

        
        
    }

}
