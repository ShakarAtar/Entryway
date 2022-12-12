using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public GameObject currentWayPoint, nextWayPoint;
    float movementSpeed = 5f;
    public GameObject projectilePrefab;
    float nextShotTime;
    float shotWaitTime = 2;

    private void Start()
    {
        nextShotTime= Time.time + shotWaitTime;
    }

    private void Update()
    {
        float step = movementSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, currentWayPoint.transform.position, step);

        if (Time.time >= nextShotTime) 
        { 
            GameObject projectile = Instantiate(projectilePrefab);
            projectile.GetComponent<ProjectileBehaviour>().ShootPlayer(this);
            nextShotTime += shotWaitTime;
        }
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
