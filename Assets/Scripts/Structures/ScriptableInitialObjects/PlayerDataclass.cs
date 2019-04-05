﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class PlayerDataclass
{

    #region initial player
    public int Health; //Basic Health
    public int Damage; //Basic damage
    public int CriticalDamage; //Adding more damage calulated by Percentage of (Damage * CriticalDamage/100)
    public int Armour; //DamagesTaken are increase
    [Range(1, 5)]
    public int AttackSpeed; //More attack speed, more fast attack will given to enemy
    public int UltimateMeter; //Increase the ultimate meter
    public int LifeSteal; //Add more health every damages are given to enemy
    #endregion

    #region fight probabilities
    public int BlockChance; //Block Probability from any attack from enemy 
    public int CriticalChance; //Critical Probabiliy for attack will given to enemy

    public PlayerDataclass(int health, int damage, int criticalDamage, int armour, int attackSpeed, int ultimateMeter, int lifeSteal, int blockChance, int criticalChance)
    {
        Health = health;
        Damage = damage;
        CriticalDamage = criticalDamage;
        Armour = armour;
        AttackSpeed = attackSpeed;
        UltimateMeter = ultimateMeter;
        LifeSteal = lifeSteal;
        BlockChance = blockChance;
        CriticalChance = criticalChance;
    }
    #endregion
}
