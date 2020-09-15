using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : Weapon
{
    public override void Shoot() {
        base.Shoot();
        RaycastHit hit = GetHitData();
        // if (hit.collider.GetComponent<Enemy>()) {
        //     hit.collider.GetComponent<Enemy>().TakeDamage(damage);
        // }
    }
}
