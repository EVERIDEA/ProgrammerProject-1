using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Everidea.Core
{
    public class DamageManager
    {

        public void CalculateDamage(Player player, float damage)
        {
            player.TakeDamage(damage);
        }
    }
}
