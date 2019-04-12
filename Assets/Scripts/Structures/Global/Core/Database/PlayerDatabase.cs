using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Types;

namespace Everidea.CoreData
{
    [System.Serializable]
    public class PlayerData : CharacterData
    {

    }
    [CreateAssetMenu(fileName = "PlayerDatabase", menuName = "EverideaDB/PlayerDB")]
    public class PlayerDatabase : CharacterDatabase
    {
        public PlayerData[] Database;
    }
}