using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMalee : Character,IHaveEnemyStats
{
    public int Health { get; set; }
    public int Damage { get; set; }
    public int Armour { get; set; }
    public int AttackSpeed { get; set; }
    
    public void InitiateEnemy(InitialEnemy _enemyStats)
    {
        Health = _enemyStats.Health;
        Damage = _enemyStats.Damage;
        Armour = _enemyStats.Armour;
        AttackSpeed = _enemyStats.AttackSpeed;
    }

    public override void Dead(string _deadAnimationName)
    {
        if (Health <= 0)
        {
            Debug.Log("Dead");
            Destroy(gameObject);
        }
    }

    public override void LaunchAttack(IHavePlayerStats _player, IHaveEnemyStats _enemy,string _attackAnimationName)
    {
        throw new System.NotImplementedException();
    }

    public void RecoveryHealth(int _amount)
    {
        throw new System.NotImplementedException();
    }

    public void ReduceHealth(int _amount)
    {
        Health -= _amount;
        Dead("enemy_malee_dead");
    }
}
