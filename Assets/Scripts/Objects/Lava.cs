using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Lava : Obstacles
{
    public override void Activate(GameObject player)
    {
        LevelManager.getInstance().resetScene();//referencing back to the level manager
    }
}
