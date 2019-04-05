using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Types;

namespace Everidea.CoreData
{
    [CreateAssetMenu(fileName = "PlayerDatabase", menuName = "EverideaDB/PlayerDB")]
    public class PlayerData : CharacterData
    {
        public PlayerClassType ClassType;
        public int Level = 1;
    }
}