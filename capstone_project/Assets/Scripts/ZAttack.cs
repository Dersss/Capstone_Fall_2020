using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Nothing useful is happening here yet
public class ZAttack : MonoBehaviour
{
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
        animator.SetBool("atPlayer", false);
    }

    // Update is called once per frame
    void Update()
    {
        //heads toward player
        Vector3 player = new Vector3(GameObject.Find("PlayerCollider").transform.position.x, 0, GameObject.Find("PlayerCollider").transform.position.z);
        transform.LookAt(player);





    }
    private void OnTriggerEnter(Collider other)
    {
        /*if (other.gameObject.CompareTag("Bullet"))
        {
            //fall back animation and despawn

            
        }*/

        if (other.gameObject.CompareTag("Player"))
        {
            animator.SetBool("atPlayer", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            animator.SetBool("atPlayer", false);
        }
    }
}
