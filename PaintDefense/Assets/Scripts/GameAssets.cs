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

    // TOWERS
    // Elfes Donjons
    public Transform ElfeDonjon;
    public Transform ElfeDonjonlvl2;
    public Transform ElfeDonjonlvl3;
    public Transform ElrauDonjon;

    // Furnaces
    public Transform Furnace;
    
    // Arbaïca
    public Transform Arbaïca;

    //tki ?
    public Transform ExplosiveTower;

    // ENEMIES
    public Transform ClassicEnemy;
    public Transform BigEnemy;
}
