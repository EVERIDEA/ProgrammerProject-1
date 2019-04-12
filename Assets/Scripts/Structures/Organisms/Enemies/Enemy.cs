using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Everidea.CoreData;

public class Enemy : Character
{
    private void Start()
    {
        base.Initialization<EnemyData>(this);

        Debug.Log(attribute[AttributeType.Health]);
    }
}
