using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InitialSword", menuName = "InitialObjects/InitialSword")]
public class InitialSword : ScriptableObject
{
    #region initial sword
    public Sprite SwordArt;
    public int Damage; //Basic damage
    public int CriticalDamage; //Adding more damage calulated by Percentage of (Damage * CriticalDamage/100)
    public int Armour; //DamagesTaken are increase
    public int UltimateMeter; //Increase the ultimate meter
    public int LifeSteal; //Add more health every damages are given to enemy
    #endregion

    #region fight probabilities
    public int CriticalChance; //Critical damage probability
    #endregion

}
