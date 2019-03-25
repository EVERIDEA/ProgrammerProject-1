using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Everidea.Core
{
    public class CharacterHealth : MonoBehaviour, IHealth
    {
        public Health Health;
        
        //Adding calculation health from status etc from core database
        public void InitHealth()
        {
            Health.AdditionalHealth = Health.NormalHealth + 50;
            Health.CurrentHealth = Health.AdditionalHealth;
        }

        //get all data health from object
        public Health GetHealth()
        {
            return Health;
        }

        //Set health affected by damage opponent
        public void SetHealth(float damage)
        {
            Health.CurrentHealth -= damage;
            Debug.Log(Health.CurrentHealth);
            if (Health.CurrentHealth <= 0)
            {
                Health.CurrentHealth = 0;
                Debug.Log("Player Dead");
            }
        }
    }
}
