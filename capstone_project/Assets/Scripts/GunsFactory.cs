using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunsFactory : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> guns = new List<GameObject>();
 
   public GameObject CreateGun(int gunIndex)
   {
       return Instantiate(guns[gunIndex]);
   }
}
