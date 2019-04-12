using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField]
    PlayerInputReader input;

    public delegate void OnInputController (EInputType type, KeyCode keycode);
    public event OnInputController OnInput;


    void Update()
    {
        Event e = Event.current;
        
        if (!input.IsDisable)
        {
            foreach (KeyCode kcode in System.Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(kcode))
                {
                    if (OnInput != null)
                        OnInput(EInputType.GETKEY_DOWN, kcode);
                    input.InputType = EInputType.GETKEY_DOWN;
                    input.Code = kcode;
                }
                else if (Input.GetKey(kcode))
                {
                    if (OnInput != null)
                        OnInput(EInputType.GETKEY_HOLD, kcode);
                    input.InputType = EInputType.GETKEY_HOLD;
                    input.Code = kcode;
                }
                else if (Input.GetKeyUp(kcode))
                {
                    if (OnInput != null)
                        OnInput(EInputType.GETKEY_UP, kcode);
                    input.InputType = EInputType.GETKEY_UP;
                    input.Code = kcode;
                }

            }

            if (Input.GetMouseButtonDown(0))
            {
                if (OnInput != null)
                    OnInput(EInputType.MOUSE_DOWN, KeyCode.None);
                input.InputType = EInputType.MOUSE_DOWN;
                input.Code = KeyCode.None;
            }
            else if (Input.GetMouseButton(0))
            {
                if (OnInput != null)
                    OnInput(EInputType.MOUSE_HOLD, KeyCode.None);
                input.InputType = EInputType.MOUSE_HOLD;
                input.Code = KeyCode.None;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                if (OnInput != null)
                    OnInput(EInputType.MOUSE_UP, KeyCode.None);
                input.InputType = EInputType.MOUSE_UP;
                input.Code = KeyCode.None;
            }
        }

    }
}
