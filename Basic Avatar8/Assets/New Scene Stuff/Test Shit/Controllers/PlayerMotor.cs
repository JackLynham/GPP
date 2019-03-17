using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/* This component moves our player using a NavMeshAgent. */


public class PlayerMotor : Interactable
{
    PlayerManager EneemyManager;
    CharacterStats myStats;
  public EnemyStats enemy;

    void Start()
    {
        EneemyManager = PlayerManager.instance;
        myStats = GetComponent<CharacterStats>();
    }


    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            enemy.currentHealth -= 10;
        }
    }
    public override void Interact()
    {
        base.Interact();
        CharacterCombat playerCombat = EneemyManager.player.GetComponent<CharacterCombat>();
        if (playerCombat != null)
        {
            playerCombat.Attack(myStats);
        }
    }


}
