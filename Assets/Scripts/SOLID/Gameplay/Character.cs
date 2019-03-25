using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Everidea.Core
{
    public abstract class Character : MonoBehaviour
    {
        public CharacterType Type;

        [HideInInspector]
        public IHealth PHealth;

        // Use this for initialization
        void Awake()
        {
            PHealth = GetComponent<IHealth>();

            Init();
            LoadAttribute();
            LoadSecondaryAttribute();
        }

        public abstract void Init();

        public abstract void LoadAttribute();
        public abstract void LoadSecondaryAttribute();

        public abstract void TakeDamage(float damage);
    }
}
