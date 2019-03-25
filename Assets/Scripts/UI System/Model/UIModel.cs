using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIModel : Model<UIApplication>, IInitGame
{
    public DialogueModel [] DialogueData;

    public void InitGame()
    {
        app.view.Dialog.InitDialogData(DialogueData);
        app.view.Dialog.TypeDialog("S-001");
    }
    

}
