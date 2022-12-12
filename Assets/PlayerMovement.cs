using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float rotationSpeed = 120f;
    float pThrust = 5f;
    float pDashSpeed = 5f;
    public GameObject projectilePrefab;
    Rigidbody pRigidbody;
    bool jumpInitiated = false;
    bool dashInitiated = false;
    bool isGrounded;
    int jumpSequence;
    Vector3 dashVector;

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

        if (Input.GetKeyDown(KeyCode.Mouse0) && GetComponent<Player>().CanCastSpell())
        {
            GameObject projectile = Instantiate(projectilePrefab);
            projectile.GetComponent<ProjectileBehaviour>().Shoot(this);
            GetComponent<Player>().OnCastSpellFireball();   


        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded || jumpSequence == 1)
            {
                jumpInitiated = true;

            }
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            dashInitiated = true;
        }


        if (movementVector != Vector3.zero)
        {
            
            movementVector = movementVector.normalized;
            transform.position = transform.position + movementVector * movementSpeed * Time.deltaTime;
            dashVector = movementVector;
        } else
        {
            dashVector = transform.forward;
        }

     
            transform.Rotate(new Vector3(0,rotationAngle*rotationSpeed* Time.deltaTime,0));
            
    
    }


    private void OnCollisionEnter(Collision feet)
    {
        if (feet.gameObject.tag == "Ground")
        {
            isGrounded = true; 
            jumpSequence = 0;
        }
    }

    private void OnCollisionExit(Collision feet)
    {
        if (feet.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }

    private void FixedUpdate()
    {

        if (jumpInitiated && jumpSequence < 2)
        {
            //jumps
            jumpInitiated = false;
            jumpSequence ++;
            pRigidbody.AddForce(Vector3.up * pThrust, (ForceMode)ForceMode2D.Impulse);
            
        }

        if (dashInitiated)
        {
            //dashes
            dashInitiated = false;
            pRigidbody.AddForce(dashVector * pDashSpeed, (ForceMode)ForceMode2D.Impulse);

        }
    }
}
