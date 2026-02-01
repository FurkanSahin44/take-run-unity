using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameDirector : MonoBehaviour
{
    [Header("Managers")]
    public EnemyManager EnemyManager;
    public LevelManager LevelManager;

    private void Start()
    {
        RestartLevel();
    }

    private void RestartLevel()
    {
        LevelManager.restartLevel();
        EnemyManager.restartEnemyManager();
    }

    public void LevelCompleted()
    {
        EnemyManager.stopEnemies();
    }
}
