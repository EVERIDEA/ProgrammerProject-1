using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation
{
    Animator animator;

    public PlayerAnimation(GameObject obj, bool isChildren)
    {
        animator = isChildren ? obj.GetComponentInChildren<Animator>() : obj.GetComponent<Animator>();
    }

    public void Play(string name)
    {
        animator.Play(name);
    }
}