using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Everidea.CoreData
{
    public class CharacterData : ScriptableObject
    {
        public string Id = "";
        public string Name = "";

        public float Health = 100;
        public float Damage = 20;
        public int Armor = 5;
        public float AttackSpeed = 2;
    }
}
