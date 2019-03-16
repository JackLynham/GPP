using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth { get; private set; }
    public Stat Damage;
    //  public Stat Hp;


     void Awake()
    {
        currentHealth = maxHealth;
    }

     void Update()
    {
       if(Input.GetKeyDown(KeyCode.T))
      {
           TakeDamage(10);
      }
    }
    public void TakeDamage(int damage)
    {
        damage = Mathf.Clamp(damage, 0, int.MaxValue);
        currentHealth -= damage;

        Debug.Log(transform.name + " takes" + Damage + " Damage");

        if(currentHealth <=0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        //Overide Method

        Debug.Log(transform.name + "Died");
    }
}
