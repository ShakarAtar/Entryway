using System;

public class Player
	int pHealth, pArmour, pShottyAmmo, pArAmmo;
{
	public Player()	{



	}

	public static AddHealth (int health)
	{
		pHealth =+ health;
	}

	public static TakeDamage (int damage)
	{
		if (pArmour = 0)
		{
		pHealth -= damage;

		} else
		{
			pArmour -= damage;
		}
		
	}




}
