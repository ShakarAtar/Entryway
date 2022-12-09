using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Behaviour : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float rotationSpeed = 50f;
    public float pThrust = 100f;
    public GameObject projectilePrefab;
    Rigidbody pRigidbody;
    bool canJump = false;
    bool isGrounded;
    int doubleJump;

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
            if (isGrounded || doubleJump == 1)
            {
                canJump= true;

            }
        }


        if (movementVector != Vector3.zero)
        {
            
            movementVector = movementVector.normalized;
            transform.position = transform.position + movementVector * movementSpeed * Time.deltaTime;
        }

     
            transform.Rotate(new Vector3(0,rotationAngle*rotationSpeed* Time.deltaTime,0));
            
    
    }

    private void OnCollisionEnter(Collision feet)
    {
        if (feet.gameObject.tag == "Ground")
        {
            isGrounded = true; 
            doubleJump = 0;
        }
    }

    private void OnCollisionExit(Collision feet)
    {
        if (feet.gameObject.tag == "Ground")
        {
            isGrounded= false;
        }
    }

    private void FixedUpdate()
    {

        if (canJump && doubleJump < 2)
        {
            //reset the key checker and jump
            canJump = false;
            doubleJump ++;
            pRigidbody.AddForce(Vector3.up * pThrust, (ForceMode)ForceMode2D.Impulse);
            //pRigidbody.AddForce(transform.up * pThrust, ForceMode.Acceleration);
        }
    }
}
