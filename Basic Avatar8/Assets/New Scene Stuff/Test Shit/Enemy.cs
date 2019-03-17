using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Handles interaction with the Enemy */

[RequireComponent(typeof(CharacterStats))]
public class Enemy : Interactable {

	PlayerManager playerManager;
	CharacterStats myStats;
    public EnemyStats enemy;

    void Start ()
	{
		playerManager = PlayerManager.instance;
		myStats = GetComponent<CharacterStats>();
	}

    private void Update()
    {
        if(enemy.currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public override void Interact()
	{
		base.Interact();
		CharacterCombat playerCombat = playerManager.player.GetComponent<CharacterCombat>();
		if (playerCombat != null)
		{
			playerCombat.Attack(myStats);
		}
	}

}
