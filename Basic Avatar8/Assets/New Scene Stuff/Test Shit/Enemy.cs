using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Handles interaction with the Enemy */

[RequireComponent(typeof(CharacterStats))]
public class Enemy : Interactable {

	PlayerManager playerManager;
	CharacterStats myStats;
    public EnemyStats enemy;
    public SlimeStats slime;
    public GameObject MainSlime;
    float time = .1f;
 
    public
    void Start ()
	{
		playerManager = PlayerManager.instance;
		myStats = GetComponent<CharacterStats>();
      
    }

    private void Update()
    {
      
        if (enemy.currentHealth <= 0)
        {
            slime.Slime1.SetActive(true);
            slime.Slime2.SetActive(true);
            time -= Time.deltaTime;
            if (time <= 0)
            {
                MainSlime.SetActive(false);
            }
           
           
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
