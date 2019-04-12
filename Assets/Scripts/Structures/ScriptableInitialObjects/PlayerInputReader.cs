using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EInputType {
    GETKEY_DOWN,
    GETKEY_HOLD,
    GETKEY_UP,
    MOUSE_DOWN,
    MOUSE_UP,
    MOUSE_HOLD
}

[CreateAssetMenu]
public class PlayerInputReader : ScriptableObject
{
    public bool IsDisable;
    public EInputType InputType;
    public KeyCode Code;
}
