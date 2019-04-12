using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AttributeType
{
    Health,
    Damage,
    Armor,
    AttackSpeed,
    BlockChance,
    CriticalDamage,
    CriticalChance,
    Lifesteal,
    UltimateMeter
}

[System.Serializable]
public class AttributeData
{
    public AttributeType Type;
    public float Value;

    public AttributeData(AttributeType type, float value)
    {
        Type = type;
        Value = value;
    }
}