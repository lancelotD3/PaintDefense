using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static List<Enemy> enemies = new List<Enemy>();

    public static void Create(string name, Vector3 spawnPosition, Transform[] wayPoints)
    {
        switch (name)
        {
            case "ClassicEnemy":
            {
                Transform enemyTransorm = Instantiate(GameAssets.i.BigEnemy, spawnPosition, Quaternion.identity);
                BigEnemy enemy = enemyTransorm.GetComponent<BigEnemy>();
                enemy.Setup(wayPoints);

                enemies.Add(enemy);
                break;
            }
            case "BigEnemy":
            { 
                Transform enemyTransorm = Instantiate(GameAssets.i.ClassicEnemy, spawnPosition, Quaternion.identity);

                ClassicEnemy enemy = enemyTransorm.GetComponent<ClassicEnemy>();
                enemy.Setup(wayPoints);

                enemies.Add(enemy);
                break;
            }
        }
    }

    public static void Remove(Enemy enemy)
    {
        enemies.Remove(enemy);
    }

    public static Enemy GetClosestEnemy(Vector3 pos, float maxRange)
    {
        Enemy closest = null;
        foreach(Enemy enemy in enemies)
        {
            if(Vector3.Distance(pos, enemy.transform.position) <= maxRange)
            {
                if (closest == null)
                    closest = enemy;
                else
                    if (Vector3.Distance(pos, enemy.transform.position) < Vector3.Distance(pos, closest.transform.position))
                        closest = enemy;
            }
        }
        return closest;
    }

    public static bool IsEmpty()
    {
        if (enemies.Count == 0)
            return true;
        return false;
    }
}
