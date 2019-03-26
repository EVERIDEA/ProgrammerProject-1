﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Everidea.Core
{
    public class Player : Character
    {
        public override void Init()
        {
            Type = CharacterType.PLAYER;
        }

        public override void LoadAttribute()
        {
        }

        public override void LoadSecondaryAttribute()
        {
            PHealth.InitHealth();
        }

        public override void TakeDamage(float damage)
        {
            Health h = PHealth.GetHealth();
            PHealth.SetHealth(damage);
        }
    }
}