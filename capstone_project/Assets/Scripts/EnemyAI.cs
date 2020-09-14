using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Nothing useful is happening here yet
public class EnemyAI : MonoBehaviour
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

        
     
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            //fall back animation and despawn

            
        }
    }
}
