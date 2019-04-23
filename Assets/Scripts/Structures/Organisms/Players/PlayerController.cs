using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private int moveSpeed = 5;
    [SerializeField]
    private int jumpPower = 15;

    #region private parameter
    private bool isGrounded = true;
    bool isAttack = false;
    bool isBussy = false;
    #endregion

    #region base action
    PlayerMove playerMove;
    PlayerJump playerJump;
    PlayerAnimation playerAnimation;
    PlayerStomp playerStomp;
    PlayerFlashMove playerFlash;
    PlayerAttack playerAttack;
    #endregion

    [SerializeField]
    PlayerDirection direction;
    
    private void Awake()
    {
        playerMove = new PlayerMove(transform);
        playerJump = new PlayerJump(transform);
        playerAnimation = new PlayerAnimation(transform.GetChild(0).gameObject, true);
        playerFlash = new PlayerFlashMove(gameObject);
        playerStomp = new PlayerStomp(gameObject);
        playerAttack = new PlayerAttack();

        FindObjectOfType<PlayerInput>().OnInput += OnInputController;
    }

    #region AUTO ATTACK
    //public void AutoAttack()
    //{
    //    GameObject enemyClosest = FindClosestEnemy(GameObject.FindGameObjectsWithTag("enemy"));
    //    if (enemyClosest != null)
    //    {
    //        IHavePlayerStats playerStats = GetComponent<IHavePlayerStats>();
    //        IHaveEnemyStats enemyStats = enemyClosest.GetComponent<IHaveEnemyStats>();
    //        if (playerStats != null && enemyStats != null)
    //        {
    //            if (isAutoAttack)
    //            {
    //                DamageCalculation dc = new DamageCalculation();
    //                autoAttackCounter += Time.deltaTime;
    //                if (autoAttackCounter > dc.AttackSpeedCalculation(AttackSpeed))
    //                {
    //                    GetComponent<Player>().LaunchAttack(playerStats, enemyStats, "player_attack");
    //                    autoAttackCounter = 0;
    //                }
    //            }
    //        }
    //    }
    //}

    //private GameObject FindClosestEnemy(GameObject[] _enemyObjects)
    //{
    //    if (_enemyObjects != null)
    //    {
    //        GameObject finalClosestEnemy = null;
    //        float distance = Mathf.Infinity;
    //        Vector3 position = transform.position;
    //        foreach (GameObject obj in _enemyObjects)
    //        {
    //            Vector3 diff = obj.transform.position - position;
    //            float curDistance = diff.sqrMagnitude;
    //            if (curDistance < distance)
    //            {
    //                finalClosestEnemy = obj;
    //                distance = curDistance;
    //            }
    //        }

    //        if (Vector2.Distance(transform.position, finalClosestEnemy.transform.position) < trackEnemyLenght)
    //        {
    //            return finalClosestEnemy;
    //        }
    //        else
    //        {
    //            return null;
    //        }
    //    }
    //    else
    //    {
    //        return null;
    //    }
    //}
    #endregion

    void OnInputController(EInputType type, KeyCode code) {
        Debug.Log(type + " " + code);
        switch (type) {
            case EInputType.GETKEY_DOWN:
                KeyDownAction(code);
                break;
            case EInputType.GETKEY_HOLD:
                KeyHoldAction(code);
                break;
            case EInputType.GETKEY_UP:
                KeyUpAction(code);
                break;
            case EInputType.MOUSE_DOWN:
                MouseDownAction();
                break;
        }
    }

    void KeyDownAction(KeyCode key)
    {
        switch (key) {
            case KeyCode.A: case KeyCode.D:
                playerAnimation.Play("IsRun", true);
                break;
            case KeyCode.Space:
                playerAnimation.Play("IsJump", true);
                if (isGrounded)
                    playerJump.Jump(jumpPower);
                break;
            case KeyCode.F:
                int dir = direction.Direction == EDirection.LEFT ? -1 : 1;
                playerFlash.FlashMove(dir, moveSpeed);
                break;
        }
    }
    void KeyHoldAction(KeyCode key)
    {
        switch (key)
        {
            case KeyCode.A:
                direction.Direction = EDirection.LEFT;
                playerMove.Move(-1, moveSpeed);
                break;
            case KeyCode.D:
                direction.Direction = EDirection.RIGHT;
                playerMove.Move(1, moveSpeed);
                break;
            case KeyCode.Space:
                break;
        }
    }
    void KeyUpAction(KeyCode key)
    {
        switch (key)
        {
            case KeyCode.A: case KeyCode.D:
                playerAnimation.Play("IsRun",false);
                break;
            case KeyCode.Space:
                break;
        }
    }

    void MouseDownAction()
    {
        playerAnimation.Play("Attack1");
    }
}
