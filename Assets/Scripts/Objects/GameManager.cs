using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private bool isGameOver;
    public static float gameTime;

    public bool IsGameOver
    {
        get { return isGameOver; }
        set
        {
            isGameOver = value;
            if (isGameOver)
            {
                SaveGameData();
                StartCoroutine(LoadSceneAfterDelay(2.0f, "GameOverScene"));
            }
        }
    }

    private IEnumerator LoadSceneAfterDelay(float delay, string sceneName)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        LoadGameData();
    }

    private void Update()
    {
        if (!isGameOver)
        {
            gameTime += Time.deltaTime;
        }
    }

    private void SaveGameData()
    {
        string filePath = Application.persistentDataPath + "/gameData.json";
        GameData gameData = new GameData(gameTime);
        string jsonData = JsonUtility.ToJson(gameData);
        File.WriteAllText(filePath, jsonData);
        Debug.Log("Game data saved to: " + filePath);
    }

    private void LoadGameData()
    {
        string filePath = Application.persistentDataPath + "/gameData.json";
        if (File.Exists(filePath))
        {
            string jsonData = File.ReadAllText(filePath);
            GameData gameData = JsonUtility.FromJson<GameData>(jsonData);
            gameTime = gameData.gameTime;
            Debug.Log("Game data loaded from: " + filePath);
        }
        else
        {
            gameTime = 0.0f;
            Debug.Log("No game data found at: " + filePath);
        }
    }
}

public class GameData
{
    public float gameTime;

    public GameData(float gameTime)
    {
        this.gameTime = gameTime;
    }
}