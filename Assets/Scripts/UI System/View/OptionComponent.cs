using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unitycoding.UIWidgets;

public class OptionComponent : UIWidget
{
    public GameObject OptionUI;

    public void ShowOption()
    {
        OptionUI.SetActive(true);
        Show();
    }
    public void CloseOption()
    {
        Close();
    }
}
