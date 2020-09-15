using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupController : MonoBehaviour
{

    

    // public Transform weaponHolder;

    // public GameObject weapon;

    // ItemDatabase database;
    // PlayerInventory inventory;
    // GameObject gameController;


    // void Start() {
    //     gameController = GameObject.FindWithTag("gc");
    //     database = gameController.GetComponent<ItemDatabase>();
    //     inventory = gameController.GetComponent<PlayerInventory>();
    // }
    // void Update() {
    //     if (Input.GetKeyUp(KeyCode.G)) {
    //         DropWeapon();
    //         Debug.Log("Key \"G\" pressed...");
    //     }
    // }

    // public void PickupWeapon(GameObject _weapon) {
    //     DropWeapon();
    //     Debug.Log("Trying pickup...");

    //     // Vector3 rot = new Vector3(0,180,0);
    //     // weapon = Instantiate(database.weapons[0].weaponObj, inventory.weaponSlot[0].gameObject.transform.position,  Quaternion.Euler(rot));
    //     // weapon.transform.parent = inventory.weaponSlot[0].transform;

    //     weapon = _weapon;
    //     int wepId = weapon.GetComponent<ItemID>().itemID;
    //     weapon.transform.SetParent(weaponHolder);
    //     // GameObject.FindWithTag("GunsSlot1").transform.position.x;
    //     weapon.transform.parent = inventory.weaponSlot[0].transform;
    //     weapon.transform.rotation = inventory.weaponSlot[0].transform.rotation;
    //     weapon.transform.position = inventory.weaponSlot[0].transform.position;
    //     Debug.Log("Equipping weapon...");
    //     // weapon.transform.rotation = weaponHolder.rotation;
    // }

    // public void DropWeapon() {
    //     if (weapon != null) {
    //         weapon.GetComponent<Weapon_Pickup>().DropWeapon();
    //         weapon = null;
    //     }
    // }



    // float pickUpRange = 5f;
    // int layerMask;
    // GameObject gameController;

    // GameObject primaryWep, secondaryWep, currentWep;

    // ItemDatabase database;
    // PlayerInventory inventory;
    // Camera cam;

    // int gunIndex = 0;

    // void Start() {
    //     gameController = GameObject.FindWithTag("gc");
    //     database = gameController.GetComponent<ItemDatabase>();
    //     inventory = gameController.GetComponent<PlayerInventory>();
    //     layerMask = LayerMask.GetMask("Pickup");
    //     cam = GetComponent<Camera>();
    //     inventory.weaponSlot[1].gameObject.SetActive(true);
    // }

    // void Update() {
    //     if (Input.GetKeyDown(KeyCode.G)) {
    //         CreateGun();
    //     }
    //     Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
    //     RaycastHit hit;

    //     if (Physics.Raycast(ray, out hit, pickUpRange, layerMask)) {
    //         if (Input.GetKeyDown(KeyCode.G)) {
    //             Vector3 rot = new Vector3(0,180,0);
    //             GameObject newWep = Instantiate(database.weapons[0].weaponObj, inventory.weaponSlot[0].gameObject.transform.position,  Quaternion.Euler(rot));
    //             newWep.transform.parent = inventory.weaponSlot[0].transform;
    //     //         int id = hit.transform.GetComponent<ItemID>().itemID;

    //     //         if (database.weapons[id].weaponType == 1) {
    //     //             if (inventory.inventory[0] == id) {
    //     //                 Debug.Log("You already have this weapon.");
    //     //             } else if (inventory.inventory[0] != id) {
    //     //                 Destroy(primaryWep.gameObject);
    //     //                 inventory.inventory[0] = id;
    //     //                 primaryWep = Instantiate(database.weapons[id].weaponObj, inventory.weaponSlot[0].gameObject.transform.position, inventory.weaponSlot[0].gameObject.transform.rotation);
    //     //                 primaryWep.transform.parent = inventory.weaponSlot[0].transform;
    //     //             } else if (inventory.inventory[0] == 0) {
    //     //                 inventory.inventory[0] = id;
    //     //                 primaryWep = Instantiate(database.weapons[id].weaponObj, inventory.weaponSlot[0].gameObject.transform.position, inventory.weaponSlot[0].gameObject.transform.rotation);
    //     //                 primaryWep.transform.parent = inventory.weaponSlot[0].transform;
    //     //             }
    //     //         }
    //     //         if (database.weapons[id].weaponType == 2) {
    //     //             if (inventory.inventory[1] == id) {
    //     //                 Debug.Log("You already have this weapon.");
    //     //             } else if (inventory.inventory[1] != id) {
    //     //                 Destroy(secondaryWep.gameObject);
    //     //                 inventory.inventory[1] = id;
    //     //                 secondaryWep = Instantiate(database.weapons[id].weaponObj, inventory.weaponSlot[1].gameObject.transform.position, inventory.weaponSlot[1].gameObject.transform.rotation);
    //     //                 secondaryWep.transform.parent = inventory.weaponSlot[1].transform;
    //     //             } else if (inventory.inventory[1] == 0) {
    //     //                 inventory.inventory[1] = id;
    //     //                 secondaryWep = Instantiate(database.weapons[id].weaponObj, inventory.weaponSlot[1 ].gameObject.transform.position, inventory.weaponSlot[1].gameObject.transform.rotation);
    //     //                 secondaryWep.transform.parent = inventory.weaponSlot[1].transform;
    //     //             }
    //     //         }
    //         }
    //     }
    // }

    // void CreateGun() {
        
    // }
}
