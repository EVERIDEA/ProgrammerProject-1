using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SavePoints {

    const string folderName = "BinaryDataSaved";
    const string fileExtension = ".eitech";
    const string fileNamePlayerStats = "player01"; 

    private string dataPlayerPath;

    public SavePoints() {
        string folderPath = Path.Combine(Application.persistentDataPath, folderName);

        if (!Directory.Exists(folderPath))
            Directory.CreateDirectory(folderPath);

        dataPlayerPath = Path.Combine(folderPath, fileNamePlayerStats + fileExtension);
        Debug.Log(dataPlayerPath);
    }

    public void SavePlayerStats(PlayerCurrentStats playerStats)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();

        using (FileStream fileStream = File.Open(dataPlayerPath, FileMode.OpenOrCreate))
        {
            binaryFormatter.Serialize(fileStream, playerStats);
        }
    }

    public PlayerCurrentStats LoadPlayerStats()
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();

        using (FileStream fileStream = File.Open(dataPlayerPath, FileMode.Open))
        {
            return (PlayerCurrentStats) binaryFormatter.Deserialize(fileStream);
        }
    }
}

[System.Serializable]
public class PlayerCurrentStats
{
    public int PlayerStatsIndex;
    public int PlayerSwordIndex;
    public GemsCurrentUse GemsUsed;

    public PlayerCurrentStats(int playerStatsIndexa, int playerSwordIndex, GemsCurrentUse gemsUsed)
    {
        this.PlayerStatsIndex = playerStatsIndexa;
        this.PlayerSwordIndex = playerSwordIndex;
        this.GemsUsed = gemsUsed;
    }
}

[System.Serializable]
public class GemsCurrentUse
{
    public int RedGemUsedIndex;
    public int BlueGemUsedIndex;
    public int YellowGemUsedIndex;
    public int PurpleGemUsedIndex;

    public GemsCurrentUse(int redGemUsedIndex, int blueGemUsedIndex, int yellowGemUsedIndex, int purpleGemUsedIndex)
    {
        this.RedGemUsedIndex = redGemUsedIndex;
        this.BlueGemUsedIndex = blueGemUsedIndex;
        this.YellowGemUsedIndex = yellowGemUsedIndex;
        this.PurpleGemUsedIndex = purpleGemUsedIndex;
    }
}
