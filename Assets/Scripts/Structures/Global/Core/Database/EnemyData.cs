using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Types;

namespace Everidea.CoreData
{
    [CreateAssetMenu(fileName = "EnemyDatabase", menuName = "EverideaDB/EnemyDB")]
    public class EnemyData : CharacterData
    {
        public CharacterAtkType AttackType = CharacterAtkType.MELEE;
        public EnemyType EnemyType = EnemyType.NORMAL;
    }
}
