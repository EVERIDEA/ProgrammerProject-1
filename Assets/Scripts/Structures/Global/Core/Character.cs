using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Everidea.CoreData;

public abstract class Character : MonoBehaviour, IAttribute
{
    GameDatabase gameDatabase;

    public string Id = "";
    public string Name = "";
    protected Health health;
    
    protected Dictionary<AttributeType, float> attribute = new Dictionary<AttributeType, float>();
    public Dictionary<AttributeType, float> Attribute { get { return attribute; } }

    public void Initialization <T>(Character p_target) where T : CharacterData
    {
        if (Id == "")
            throw new System.Exception("Please insert ID on Object");

        gameDatabase = FindObjectOfType<GameDatabase>();
        var db = (T)gameDatabase.GetDatabase(p_target);
        
        //add all attributes
        for (int i = 0; i < db.Attributes.Length; i++)
            attribute.Add(db.Attributes[i].Type, db.Attributes[i].Value);

        Name = db.Name;
    }

    public AttributeData GetAttribute(AttributeType type)
    {
        if (!attribute.ContainsKey(type))
            return null;

        AttributeData att = new AttributeData(type, Attribute[type]);
        return att;
    }
}
