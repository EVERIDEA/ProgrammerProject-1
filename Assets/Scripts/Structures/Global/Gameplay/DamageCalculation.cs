using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCalculation {

    public DamageCalculation(){}

    public int PlayerDamageAfterCalculation(IHavePlayerStats _player, IHaveEnemyStats _enemy)
    {
        int finalDamage = 0;
        int criticalChance = FindProbability();
        Debug.Log(criticalChance);
        if (criticalChance <= (_player.CriticalChance + _player.SwordStats.CriticalChance))
        {
            finalDamage = _player.Damage * (_player.CriticalDamage/100);
            Debug.Log("CRITICAL !!");
        }
        else
        {
            finalDamage = _player.Damage;
        }
        return finalDamage + _player.SwordStats.Damage - (_enemy.Armour);
    }

    public int EnemyDamageAfterCalculation(IHavePlayerStats _player, IHaveEnemyStats _enemy)
    {
        int blockChance = FindProbability();
        if (blockChance <= _player.BlockChance)
        {
            return 0;
        }
        else
        {
            return _enemy.Damage - (_player.Armour);
        }
    }

    public int FindProbability()
    {
        return Random.Range(1, 101);
    }

    public float AttackSpeedCalculation(int _currentAttackSpeed)
    {
        float finalAttackSpeed = 1.5f;
        int i = 0;
        while (i < _currentAttackSpeed)
        {
            finalAttackSpeed -= 0.25f;
            i++;
        }
        return finalAttackSpeed;
    }
}
