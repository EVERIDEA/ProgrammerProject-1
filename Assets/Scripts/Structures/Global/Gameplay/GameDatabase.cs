using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Everidea.CoreData;

public class GameDatabase : MonoBehaviour
{
    [SerializeField]
    PlayerDatabase playerDB;
    [SerializeField]
    EnemyDatabase enemyDB;

    public CharacterData GetDatabase(Character p_target)
    {
        CharacterData data = new CharacterData();
        if (p_target is Player)
        {
            for (int i = 0; i < playerDB.Database.Length; i++)
            {
                if (playerDB.Database[i].Id == p_target.Id)
                    data = playerDB.Database[i];
            }
        }
        else
        {
            for (int i = 0; i < enemyDB.Database.Length; i++)
            {
                if (enemyDB.Database[i].Id == p_target.Id)
                    data = enemyDB.Database[i];
            }
        }

        if (data == null)
            Debug.Log("Data dengan id " + p_target.Id + " tidak ada");

        return data;
    }


}
