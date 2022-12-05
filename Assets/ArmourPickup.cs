using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmourPickup : MonoBehaviour
{
    public Player shakar;
    //public GameObject pickup;
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
        Debug.Log("Collision works");
        if (collision.gameObject.tag == "Shakar") {
            Debug.Log("Collision success");
            shakar.AddArmour(15);
            Debug.Log("Armour: " + shakar.name);
            Destroy(this.gameObject);
        }
    }

    void OnCollisionExit(Collision collision)
    {
        Debug.Log("Collision exit works");
        if (collision.gameObject.tag == "Shakar")
        {
            Debug.Log("Collision exit success");
            shakar.AddArmour(15);
            Debug.Log("Armour exit: " + shakar.name);
            Destroy(this.gameObject);
        }

    }
}
