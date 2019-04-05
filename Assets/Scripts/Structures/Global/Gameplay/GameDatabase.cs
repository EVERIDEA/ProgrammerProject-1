using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDatabase : MonoBehaviour {
    
    public InitialPlayer PlayerStats;
    public InitialEnemy EnemyStats;
    public InitialSword[] SwordStats;
    public InitialGem[] GemStats;
    
    public PlayerDataclass GetInitialPlayer()
    {
        return PlayerStats.PlayerDB;
    }

    public InitialEnemy GetInitialEnemy(int _index)
    {
        return EnemyStats;
    }

    public InitialSword GetInitialSword(int _index)
    {
        return SwordStats[_index];
    }

    public InitialGem GetInitialGem(int _index)
    {
        return GemStats[_index];
    }
}
