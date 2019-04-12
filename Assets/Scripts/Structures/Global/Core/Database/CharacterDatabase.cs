using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Everidea.CoreData
{
    [System.Serializable]
    public class CharacterData
    {
        public string Id = "";
        public string Name = "";
        public AttributeData[] Attributes;
    }
    public class CharacterDatabase : ScriptableObject
    {
    }
}
