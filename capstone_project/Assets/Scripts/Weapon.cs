using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Weapon_Pickup))]
[RequireComponent(typeof(AudioSource))]
public class Weapon : MonoBehaviour
{
    public int itemID;
    public int weaponType;
    public string name;
    public GameObject weaponObj;
    public float damage;
    public float fireRate;
    public float range;
    public float ammo;
    public float maxAmmo;
    public float totalAmmo;
    public Sprite customCrossHair;
    public Camera cam;
    private Weapon_UI ui;
    private AudioSource audio;
    private bool isActive;
    private float timer = 0f;

    void Start() {
        ui = FindObjectOfType<Weapon_UI>();
        audio = GetComponent<AudioSource>();
        audio.playOnAwake = false;
    }

    void Update() {
        if (!isActive) {
            return;
        } 
        
        timer += Time.deltaTime;

        if (Input.GetMouseButton(0)) {
            if (ammo >= 1) {
                Shoot();
                Debug.Log("Shooting...");
                timer = 0f;
            }
        }
        if (Input.GetKeyDown(KeyCode.R)) {
            Reload();
        }
    }

    public void WeaponIsActive(bool _value) {
        isActive = _value;

        if (isActive) {
            ui.SetCrossHair(customCrossHair);
        } else {
            ui.Hide_UI();
        }
    }

    public void Handle_UI() {
        ui.Update_UI(ammo, maxAmmo);
    }

    public virtual void Reload() {
        if (maxAmmo <= totalAmmo) {
            totalAmmo += ammo;
            ammo = 0;
            totalAmmo -= maxAmmo;
            ammo += maxAmmo;
        } else {
            ammo += totalAmmo;
        }

        Handle_UI();
    }

    public virtual void Shoot() {
        audio.Play();
        ammo -= 1;
        Handle_UI();
    }

    public RaycastHit GetHitData() {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, range)) {
            return hit;
        }

        return hit;
    }
}
