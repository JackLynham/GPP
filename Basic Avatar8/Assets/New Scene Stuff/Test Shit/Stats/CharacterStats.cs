using UnityEngine;

/* Base class that player and enemies can derive from to include stats. */

public class CharacterStats : MonoBehaviour {

	// Health
	public int maxHealth = 100;
	public int currentHealth { get; set; }

	public Stat damage;
	public Stat armor;
    public int Dmg; 
	// Set current health to max health
	// when starting the game.
	void Awake ()
	{
		currentHealth = maxHealth;
	}
    private void Update()
    {
    }
    // Damage the character
    public void TakeDamage(int damage)
	{
		// Damage the character
		currentHealth -= damage;
        // Debug.Log(damage);
     
		Debug.Log(transform.name + " takes " + damage + " damage.");

		// If health reaches zero
		if (currentHealth <= 0)
		{
			Die();
		}
        damage = Dmg;
	}

	public virtual void Die ()
	{
		// Die in some way
		// This method is meant to be overwritten
		Debug.Log(transform.name + " died.");
        Destroy(gameObject);
	}

}
