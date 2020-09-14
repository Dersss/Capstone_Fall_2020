
using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoilController : MonoBehaviour
{
   public float rotationSpeed = 6;
   public float returnSpeed = 25;

   public UnityEngine.Vector3 RecoilRotation;
   public UnityEngine.Vector3 RecoilRotationAiming;

   public bool aiming;

   private UnityEngine.Vector3 currentRotation;
   private UnityEngine.Vector3 Rot;

   void FixedUpdate() {
       currentRotation = UnityEngine.Vector3.Lerp(currentRotation, UnityEngine.Vector3.zero, returnSpeed * Time.deltaTime);
       Rot = UnityEngine.Vector3.Slerp(Rot, currentRotation, rotationSpeed * Time.fixedDeltaTime);
       transform.localRotation = UnityEngine.Quaternion.Euler(Rot);
   }

   public void Fire() {
       if (aiming) {
           currentRotation += new UnityEngine.Vector3(-RecoilRotationAiming.x, UnityEngine.Random.Range(-RecoilRotationAiming.y, RecoilRotationAiming.y), UnityEngine.Random.Range(-RecoilRotationAiming.z, RecoilRotationAiming.z));
       } else {
            currentRotation += new UnityEngine.Vector3(-RecoilRotation.x, UnityEngine.Random.Range(-RecoilRotation.y, RecoilRotation.y), UnityEngine.Random.Range(-RecoilRotation.z, RecoilRotation.z));
       }
   }

   void Update() {
       if (Input.GetButtonDown("Fire1")) {
           Fire();
       }
       if (Input.GetButton("Fire2")) {
           aiming = true;
       } else {
           aiming = false;
       }
   }
}
