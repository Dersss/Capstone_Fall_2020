using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZCalm : MonoBehaviour
{
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
    }


    void Update()
    {


            //Vector3 player = new Vector3(GameObject.Find("PlayerCollider").transform.position.x, 0, GameObject.Find("PlayerCollider").transform.position.z);
            //transform.LookAt(player);


        

    }

}
