using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour {

    public Animator CharacterAnimator { get; set;}

    public abstract void LaunchAttack(IHavePlayerStats _player, IHaveEnemyStats _enemy,string _attackAnimationName);
    public abstract void Dead(string _deadAnimationName);
}
