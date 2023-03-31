using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveLoadManager : MonoBehaviour
{
    private static string SAVE_PATH;

    private static readonly byte ENCRYPTION_KEY = 0xAA;

    private void Awake()
    {
        SAVE_PATH = Application.persistentDataPath + "/save.json";
    }

    public static void Save(GameData data, float gameTime)
    {
        data.gameTime = gameTime;
        string json = JsonUtility.ToJson(data);
        byte[] encryptedData = Encrypt(json);
        File.WriteAllBytes(SAVE_PATH, encryptedData);
    }

    public static GameData Load()
    {
        GameData data = null;

        if (File.Exists(SAVE_PATH))
        {
            byte[] encryptedData = File.ReadAllBytes(SAVE_PATH);
            string decryptedData = Decrypt(encryptedData);
            data = JsonUtility.FromJson<GameData>(decryptedData);
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

    private static byte[] Encrypt(string text)
    {
        byte[] data = System.Text.Encoding.UTF8.GetBytes(text);
        for (int i = 0; i < data.Length; i++)
        {
            data[i] = (byte)(data[i] ^ ENCRYPTION_KEY);
        }
        return data;
    }

    private static string Decrypt(byte[] data)
    {
        for (int i = 0; i < data.Length; i++)
        {
            data[i] = (byte)(data[i] ^ ENCRYPTION_KEY);
        }
        string text = System.Text.Encoding.UTF8.GetString(data);
        return text;
    }
}
