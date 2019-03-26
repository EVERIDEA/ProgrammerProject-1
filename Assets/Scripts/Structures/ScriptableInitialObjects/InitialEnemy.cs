using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="InitialEnemy", menuName = "InitialObjects/InitialEnemy")]
public class InitialEnemy : ScriptableObject {
    #region initial player
    public int Health; //Basic Health
    public int Damage; //Basic damage
    public int Armour; //DamagesTaken are increase
    [Range(1,5)]
    public int AttackSpeed; //More attack speed, more fast attack will given to enemy
    #endregion
}
