using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Nothing useful is happening here yet
public class EnemyAI : MonoBehaviour
{
    public Animator animator;
    public Animation anim;
    public ArrayList an;
    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
        anim = this.GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {

        
       //animator.GetCurrentAnimatorClipInfo(0);
        
    }
}
