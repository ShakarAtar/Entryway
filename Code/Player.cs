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

		if (pHealth = 0)
		{
			Main.gameOver = true;

		}
		
	}

	public static void AddArmour (int armour)
	{
		if (pArmour < maxArmour)
		{
			pArmour =+ armour;
		}
	}

	public static void AddArAmmo (int arAmmo)
	{
		if (pArAmmo < maxArAmmo)
		{
		pArAmmo =+ arAmmo;

		}
	}

    public static void AddShottyAmmo(int shottyAmmo)
    {
        if (pShottyAmmo < maxShottyAmmo)
        {
            pShottyAmmo = +shottyAmmo;

        }
    }



}
