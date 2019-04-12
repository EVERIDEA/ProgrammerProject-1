using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health
{
    float maxHealth;
    float currentHealth;

    public Health(float maxHealth)
    {
        this.maxHealth = maxHealth;
        this.currentHealth = maxHealth;
    }

    public void IncreaseHealth (float value)
    {
        currentHealth += value;

        if (currentHealth >= maxHealth) {
            currentHealth = maxHealth;
        }
    }

    public void DecreaseHealth (float value)
    {
        currentHealth -= value;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Debug.Log("Player Dead");
        }
    }
}
