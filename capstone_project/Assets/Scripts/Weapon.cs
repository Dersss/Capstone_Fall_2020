using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    bool ads = false;
    GameObject gunSlot;

    void Start() {
        ui = FindObjectOfType<Weapon_UI>();
        audio = GetComponent<AudioSource>();
        // audio.playOnAwake = false;   
        isActive = true;
        SetGunSlot();
    }

    void Update() {
        SetGunSlot();
        if (!isActive) {
            return;
        } 
        
        timer += Time.deltaTime;

        if (Input.GetMouseButton(0)) {
            if (ammo >= 1) {
                audio.Play();
                Shoot();
                
                Debug.Log("Shooting...");
                timer = 0f;
            }
        }
        if (Input.GetKeyDown(KeyCode.R)) {
            Reload();
        }
        if (Input.GetMouseButton(1)) {
            ads = true;
            ADS();
            // if (Input.GetMouseButton(0)) {
            //     if (ammo >= 1) {
            //         Shoot();
                    
            //         Debug.Log("Shooting...");
            //         timer = 0f;
            //     }
            // }
        } else {
            ads = false;
            gunSlot.transform.localPosition = new Vector3(0.17f, -0.17f, 0.6f);
        }

        // if (Input.GetMouseButton(0) && Input.GetMouseButton(1)) {
        //     if (ammo >= 1) {
        //         Shoot();
        //         audio.Play();
        //         Debug.Log("Shooting...");
        //         timer = 0f;
        //     }
        // }
        
    }

    void SetGunSlot() {
        if(GameObject.FindWithTag("GunSlot1").activeSelf) {
            gunSlot = GameObject.FindWithTag("GunSlot1");
        } else if (GameObject.FindWithTag("GunSlot2").activeSelf) {
            gunSlot = GameObject.FindWithTag("GunSlot2");
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
        
        ammo -= 1;
        // Handle_UI();
    }

    public RaycastHit GetHitData() {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, range)) {
            return hit;
        }

        return hit;
    }

    public void ADS() {
        Debug.Log("ADS");
        gunSlot.transform.localPosition = Vector3.Slerp(new Vector3(0, 0, 0), new Vector3(-0.17f, -22.013f, 15.416f), 1f * Time.deltaTime); 
    }
}
