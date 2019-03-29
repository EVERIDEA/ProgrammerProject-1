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
        playerAnimator.SetBool("IsJump", e);
    }

    public void PlayFlashForward()
    {
        playerAnimator.Play("FlashForward");
    }

    public void PlayStomp()
    {
        playerAnimator.Play("Stomp");
    }

    public void PlayAttack(int attackIndexSession)
    {
        if(attackIndexSession == 1) playerAnimator.Play("Attack1");
        else if(attackIndexSession == 2) playerAnimator.Play("Attack2");
        else if(attackIndexSession == 3) playerAnimator.Play("Attack3");
    }

    public void PlayTripleCombo()
    {
        playerAnimator.Play("Triplecombo");
    }
}
