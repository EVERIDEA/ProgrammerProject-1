using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseComponent : MonoBehaviour
{
    [SerializeField]
    GameObject PauseUI;

    public void InitPause()
    {
        PauseUI.SetActive(false);
        Time.timeScale = 1;
    }

    public void Pause()
    {
        if (PauseUI.activeInHierarchy)
        {
            PauseUI.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            PauseUI.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
