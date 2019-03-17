using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SlimeStats : MonoBehaviour
{
    public float Damage;
    public float maxhealth;
    public float currentHealth;

    public PlayerStats player;

    public GameObject Slime1;
    public GameObject Slime2;
    public EnemyStats enemy;

     //NavMeshAgent agent;
    private void Start()
    {
        Slime1.SetActive(false);
        Slime2.SetActive(false);
    }

    private void Awake()
    {
         currentHealth = maxhealth;
    }
    public void Update()
    {
        if(currentHealth <= 0)
        {
            Slime1.SetActive(false);
            Slime2.SetActive(false);
        }
    }


}
