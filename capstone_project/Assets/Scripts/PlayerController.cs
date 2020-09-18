using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    Rigidbody rb;
    Vector3 moveDirection;
    public float walkSpeed;
    public Vector3 jump;
    public float jumpForce = 2.0f;
    public bool isGrounded;
    private bool isCrouching = false;
    private int count;
    public Text countText;
    public Text winText;
    GameObject pUp;
    float crouchHeight;
    float standHeight;
    PickupController pc;
    ItemDatabase database;
    GameObject gameController, slot1, slot2, pickup;
    PlayerInventory inventory;
    int currentWepNum;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        pc = GetComponent<PickupController>();

        gameController = GameObject.FindWithTag("gc");
        database = gameController.GetComponent<ItemDatabase>();
        inventory = gameController.GetComponent<PlayerInventory>();

        count = 0;
        SetCountText();
        winText.text = "";
        pUp = GameObject.Find("Pickup");
        jump = new Vector3(0.0f, 2.0f, 0.0f);
        standHeight = rb.position.y;
        crouchHeight = standHeight/2;

        slot1 = GameObject.FindWithTag("GunSlot1");
        slot2 = GameObject.FindWithTag("GunSlot2");
        SetCurrentWeapon();
    }

    void Update() {
        
        float moveHor = Input.GetAxis("Horizontal");
        float moveVer = Input.GetAxis("Vertical");
        moveDirection = (moveHor * transform.right + moveVer * transform.forward).normalized;
        if (Input.GetKeyDown(KeyCode.LeftShift)) {
            walkSpeed *= 2;
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift)) {
            walkSpeed /= 2;
        }
        else if(Input.GetKeyDown(KeyCode.Space) && isGrounded){
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        } else if (Input.GetKeyDown(KeyCode.C)) {
            isCrouching = !isCrouching;
        } else if (Input.GetKeyDown(KeyCode.G)) {
            Pickup();
        }
        
    }
    void FixedUpdate()
    {
        SetCurrentWeapon();
        Move();
        // if (DetectCollision()) {
        //     pUp.SetActive(false);
        //     count += 1;
        //     SetCountText();
        // }
    }

    // Collision Detection just using positions
    
    bool DetectCollision() {
        bool ret = false;
        double threshold = 1.1;
        float distance = Mathf.Sqrt(Mathf.Pow((int)rb.position.x - (int)pUp.GetComponent<Rigidbody>().position.x, 2) + Mathf.Pow((int)rb.position.z - (int)pUp.GetComponent<Rigidbody>().position.z, 2));
        if (distance < threshold) {
            ret = true;
        }
        return ret;
    }
    void Move() {
        Vector3 yVelFix = new Vector3(0, rb.velocity.y, 0);
        rb.velocity = moveDirection * walkSpeed * Time.deltaTime;
        rb.velocity += yVelFix;
    }

    // Collision Detection using Collisions/Triggers

    void OnTriggerEnter(Collider other) {
        // if (other.gameObject.CompareTag("Pickup")) {
        //     other.gameObject.SetActive(false);
        //     count += 1;
        //     SetCountText();
        // }
        
        if (other.gameObject.CompareTag("Weapon")) {
            Debug.Log("Weapon/Player Collision with Weapon: " + other.gameObject.GetComponent<ItemID>().itemID);
            Debug.Log("Current Weapon: " + currentWepNum);
            pickup = other.gameObject;
            
        }
    }

    void OnTriggerExit(Collider other) {
        pickup = null;
    }

    void OnCollisionStay() {
        isGrounded = true;
    }

    void SetCountText() {
        countText.text = "Collect the boxes to win! Count: " + count.ToString();
        if (count >= 1) {
            winText.text = "You Win!";
        }
    }

    void Crouch() {
        if (isCrouching) {
            Vector3 tempPos = rb.position;
            Vector3 newPos = new Vector3(tempPos.x, standHeight, tempPos.z);
            rb.position = newPos;
        } else {
            Vector3 tempPos = rb.position;
            Vector3 newPos = new Vector3(tempPos.x, crouchHeight, tempPos.z);
            rb.position = newPos;
        }
        
    }

    void SetCurrentWeapon() {
        
        if (slot1.transform.GetChild(0).gameObject.activeSelf) {
            currentWepNum = 0;
        } else {
            currentWepNum = 1;
        }
    }

    void Pickup() {
        GameObject newWep = Instantiate(database.weapons[pickup.gameObject.GetComponent<ItemID>().itemID].weaponObj, inventory.weaponSlot[currentWepNum].gameObject.transform.position,  inventory.weaponSlot[currentWepNum].transform.GetChild(0).gameObject.transform.rotation);
        Destroy(inventory.weaponSlot[currentWepNum].transform.GetChild(0).gameObject);
        GameObject old = Instantiate(inventory.weaponSlot[currentWepNum].transform.GetChild(0).gameObject, slot1.transform.position, slot1.transform.rotation);
        newWep.transform.parent = inventory.weaponSlot[currentWepNum].transform;
        pickup.gameObject.SetActive(false);
    }
}