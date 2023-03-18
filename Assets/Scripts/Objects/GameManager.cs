using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; //Static instance of the GameManager so it can be accessed globally

    private bool isGameOver; //Flag for if the game is over

    public bool IsGameOver
    {
        get { return isGameOver; } //Getter method for accessing isGameOver flag
        set 
        {
            isGameOver = value;
            if (isGameOver)
            {
                StartCoroutine(LoadSceneAfterDelay(2.0f, "GameOverScene")); //Load the game over scene after a delay of 2 seconds
            }
        }
    }

    private IEnumerator LoadSceneAfterDelay(float delay, string sceneName) //Coroutine to load a scene after a specified delay
    {
        yield return new WaitForSeconds(delay); //Wait for the specified delay
        SceneManager.LoadScene(sceneName); //Load the specified scene
    }

    private void Awake()
    {
        if (instance == null) //If instance doesn't exist
        {
            instance = this; //Set instance to this
        }
        else if (instance != this) //If instance exists and it's not this
        {
            Destroy(gameObject); //Destroy this object
        }
        DontDestroyOnLoad(gameObject); //Don't destroy this object when a new scene is loaded
    }
}
