using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
        public int pHealth, pArmour, pShottyAmmo, pArAmmo, maxHealth, maxArmour, maxShottyAmmo, maxArAmmo;
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = 200;
        maxArmour = 200;
        maxShottyAmmo = 40;
        maxArAmmo = 200;
        pHealth = 100;
        pArmour = 0;
        pShottyAmmo = 0;
        pArAmmo = 20;
        Debug.Log("Health: " + pHealth + " Armour: " + pArmour);
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            TakeDamage(10);
            Debug.Log("Health: " + pHealth + " Armour: " + pArmour);
        }

    }
    public void TakeDamage(int damage)
    {

        for (int i = 0; i < damage; i++)
        {
            if (pArmour > 0)
            {
                pArmour--;

            }
            else
            {
                pHealth--;
            }
        }
        

        if (pHealth <= 0)
        {
            //Main.gameOver = true;

        }

    }

    public void AddHealth(int health)
    {
        if (pHealth < maxHealth)
        {
            if (pHealth + health >= maxHealth) 
            { 
                pHealth = maxHealth;
            }
                
            else
            {
                pHealth += health;

            }
        }
    }


    public void AddArmour(int armour)
    {
        if (pArmour < maxArmour)
        {
            if (pArmour + armour >= maxArmour)
            {
                pArmour = maxArmour;

            }
            else
            {
                pArmour += armour;

            }
        }
    }

    public void AddArAmmo(int arAmmo)
    {
        if (pArAmmo < maxArAmmo)
        {
            if (pArAmmo + arAmmo >= maxArAmmo)
            {
                pArAmmo = maxArAmmo;

            }
            else { pArAmmo += arAmmo; }

        }
    }

    public void AddShottyAmmo(int shottyAmmo)
    {
        if (pShottyAmmo < maxShottyAmmo)
        {
            if (pShottyAmmo + shottyAmmo >= maxShottyAmmo)
            {
                pShottyAmmo = maxShottyAmmo;
            }
            else
            {
                pShottyAmmo += shottyAmmo;

            }

        }
    }
}
