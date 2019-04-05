using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Types;

namespace Everidea.CoreData
{
    [CreateAssetMenu(fileName = "WeaponDatabase", menuName = "EverideaDB/WeaponDB")]
    public class WeaponData : ScriptableObject
    {
        public string WeaponId;
        public string WeaponName;
        public AttackType Type;
        public WeaponClassType ClassType;
        public Sprite SpriteImage;
        public float Damage; //Basic damage
        public float CriticalDamage; //Adding more damage calulated by Percentage of (Damage * CriticalDamage/100)
        public float CriticalChance; //Critical damage probability

        public int UltimatePoint; //Increase the ultimate meter
        public float LifestealPercentage; //Add more health every damages are given to enemy
        public float LifestealChance; //Add more health every damages are given to enemy

    }
}