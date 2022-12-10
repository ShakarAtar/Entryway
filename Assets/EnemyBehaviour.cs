using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public GameObject currentWayPoint, nextWayPoint;
    float movementSpeed = 5f;

    private void Update()
    {
        float step = movementSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, currentWayPoint.transform.position, step);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Fireball")
        {
            Debug.Log("Enemy was hit.");
            Destroy(this.gameObject);  
        }

        if (collision.gameObject == currentWayPoint)
        {
            GameObject swap = currentWayPoint;
            currentWayPoint = nextWayPoint;            
            nextWayPoint = swap;
        }
    }

}
