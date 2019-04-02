using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    public float currentHealth;
    private const float maxHealth = 100f;
    public float healthperc;
	void Start ()
    {
        currentHealth = maxHealth;
        healthperc = currentHealth / maxHealth;
	}
	
	void Update ()
    {
        if (healthperc <= 0)
        {
            Stats.kills++;
            Stats.Tkills++;
            Destroy(gameObject);
        }

	}

    public void HealthPercentage(float damage)
    {
            currentHealth -= damage;
            healthperc = (float)currentHealth / (float)maxHealth;
    }
}
