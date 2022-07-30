using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Helpers;
using Helpers.Utils;

public class TowerClassic : MonoBehaviour
{
    private Vector3 projectileShootFromPosition;


    //Cooldown Shoot
    private bool canShoot = false;
    private float cooldownShoot = 1.0f;
    private float cooldownShootTimer = .0f;

    private int damage = 5;
    private float range = 3;

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
        Projectile.Create(projectileShootFromPosition, EnemyPos);
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
}
