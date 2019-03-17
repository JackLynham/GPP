using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/* This component moves our player using a NavMeshAgent. */


public class PlayerMotor : Interactable
{
    PlayerManager EneemyManager;
    public CharacterStats myStats;
    public EnemyStats enemy;
    public PlayerStats player;
    public SlimeStats slime;
    void Start()
    {
        EneemyManager = PlayerManager.instance;
        myStats = GetComponent<CharacterStats>();
    }


    private void Update()
    {

  
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

    public void TakeDamage(int damage)
    {

    }

    private void OnTriggerStay(Collider other)
    {
        
            if (other.gameObject.CompareTag("Enemy"))
            {
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    enemy.currentHealth -= player.damage;
                }

              
            }

        if (other.gameObject.CompareTag("Slime"))
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                slime.currentHealth -= 3;
            }
        }

        if (other.gameObject.CompareTag("Slime"))
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                slime.currentHealth -= 3;
            }
        }

    }
}
