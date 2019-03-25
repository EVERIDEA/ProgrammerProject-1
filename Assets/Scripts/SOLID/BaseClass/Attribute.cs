using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Everidea.Core
{
    [System.Serializable]
    public class Health
    {
        public float NormalHealth;
        public float AdditionalHealth;
        public float CurrentHealth;
    }

    [System.Serializable]
    public class Attribute
    {
        public AttributeType Type;
        public int Value;
    }


    [System.Serializable]
    public class SecondaryAttribute
    {
        public SecondaryAttributeType Type;
        public int Value;
    }
}
