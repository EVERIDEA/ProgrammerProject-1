using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SavePoints {

    const string folderName = "BinaryDataSaved";
    const string fileExtension = ".eitech";
    const string fileNamePlayerStats = "player_stats"; 
    const string fileNamePlayerCurrency = "player_currency";

    private string folderPath;
    private string dataPlayerPath;
    private string dataPlayerCurrencyPath;

    public SavePoints() {
#if UNITY_EDITOR
        folderPath = Path.Combine(Application.persistentDataPath, folderName);
#elif UNITY_ANDROID
        folderPath = Path.Combine(Application.dataPath, folderName);
#endif
        if (!Directory.Exists(folderPath))
            Directory.CreateDirectory(folderPath);

        dataPlayerPath = Path.Combine(folderPath, fileNamePlayerStats + fileExtension);
        dataPlayerCurrencyPath = Path.Combine(folderPath, fileNamePlayerCurrency + fileExtension);
        //Debug.Log(dataPlayerPath);
    }

    public void SavePlayerStats(PlayerCurrentStats playerStats)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();

        using (FileStream fileStream = File.Open(dataPlayerPath, FileMode.OpenOrCreate))
        {
            binaryFormatter.Serialize(fileStream, playerStats);
        }
    }

    public void SavePlayerCurrency(PlayerCurrency playerCurrency)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();

        using (FileStream fileStream = File.Open(dataPlayerCurrencyPath, FileMode.OpenOrCreate))
        {
            binaryFormatter.Serialize(fileStream, playerCurrency);
        }
    }

    public PlayerCurrentStats LoadPlayerStats()
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();

        try
        {
            using (FileStream fileStream = File.Open(dataPlayerPath, FileMode.Open))
            {
                return (PlayerCurrentStats)binaryFormatter.Deserialize(fileStream);
            }
        }
        catch (FileNotFoundException e)
        {
            //Suppost to add some loading, when load data
            SavePlayerStats(new PlayerCurrentStats(0,0,new GemsCurrentUse(0,0,0,0)));
            return null;
        }
    }

    public PlayerCurrency LoadPlayerCurrency()
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();

        try
        {
            using (FileStream fileStream = File.Open(dataPlayerCurrencyPath, FileMode.Open))
            {
                return (PlayerCurrency) binaryFormatter.Deserialize(fileStream);
            }
        }
        catch (FileNotFoundException e)
        {
            Debug.Log("ERROR : " + e);
            SavePlayerCurrency(new PlayerCurrency(0,0));
            return null;
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
public class PlayerCurrency
{
    public int Exp;
    public float Gold;

    public PlayerCurrency(int exp, float gold)
    {
        this.Exp = exp;
        this.Gold = gold;
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
