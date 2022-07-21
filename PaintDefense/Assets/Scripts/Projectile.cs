using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public static void Create(Vector3 spawnPosition, Vector3 targetPos)
    {
        Instantiate(GameAssets.i.Projectile, spawnPosition, Quaternion.identity);
    }

    private void setup()
    {

    }
}
