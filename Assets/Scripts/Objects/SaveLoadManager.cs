using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveLoadManager : MonoBehaviour
{
    private static string SAVE_PATH;

    private void Awake()
    {
        SAVE_PATH = Application.persistentDataPath + "/save.json";
    }

    public static void Save(GameData data, float gameTime)
    {
        data.gameTime = gameTime;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(SAVE_PATH, json);
    }

    public static GameData Load()
    {
        GameData data = null;

        if (File.Exists(SAVE_PATH))
        {
            string json = File.ReadAllText(SAVE_PATH);
            data = JsonUtility.FromJson<GameData>(json);
        }

        return data;
    }

    public static void DeleteSave()
    {
        if (File.Exists(SAVE_PATH))
        {
            File.Delete(SAVE_PATH);
        }
    }
}
