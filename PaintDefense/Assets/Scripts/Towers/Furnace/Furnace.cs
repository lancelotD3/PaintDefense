using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Helpers;
using Helpers.Utils;

public class Furnace : MonoBehaviour
{
    private Vector3 projectileShootFromPosition;

    //Cooldown Shoot
    private bool canShoot = false;
    [SerializeField]
    private float cooldownShoot = 1.0f;
    private float cooldownShootTimer = .0f;

    [SerializeField]
    private int damage = 5;
    [SerializeField]
    private float range = 3;

    [SerializeField]
    private static int price = 100;

    private Vector3 aimDir;
    private float angle;

    private void Awake()
    {
        projectileShootFromPosition = transform.Find("ProjectileShootFromPosition").position;
    }

    private void Update()
    {
        UpdateTimers();

        Enemy enemy = GetClosestEnemy();
        if (enemy != null)
        {
            // Enemy in range
            aimDir = (enemy.transform.position - transform.position).normalized;
            angle = UtilsClass.GetAngleFromVectorFloat(aimDir);
            transform.eulerAngles = new Vector3(0, 0, angle);

            if (canShoot)
            {
                if (enemy.tag == "Enemy")
                {
                    canShoot = false;
                    Shoot(enemy.transform.position);
                    enemy.TakeDamage(damage);
                }
            }
        }
    }

    public void Shoot(Vector2 EnemyPos)
    {
        projectileShootFromPosition = transform.Find("ProjectileShootFromPosition").position;
        FireBallProjectile.Create(projectileShootFromPosition, EnemyPos);
    }

    private Enemy GetClosestEnemy()
    {
        return EnemyManager.GetClosestEnemy(transform.position, range);
    }

    private void UpdateTimers()
    {
        UpdateCooldownTimer();
    }

    private void UpdateCooldownTimer()
    {
        if (!canShoot)
        {
            cooldownShootTimer -= Time.deltaTime;
            if (cooldownShootTimer < .0f)
            {
                canShoot = true;
                cooldownShootTimer = cooldownShoot;
            }
        }
    }

    public static int GetPrice() => price;
}
