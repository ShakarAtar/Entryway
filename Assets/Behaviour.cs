using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Behaviour : MonoBehaviour
{
    public float movementSpeed = 5f;
    // Update is called once per frame
    void Update()
    {
        Vector3 movementVector = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            movementVector += new Vector3(1, 0, 0);     
  
        }

        if (Input.GetKey(KeyCode.S))
        {
            movementVector += new Vector3(-1, 0, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            movementVector += new Vector3(0, 0, -1);
        }

        if (Input.GetKey(KeyCode.A))
        {
            movementVector += new Vector3(0, 0, 1);
        }

        if (movementVector != Vector3.zero)
        {
            movementVector = movementVector.normalized;
            transform.position = transform.position + movementVector * movementSpeed * Time.deltaTime;

        }

    
    }
}
