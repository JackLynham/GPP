using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Handles the players stats and adds/removes modifiers when equipping items. */

public class PlayerStats : CharacterStats
{
    public int damage = 3;
	
	public override void Die()
	{
		base.Die();
		//PlayerManager.instance.KillPlayer();
	}
}
