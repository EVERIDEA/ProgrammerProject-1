using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Everidea.Core
{
    public class Enemy : Character
    {
        public override void Init()
        {
            Type = CharacterType.ENEMY;
        }
        public override void LoadAttribute()
        {

        }

        public override void LoadSecondaryAttribute()
        {

        }

        public override void TakeDamage(float damage)
        {

        }
    }
}
