using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Everidea.Core
{
    public class PlayerA : Player
    {

        public override void LoadAttribute()
        {
            PHealth.InitHealth();
        }

        public override void LoadSecondaryAttribute()
        {

        }

        public override void TakeDamage(float damage)
        {
            PHealth.SetHealth(damage);
        }
    }
}
