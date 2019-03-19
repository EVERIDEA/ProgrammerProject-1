using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageManager {

    public void CalculateDamage(Player player, float damage)
    {
        player.TakeDamage(damage);
    }
}
