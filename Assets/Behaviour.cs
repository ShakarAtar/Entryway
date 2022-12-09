using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Behaviour : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float rotationSpeed = 50f;
    public float pThrust = 150f;
    public GameObject projectilePrefab;
    Rigidbody pRigidbody;
    bool canJump = false;

    private void Start()
    {
        pRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movementVector = Vector3.zero;
        float rotationAngle = 0f;

        if (Input.GetKey(KeyCode.Q)) {
            rotationAngle -= 1;

        }

        if (Input.GetKey(KeyCode.E)) {
            rotationAngle += 1;

        }

        if (Input.GetKey(KeyCode.W))
        {
            movementVector += transform.forward;     
    
        }

        if (Input.GetKey(KeyCode.S))
        {
            movementVector -= transform.forward;
        }

        if (Input.GetKey(KeyCode.D))
        {
            movementVector += transform.right;
        }

        if (Input.GetKey(KeyCode.A))
        {
            movementVector -= transform.right;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log("Mouse0 is pressed");
            GameObject projectile = Instantiate(projectilePrefab);
            projectile.GetComponent<ProjectileBehaviour>().Shoot(this);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Debug.Log("Space is pressed");
            canJump= true;
        }


        if (movementVector != Vector3.zero)
        {
            
            movementVector = movementVector.normalized;
            transform.position = transform.position + movementVector * movementSpeed * Time.deltaTime;
        }

     
            transform.Rotate(new Vector3(0,rotationAngle*rotationSpeed* Time.deltaTime,0));
            
    
    }

    private void FixedUpdate()
    {

        if ( canJump)
        {
            //reset the key checker and jump
            canJump = false;
            GetComponent<Rigidbody>().velocity = Vector2.up * pThrust;
            //pRigidbody.AddForce(transform.up * pThrust, ForceMode.Acceleration);
        }
    }
}
