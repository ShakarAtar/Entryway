using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaPickup : MonoBehaviour
{
    int manaValue = 5;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Shakar")
        {
            Player shakar = collision.gameObject.GetComponent<Player>();
            shakar.AddMana(manaValue);
            Destroy(this.gameObject);
        }
    }
}
