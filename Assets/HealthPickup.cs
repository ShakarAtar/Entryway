using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    int healthVial = 20;
    public Player shakar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Shakar")
        {
            shakar = collision.gameObject.GetComponent<Player>();
            shakar.AddHealth(healthVial);
            Debug.Log(this.name + " Health: " + shakar.pHealth + " Armour: " + shakar.pArmour);
            Destroy(this.gameObject);
        }
    }
}
