using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelManager
{//on collision will signal the end of the current level and switch to the next.

    public static LevelManager instance;//Sets a reference to itself
                                   //Exists so you can access the class in other scripts
    private void Awake()//Awake starts before "void Start"
    {
       

    }


    public void resetScene()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public static LevelManager getInstance()
    {
        if (instance == null)
        {
            instance = new LevelManager();
        }

        return instance;
    }
}
