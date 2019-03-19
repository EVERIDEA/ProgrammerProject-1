using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerTesting : MonoBehaviour {

    Player playerA;

    private void Awake()
    {
        playerA = GetComponentInChildren<Player>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("click");
            DamageManager damage = new DamageManager();
            damage.CalculateDamage(playerA, 20);
        }
    }
}
