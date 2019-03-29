using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class PlayerControll : MonoBehaviour {


    public int playerDirection = 1;

    [SerializeField]
    [Range(1,5)]
    private float trackEnemyLenght = 1;

    [SerializeField]
    private Animator playerAnimator;
    [SerializeField]
    private int Movement = 5;
    [SerializeField]
    private int JumpPower = 15;
    [SerializeField]
    private int AttackSpeed = 1;
    [SerializeField]
    private float MaxLeftMap;
    [SerializeField]
    private float MaxRightMap;

    private float autoAttackCounter = 0;
    [SerializeField]
    private bool isAutoAttack = true;

    #region private parameter
    //private PlayerAttackTrigger attackTrigger;
    //private Vector2 startPos;
    //private Vector2 direction;
    private bool isGrounded = true;
    //private bool isTouchMove = false;
    //private float countToJump = 0;
    //[SerializeField]
    //private float timeToAttack = 0;
    private PlayerCurrency playerCurrency;
    private Rigidbody2D Rigid2d;
    private PlayerAnimation playerAnim;
    private bool isOnFlashForward = false;
    float attackStackCounter = 0;
    float attackCounter = 0;
    int attackIndex = 0;
    bool isStackAttack = false;
    bool isAttack = false;
    bool isBussy = false;
    float bussyCounter = 0;
    float bussyTime = 1f;
    #endregion

    private void Awake()
    {
        SavePoints sp = new SavePoints();

        playerCurrency = sp.LoadPlayerCurrency();
        while (playerCurrency == null)
        {
            playerCurrency = sp.LoadPlayerCurrency();
            if (playerCurrency != null) break;
        }
        Debug.Log("PlayerCurrency => " + "Exp : " + playerCurrency.Exp + ", Gold : " + playerCurrency.Gold);

        AttackSpeed = GetComponent<Player>().AttackSpeed;
        Rigid2d = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<PlayerAnimation>();
    }
    
    void Update()
    {
        //AutoAttack();
        // for android only
        if (Input.touchCount >= 1)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                Vector3 touchPos = Camera.main.ScreenToWorldPoint(Input.touches[i].position);
                if (touchPos.x > 0)
                {
                    Touch touch = Input.GetTouch(i);
                    //RightController(touch);
                }
                else
                {
                    if (touchPos.x < -7f)
                    {
                        Move();
                    }
                    else
                    {
                        Move();
                    }
                }
            }
        } 
        else
        {
            if (!isBussy)
            {
                if (Input.GetKey(KeyCode.A))
                {
                    playerDirection = -1;
                    Move();
                }
                else if (Input.GetKey(KeyCode.D))
                {
                    playerDirection = 1;
                    Move();
                }
                else if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A))
                {
                    playerAnim.PlayRun(false);
                }

                if (Input.GetKey(KeyCode.Space))
                {
                    if (isGrounded) Jump(JumpPower);
                }
                if (Input.GetKey(KeyCode.Q))
                {
                    if (!isGrounded)
                    {
                        Stomp();
                    }
                }
                if (Input.GetKeyDown(KeyCode.F))
                {
                    FlashMove(playerDirection);
                    
                }
                if (Input.GetMouseButtonDown(0))
                {
                    isStackAttack = true;
                    attackStackCounter = 0;
                    if (attackIndex < 3)
                    {
                        attackIndex += 1;
                    }
                    else if (attackIndex == 3)
                    {
                        attackIndex = 1;
                    }
                    Attack(attackIndex);
                }
                if (Input.GetKeyDown(KeyCode.E))
                {
                    TripleCombo();
                }
                if (isStackAttack)
                {
                    attackStackCounter += Time.deltaTime;
                    attackCounter += Time.deltaTime;
                    if (attackStackCounter >= 1.5f)
                    {
                        isStackAttack = false;
                        attackIndex = 0;
                    }
                }
            }
            else
            {
                bussyCounter += Time.deltaTime;
                if (bussyCounter >= bussyTime)
                {
                    isBussy = false;
                    bussyCounter = 0;
                }
            }
        }
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

    Vector3 SetMinMaxPlayerPosition(Vector3 mousePos)
    {
        Vector3 playerPosition = mousePos;
        if (playerPosition.x >= MaxRightMap)
            playerPosition = new Vector3(MaxRightMap, playerPosition.y, playerPosition.z);
        if (playerPosition.x <= MaxLeftMap)
            playerPosition = new Vector3(MaxLeftMap, playerPosition.y, playerPosition.z);

        return playerPosition;
    }

    public void Move()
    {
        playerAnim.PlayRun(true);
        this.transform.position = SetMinMaxPlayerPosition(new Vector3(this.transform.position.x + (playerDirection * Movement * Time.deltaTime), this.transform.position.y,-1.7f));
        this.transform.localScale = new Vector2(playerDirection, this.transform.localScale.y);
    }

    public void Attack(int index)
    {
        playerAnim.PlayAttack(index);
    }

    public void TripleCombo()
    {
        isBussy = true;
        bussyTime = 2.2f;
        playerAnim.PlayTripleCombo();
    }

    public void Jump(float _jumpPower)
    {
        playerAnim.PlayRun(false);
        playerAnim.PlayJump(true);
        Rigid2d.velocity = Vector2.up * _jumpPower;
    }
    
    public void FlashMove(int direction)
    {
        isBussy = true;
        bussyTime = 0.5f;
        playerAnim.PlayFlashForward();
        if (direction == 1) Rigid2d.velocity = Vector2.right * 15;
        else if (direction == -1) Rigid2d.velocity = Vector2.left * 15;
    }

    public void Stomp()
    {
        isBussy = true;
        bussyTime = 0.4f;
        playerAnim.PlayStomp();
        Rigid2d.velocity = Vector2.down * 30;
    }

    //void RightController(Touch touch)
    //{
    //    switch (touch.phase)
    //    {
    //        case TouchPhase.Stationary:
    //            countToJump += Time.deltaTime;
    //            if (countToJump > .08f && countToJump < 1)
    //            {
    //                if (!isTouchMove) if (isGrounded) Jump(JumpPower);
    //            }
    //            break;
    //        case TouchPhase.Began:
    //            startPos = touch.position;
    //            break;
    //        case TouchPhase.Moved:
    //            isTouchMove = true;
    //            direction = touch.position - startPos;
    //            if (direction.x > 0)
    //            {
    //                Debug.Log("FlashForward to Left");
    //            }
    //            else if (direction.x < 0)
    //            {
    //                Debug.Log("FlashForward to Left");
    //            }
    //            break;
    //        case TouchPhase.Ended:
    //            direction = Vector3.zero;
    //            isTouchMove = false;
    //            countToJump = 0;
    //            break;
    //    }
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isGrounded = true;
            playerAnim.PlayRun(false);
            playerAnim.PlayJump(false);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isGrounded = false;
        }
    }

}
