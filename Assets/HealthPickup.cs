using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    int healthValue = 20;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Shakar")
        {
            Player shakar = collision.gameObject.GetComponent<Player>();
            shakar.AddHealth(healthValue);
            Destroy(this.gameObject);
        }
    }
}
