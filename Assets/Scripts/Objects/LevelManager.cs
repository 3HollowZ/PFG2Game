using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelManager : MonoBehaviour
{//on collision will signal the end of the current level and switch to the next.

    public static LevelManager instance;//Sets a reference to itself
                                        //Exists so you can access the class in other scripts
    public GameObject NormalEnemy; // The prefab for the enemy object

    private void Start()
    {
        LevelZero();
    }

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

    private void LevelZero()
    {
        GameObject newEnemy = Instantiate(NormalEnemy);
        
    }
}
