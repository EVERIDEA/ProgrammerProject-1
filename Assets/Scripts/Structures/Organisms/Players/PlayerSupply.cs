using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSupply : MonoBehaviour {

    [SerializeField]
    private int playerStatsIndex = 0;
    [SerializeField]
    private int playerSwordIndex = 0;

    private void Awake()
    {
        GetComponent<Player>().InitiatePlayerStats(GetDatabase().GetInitialPlayer(playerStatsIndex));
        GetComponent<Player>().EquipWeapon(GetDatabase().GetInitialSword(playerSwordIndex));
    }

    private GameDatabase GetDatabase()
    {
        GameDatabase[] _dataBases = FindObjectsOfType<GameDatabase>();
        if (_dataBases.Length > 0 && _dataBases.Length < 2)
        {
            return _dataBases[0];
        }
        else
        {
            Debug.LogError("Plase Check Your GameDatabase(GameObject) in Hirarcy, make sure not less and no more then 1 GameObject, ");
            Debug.LogError("or if doesn't exist, please insert GameDatabase from Assets/Prefabs/GameDatabase into active hirarcy scene !");
            return null;
        }
    }
}
