using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character, IHavePlayerStats
{
    public InitialSword SwordStats { get; set; }

    public int Health { get; set; }
    public int Damage { get; set; }
    public int CriticalDamage { get; set; }
    public int Armour { get; set; }
    public int AttackSpeed { get; set; }
    public int UltimateMeter { get; set; }
    public int LifeSteal { get; set; }
    public int BlockChance { get; set; }
    public int CriticalChance { get; set; }

    public void InitiatePlayerStats(InitialPlayer _playerStats)
    {
        Damage = _playerStats.Damage;
        CriticalDamage = _playerStats.CriticalDamage;
        Armour = _playerStats.Armour;
        AttackSpeed = _playerStats.AttackSpeed;
        UltimateMeter = _playerStats.UltimateMeter;
        LifeSteal = _playerStats.LifeSteal;
        BlockChance = _playerStats.BlockChance;
        CriticalChance = _playerStats.CriticalChance;
    }

    public void EquipWeapon(InitialSword _playerSword)
    {
        SwordStats = _playerSword;
    }

    public override void LaunchAttack(IHavePlayerStats _player, IHaveEnemyStats _enemy,string _attackAnimationName)
    {
        if(_player != null && _enemy != null)
        {
            DamageCalculation dc = new DamageCalculation();
            int damageLaunched = dc.PlayerDamageAfterCalculation(_player, _enemy);
            Debug.Log("Attack Launched : " + damageLaunched);
            _enemy.ReduceHealth(damageLaunched);
        }
    }

    public override void Dead(string _deadAnimationName)
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
    }
}
