using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Types;

namespace Everidea.CoreData
{
    [System.Serializable]
    public class SwordData
    {
        public string Id;
        public string Name;
        public Sprite SpriteImage;
        public AttributeData[] data;
    } 

    [CreateAssetMenu(fileName = "SwordDatabase", menuName = "EverideaDB/SwordDB")]
    public class SwordDatabase : ScriptableObject
    {
        public SwordData[] SwordDB;
    }
}