using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class EnemyManager : MonoBehaviour
{
    public Enemy enemyPrefab;
    public List<Enemy> enemies;
    public Player player;

    public int enemyCount;

    public void restartEnemyManager()
    {
        DeleteEnemies();
        GenerateEnemies();
    }

    private void DeleteEnemies()
    {
        
    }

    private void GenerateEnemies()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            var enemyXPos = 0f;
            enemyXPos = Random.Range(-4f, 4f);
            var newEnemy = Instantiate(enemyPrefab);
            newEnemy.transform.position = new Vector3(enemyXPos,0,i*2-20);
            enemies.Add(newEnemy);
            newEnemy.StartEnemy(player);
        }

    }
    
    public void stopEnemies()
    {
        foreach (var e in enemies)
        {
            e.stop();
        }
    }
}

  