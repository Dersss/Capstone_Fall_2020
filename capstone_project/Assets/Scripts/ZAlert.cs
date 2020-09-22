using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZAlert : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {


    if (!animator.GetBool("Idle"))
    {

        if (Input.GetKey(KeyCode.I))
        {
            animator.SetBool("Idle", true);
        }
    }
    else
    {
        if (Input.GetKey(KeyCode.Z))
        {
            animator.SetBool("Idle", false);

            Vector3 player = new Vector3(GameObject.Find("PlayerCollider").transform.position.x, 0, GameObject.Find("PlayerCollider").transform.position.z);
            transform.LookAt(player);
        }
    }
}
}
