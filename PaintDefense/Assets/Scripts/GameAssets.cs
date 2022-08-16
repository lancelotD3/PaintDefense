using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    private static GameAssets _i;

    public static GameAssets i
    {
        get
        {
            if (_i == null) _i = (Instantiate(Resources.Load("GameAssets")) as GameObject).GetComponent<GameAssets>();
            return _i;
        }
    }

    public Sprite HeadSprite;

    public Transform Projectile;
    public Transform FireBallProjectile;

    public Transform ElfeDonjon;
    public Transform Furnace;
    public Transform Arbaïca;
    public Transform ExplosiveTower;

    public Transform ClassicTowerUpgrade1;

    public Transform ClassicEnemy;
    public Transform BigEnemy;
}
