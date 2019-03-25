using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class PlayerControll : MonoBehaviour {

    [SerializeField]
    [Range(1,5)]
    private float trackEnemyLenght = 1;

    [SerializeField]
    private int Movement = 5;
    [SerializeField]
    private int JumpPower = 15;
    [SerializeField]
    private int AttackSpeed = 1;

    private float autoAttackCounter = 0;
    [SerializeField]
    private bool isAutoAttack = true;

    private void Start()
    {
        AttackSpeed = GetComponent<Player>().AttackSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        AutoAttack();
    }

    public void AutoAttack()
    {
        GameObject enemyClosest = FindClosestEnemy(GameObject.FindGameObjectsWithTag("enemy"));
        if (enemyClosest != null)
        {
            IHavePlayerStats playerStats = GetComponent<IHavePlayerStats>();
            IHaveEnemyStats enemyStats = enemyClosest.GetComponent<IHaveEnemyStats>();
            if (playerStats != null && enemyStats != null)
            {
                if (isAutoAttack)
                {
                    DamageCalculation dc = new DamageCalculation();
                    autoAttackCounter += Time.deltaTime;
                    if (autoAttackCounter > dc.AttackSpeedCalculation(AttackSpeed))
                    {
                        GetComponent<Player>().LaunchAttack(playerStats, enemyStats, "player_attack");
                        autoAttackCounter = 0;
                    }
                }
            }
        }
    }

    private GameObject FindClosestEnemy(GameObject[] _enemyObjects)
    {
        if (_enemyObjects != null)
        {
            GameObject finalClosestEnemy = null;
            float distance = Mathf.Infinity;
            Vector3 position = transform.position;
            foreach (GameObject obj in _enemyObjects)
            {
                Vector3 diff = obj.transform.position - position;
                float curDistance = diff.sqrMagnitude;
                if (curDistance < distance)
                {
                    finalClosestEnemy = obj;
                    distance = curDistance;
                }
            }

            if (Vector2.Distance(transform.position, finalClosestEnemy.transform.position) < trackEnemyLenght)
            {
                return finalClosestEnemy;
            }
            else
            {
                return null;
            }
        }
        else
        {
            return null;
        }
    }
}
