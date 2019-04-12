using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttribute
{
    Dictionary<AttributeType, float> Attribute { get; }

    AttributeData GetAttribute(AttributeType type);
}
