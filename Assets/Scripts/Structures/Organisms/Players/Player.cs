﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Everidea.CoreData;

public class Player : Character
{
    private void Start()
    {
        base.Initialization <PlayerData>(this);

        Debug.Log(attribute[AttributeType.Health]);
    }
}
