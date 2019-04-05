using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character, IHavePlayerStats
{
    public InitialSword SwordStats { get; set; }

    private PlayerDataclass playerStats;
    public PlayerDataclass PlayerStatus {
        get { return playerStats; }
    }

    public int Health { get; set; }
    public int Damage { get; set; }
    public int CriticalDamage { get; set; }
    public int Armour { get; set; }
    public int AttackSpeed { get; set; }
    public int UltimateMeter { get; set; }
    public int LifeSteal { get; set; }

    public int BlockChance { get; set; }
    public int CriticalChance { get; set; }

    public void InitiatePlayerStats(PlayerDataclass p_data)
    {
        Health = p_data.Health;
        Damage = p_data.Damage;
        CriticalDamage = p_data.CriticalDamage;
        Armour = p_data.Armour;
        AttackSpeed = p_data.AttackSpeed;
        UltimateMeter = p_data.UltimateMeter;
        LifeSteal = p_data.LifeSteal;
        BlockChance = p_data.BlockChance;
        CriticalChance = p_data.CriticalChance;
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
