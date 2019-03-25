using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : Controller<UIApplication>
{
    private void Awake()
    {
    }

    public override void OnNotification(string p_event, Object p_target, params object[] p_data)
    {
        switch (p_event) {
            case "scene.start":
                IInitGame[] initGames = Global.GetInterfaces<IInitGame>(app.gameObject);
                foreach (var initGame in initGames)
                    initGame.InitGame();
                break;
        }
    }
}
