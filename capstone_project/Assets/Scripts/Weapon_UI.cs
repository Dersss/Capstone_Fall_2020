using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   

public class Weapon_UI : MonoBehaviour
{

    public Text ammoText;

    public Image crosshair;



    // Start is called before the first frame update
    void Start() {
        Hide_UI();
    }

    // Update is called once per frame
    public void Update_UI(float _ammo, float _maxAmmo) {
        if (!ammoText.gameObject.activeInHierarchy) {
            ammoText.gameObject.SetActive(true);
        }
        ammoText.text = _ammo.ToString() + " / " + _maxAmmo.ToString();
    }

    public void SetCrossHair(Sprite _sprite) {
        if (!crosshair.gameObject.activeInHierarchy) {
            crosshair.gameObject.SetActive(true);
        }
    }

    public void Hide_UI() {
        // if (ammoText.gameObject != null) {
        //     ammoText.gameObject.SetActive(false);
        //     crosshair.gameObject.SetActive(false);
        // }
        
    }
    
}
