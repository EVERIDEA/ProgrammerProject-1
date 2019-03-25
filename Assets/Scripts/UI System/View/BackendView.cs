using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class BackendView : MonoBehaviour, IInitGame
{

    string defaultPath = "_Data/";

    public FD[] a;

    [System.Serializable]
    public class FD
    {
        public string a;
        public int b;
    }

    public void InitGame()
    {
        if (!Directory.Exists(defaultPath))
        {
            Directory.CreateDirectory(defaultPath);
        }

        SaveData(a, false);
        LoadAllData();
    }

    #region Save
    public void SaveData (object [] e, bool isPlayerprefs = false)
    {
        string fileName = "";
        string filePath = defaultPath;
        string json = "";

        fileName = "DBLocalLevel.ei";

        if (e == null)
            return;

        //json = JsonHelper.ToJson(e, true);//        
        //json = JsonUtility.ToJson(e);
        json = JsonHelper.ToJson<FD>(a);

        if (isPlayerprefs)
            PlayerPrefs.SetString(fileName, json);
        else
        {
            File.WriteAllText(filePath+fileName, json);
        }
    }

    #endregion

    #region LOAD
    public void LoadAllData(bool isPlayerprefs = false)
    {
        string filePath = "";
        string fileName = "";
        string json = "";

        fileName = "DBLocalLevel.ei";

        if (isPlayerprefs)
            json = PlayerPrefs.GetString(fileName);
        else
        {
            if (!File.Exists(defaultPath + fileName))
                return;

            json = File.ReadAllText(defaultPath + fileName);
            FD[] dataLevel = JsonHelper.FromJson<FD>(json);

            Debug.Log(dataLevel);
        }
        
    }

    #endregion

    #region ARRAY_JSON
    public static class JsonHelper
    {
        public static T[] FromJson<T>(string json)
        {
            Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
            return wrapper.Items;
        }

        public static string ToJson<T>(T[] array)
        {
            Wrapper<T> wrapper = new Wrapper<T>();
            wrapper.Items = array;
            return JsonUtility.ToJson(wrapper);
        }

        public static string ToJson<T>(T[] array, bool prettyPrint)
        {
            Wrapper<T> wrapper = new Wrapper<T>();
            wrapper.Items = array;
            return JsonUtility.ToJson(wrapper, prettyPrint);
        }

        [Serializable]
        private class Wrapper<T>
        {
            public T[] Items;
        }
    }
    #endregion
}
