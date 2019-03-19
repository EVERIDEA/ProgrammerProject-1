using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Everidea.Core
{
    public abstract class Player : MonoBehaviour
    {

        [HideInInspector]
        public PlayerHealth PHealth;

        // Use this for initialization
        void Awake()
        {
            PHealth = GetComponent<PlayerHealth>();
            if (PHealth == null)
                gameObject.AddComponent<PlayerHealth>();

            LoadAttribute();
        }

        public abstract void LoadAttribute();
        public abstract void LoadSecondaryAttribute();

        public abstract void TakeDamage(float damage);
    }
}
