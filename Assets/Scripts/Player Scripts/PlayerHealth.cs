using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

    public float maxHealth;
    private float currentHealth;

    HealthBar h;
    private void Start()
    {
      h = GameObject.FindGameObjectWithTag("Health").GetComponent<HealthBar>();
    }
    void OnEnable ()
    {
        currentHealth = 20f;
	}
	
	
	void Update ()
    {
        if (currentHealth <= 0)
        {
            Stats.deaths++;
            Stats.Tdeaths++;
            LevelEnd.reset();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
           
	}

    public void ModifyHealth(float amount)
    {
        currentHealth += amount;

        if (currentHealth <= 100)
        {

            float Health = currentHealth / maxHealth;

            h.HandleHealthChange(Health);
        }
        else
        {
            currentHealth = maxHealth;
            float Health = currentHealth / maxHealth;

            h.HandleHealthChange(Health);
        }
        
    }
}
