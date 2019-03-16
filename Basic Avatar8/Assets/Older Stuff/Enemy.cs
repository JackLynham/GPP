using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class Enemy : Interactble
{
    PlayerManager playerManager;
    CharacterStats myStats;

    void Start()
    {
        playerManager = PlayerManager.instance;
        myStats = GetComponent<CharacterStats>();
    }
    public override void Interact()
    {
        base.Interact();
        Debug.Log("What Is Life");
        CharacterCombat playerCombat = playerManager.player.GetComponent<CharacterCombat>();

        if(playerCombat != null)
        {
            Debug.Log("What Is love");
            playerCombat.Attack(myStats);
        }
    }

}
