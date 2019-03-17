using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Keeps track of enemy stats, loosing health and dying. */

public class EnemyStats : CharacterStats
{

    CharacterStats stato;


    private void Update()
    {
        //stato.currentHealth = 10;
  
    }
    public override void Die()
	{
		base.Die();

		// Add ragdoll effect / death animation

		Destroy(gameObject);
	}

}
