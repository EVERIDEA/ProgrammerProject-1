using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = this.transform.GetChild(0).GetComponent<Animator>();
    }

    public void PlayIdle()
    {
        animator.Play("Idle");
    }

    public void Attack()
    {
        animator.Play("EnemyAttack");
    }

    public void TakeAttack()
    {
        animator.Play("EnemyGotAttacked");
    }

    public void PlayWalk(bool e)
    {
        animator.SetBool("IsWalking",e);
    }
}
