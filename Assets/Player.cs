using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
      public int pHealth, pArmour, pMana, pMaxHealth, pMaxArmour, pMaxMana;
    void Start()
    {
        //resets the player
        pMaxHealth = 200;
        pMaxArmour = 200;
        pMaxMana = 40;
        pHealth = 100;
        pArmour = 0;
        pMana = 10;
        Debug.Log("Health: " + pHealth + " Armour: " + pArmour);
        

    }

    private void OnGUI()
    {
        GUILayout.FlexibleSpace();
        GUILayout.Label("HP: " + pHealth);
        GUILayout.Label("Armour: " + pArmour);
        GUILayout.Label("Mana: " + pMana);

    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "IceBolt")
        {
            TakeDamage(10);
            Debug.Log("Health: " + pHealth + " Armour: " + pArmour);
        }

    }
    public void TakeDamage(int damage)
    {
        int armourDamage, healthDamage;
        armourDamage = Math.Min(damage, pArmour);
        healthDamage = damage - armourDamage;

        pArmour -= armourDamage;
        pHealth -= healthDamage;

        if (pHealth <= 0)
        {
            PlayerDeath();

        }

    }

    public void AddHealth(int health)
    {
        pHealth = Math.Min(pHealth + health, pMaxHealth);
                
    }


    public void AddArmour(int armour)
    {
        pArmour = Math.Min(pArmour + armour, pMaxArmour);
    }


    public void AddMana(int mana)
    {

        pMana = Math.Min(pMana + mana, pMaxMana);
    }

    public void OnCastSpellFireball()
    {
        pMana--;

    }

    public bool CanCastSpell()
    {
        return pMana > 0;
    }

    public void PlayerDeath()
    {
        //not implemented yet
        Debug.Log("You died.");
    }
}
