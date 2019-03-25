using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coba : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SavePoints sp = new SavePoints();
            sp.SavePlayerStats(new PlayerCurrentStats(0,1,new GemsCurrentUse(1,1,1,1)));
        }

        if (Input.GetMouseButtonDown(1))
        {
            SavePoints sp = new SavePoints();
            Debug.Log(sp.LoadPlayerStats().PlayerStatsIndex);
            Debug.Log(sp.LoadPlayerStats().PlayerSwordIndex);
            Debug.Log(sp.LoadPlayerStats().GemsUsed.BlueGemUsedIndex);
            Debug.Log(sp.LoadPlayerStats().GemsUsed.RedGemUsedIndex);
            Debug.Log(sp.LoadPlayerStats().GemsUsed.YellowGemUsedIndex);
            Debug.Log(sp.LoadPlayerStats().GemsUsed.PurpleGemUsedIndex);
        }
    }
}
