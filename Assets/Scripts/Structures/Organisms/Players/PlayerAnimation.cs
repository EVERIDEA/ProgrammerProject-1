using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator playerAnimator;
    private void Awake()
    {
        playerAnimator = transform.GetChild(0).GetComponent<Animator>();
        if (playerAnimator == null) Debug.LogError("Child in your current GameObject doesn't have Animator component");
    }

    public void PlayRun(bool e)
    {
        playerAnimator.SetBool("IsRun", e);
    }

    public void PlayJump(bool e)
    {
        PlayRun(false);
        playerAnimator.SetBool("IsJump", e);
    }

    public void PlayFlashForward()
    {
        PlayRun(false);
        playerAnimator.Play("FlashForward");
    }

    public void PlayStomp()
    {
        PlayRun(false);
        playerAnimator.Play("Stomp");
    }

    public void PlayAttack(int attackIndexSession)
    {
        PlayRun(false);
        if (attackIndexSession == 1) playerAnimator.Play("Attack1");
        else if(attackIndexSession == 2) playerAnimator.Play("Attack2");
        else if(attackIndexSession == 3) playerAnimator.Play("Attack3");
    }

    public void PlayTripleCombo()
    {
        PlayRun(false);
        playerAnimator.Play("Triplecombo");
    }
}
