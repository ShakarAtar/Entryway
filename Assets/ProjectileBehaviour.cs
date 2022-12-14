using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    public float projectileDisPlayer = 1.5f;
    public float projectileSpeed = 10000f;
    public float projectileDespawn = 2f;
    private float startTime;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - startTime > projectileDespawn)
        {
            Destroy(gameObject);
        }
        
    }

    public void Shoot (PlayerMovement shooter)
    {
        transform.position = shooter.transform.position + shooter.transform.forward * projectileDisPlayer;
        GetComponent<Rigidbody>().AddForce(shooter.transform.forward*projectileSpeed);
    }

    public void ShootPlayer(EnemyBehaviour shooter)
    {
        transform.position = shooter.transform.position;
        transform.LookAt(player.transform.position);
        transform.position = shooter.transform.position + transform.forward * projectileDisPlayer;
        GetComponent<Rigidbody>().AddForce(transform.forward * projectileSpeed);
    }
}
