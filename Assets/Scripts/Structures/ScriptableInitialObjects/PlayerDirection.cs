using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EDirection {
    LEFT, RIGHT
}

[CreateAssetMenu]
public class PlayerDirection : ScriptableObject
{
    public EDirection Direction;
}
