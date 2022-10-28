using System;

public class Player
	int pHealth, pArmour, pShottyAmmo, pArAmmo, maxHealth, maxArmour, maxShottyAmmo, maxArAmmo;
{
	public Player()	{
		maxHealth = 100;
		maxArmour = 100;
		maxShottyAmmo = 40;
		maxArAmmo = 200;


	}

	public static void AddHealth(int health)
	{
		if (health < maxHealth)
		{
			if (pHealth + health >= maxHealth)
				pHealth = maxHealth;

		} else
		{
			pHealth =+ health;

		}
	}

	public static void TakeDamage(int damage)
	{
		if (pArmour = 0)
		{
			pHealth -= damage;

		} else
		{
			pArmour -= damage;
		}

		if (pHealth <= 0)
		{
			Main.gameOver = true;

		}
		
	}

	public static void AddArmour (int armour)
	{
		if (pArmour < maxArmour)
		{
			if (pArmour + armour >= maxArmour)
			{
				pArmour = maxArmour;

			} else
			{
				pArmour =+ armour;

			}
		}
	}

	public static void AddArAmmo (int arAmmo)
	{
		if (pArAmmo < maxArAmmo)
		{
			if (pArAmmo + arAmmo >= maxArAmmo)
			{
				pArAmmo = maxArAmmo;

			} else { pArAmmo =+ arAmmo; }

		}
	}

    public static void AddShottyAmmo(int shottyAmmo)
    {
        if (pShottyAmmo < maxShottyAmmo)
        {
			if (pShottyAmmo + shottyAmmo >= maxShottyAmmo)
			{
				pShottyAmmo = maxShottyAmmo;
			}
			else 
			{
				pShottyAmmo = +shottyAmmo;

			}

        }
    }



}
