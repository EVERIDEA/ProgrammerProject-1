using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHavePlayerStats : IHaveSword, IHaveHealth, IHaveSkill
{
    #region initial player
    int Health { get; set; } //Basic Health
    int Damage { get; set; } //Basic damage
    int CriticalDamage { get; set; } //Adding more damage calulated by Percentage of (Damage * CriticalDamage/100)
    int Armour { get; set; } //DamagesTaken are increase
    int AttackSpeed { get; set; } //More attack speed, more fast attack will given to enemy
    int LifeSteal { get; set; } //Add more health every damages are given to enemy
    #endregion

    #region fight probabilities
    int BlockChance { get; set; } //Block Probability from any attack from enemy 
    int CriticalChance { get; set; } //Critical Probabiliy for attack will given to enemy
    #endregion
}

public interface IHaveSkill
{
    int UltimateMeter { get; set; } //Increase the ultimate meter
}

public interface IHaveEnemyStats : IHaveHealth
{
    #region initial player
    int Damage { get; set; } //Basic damage
    int Armour { get; set; } //DamagesTaken are increase
    int AttackSpeed { get; set; } //More attack speed, more fast attack will given to enemy
    #endregion
}

public interface IHaveHealth
{
    int Health { get; set; } //Basic Health
    void RecoveryHealth(int _amount);
    void ReduceHealth(int _amount);
}

public interface IHaveSword
{
    InitialSword SwordStats { get; }
}
