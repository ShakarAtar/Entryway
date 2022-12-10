using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmourPickup : MonoBehaviour
{
    
    int armourValue = 15;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Shakar") {
           Player shakar = collision.gameObject.GetComponent<Player>();
            shakar.AddArmour(armourValue);
            Destroy(this.gameObject);
        }
    } 

   
}
