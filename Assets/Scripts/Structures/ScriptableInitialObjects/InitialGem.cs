using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InitialGem", menuName = "InitialObjects/InitialGem")]
public class InitialGem : ScriptableObject
{
    #region initial player
    public int Health; //Basic Health
    public int CriticalDamage; //Adding more damage calulated by Percentage of (Damage * CriticalDamage/100)
    public int Armour; //DamagesTaken are increase
    [Range(1, 5)]
    public int ExtraAttackSpeed; //More attack speed, more fast attack will given to enemy
    #endregion

    #region fight probabilities
    public int BlockChance; //Block Probability from any attack from enemy 
    public int CriticalChance; //Critical Probabiliy for attack will given to enemy
    #endregion
}
