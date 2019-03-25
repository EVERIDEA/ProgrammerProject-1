using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDatabase : MonoBehaviour {
    
    public InitialPlayer[] PlayerStats;
    public InitialEnemy[] EnemyStats;
    public InitialSword[] SwordStats;
    public InitialGem[] GemStats;

    public GameDatabase() { }

    public InitialPlayer GetInitialPlayer(int _index)
    {
        return PlayerStats[_index];
    }

    public InitialEnemy GetInitialEnemy(int _index)
    {
        return EnemyStats[_index];
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
