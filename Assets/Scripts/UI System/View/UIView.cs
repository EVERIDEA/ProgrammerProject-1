using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIView : View<UIApplication>, IInitGame
{
    public DialogComponent Dialog { get; set; }
    public PauseComponent Pause { get; set; }


    private void Awake()
    {
        Dialog = GetComponentInChildren<DialogComponent>();
        Pause = GetComponentInChildren<PauseComponent>();
    }

    public void InitGame()
    {
        Pause.InitPause();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Pause.Pause();
        }
    }
}
