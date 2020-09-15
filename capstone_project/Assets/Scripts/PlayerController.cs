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
    private PickupController pc;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        pc = GetComponent<PickupController>();
        count = 0;
        SetCountText();
        winText.text = "";
        pUp = GameObject.Find("Pickup");
        jump = new Vector3(0.0f, 2.0f, 0.0f);
        standHeight = rb.position.y;
        crouchHeight = standHeight/2;
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
        }
        
    }
    void FixedUpdate()
    {
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

        if (other.gameObject.CompareTag("Pickup")) {
            Debug.Log("Weapon/Player Collision");
            // pc.PickupWeapon(other.gameObject);
        }
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
}