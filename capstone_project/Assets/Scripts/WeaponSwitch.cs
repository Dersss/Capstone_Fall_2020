using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    int weaponSelected = 1;

    [SerializeField]
    public GameObject primary, secondary;

    void Start() {
        SwapWeapon(1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            if (weaponSelected != 1) {
                SwapWeapon(1);
                weaponSelected = 1;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) {
            if (weaponSelected != 2) {
                SwapWeapon(2);
                weaponSelected = 2;
            }
        }
    }

    void SwapWeapon(int weaponType) {
        if (weaponType == 1) {
            primary.transform.GetChild(0).gameObject.SetActive(true);
            secondary.transform.GetChild(0).gameObject.SetActive(false);
        }
        if (weaponType == 2) {
            primary.transform.GetChild(0).gameObject.SetActive(false);
            secondary.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
