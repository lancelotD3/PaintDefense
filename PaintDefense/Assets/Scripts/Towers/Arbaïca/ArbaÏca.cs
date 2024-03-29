using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Helpers;
using Helpers.Utils;

public class Arba�ca : MonoBehaviour
{
    private Vector3 projectileShootFromPosition;

    [SerializeField]
    private Transform projectileParent;

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
    private float enemySpeedWithSlow = 3;
    [SerializeField]
    private float slowTime = 3;

    [SerializeField]
    private static int price = 100;

    private Vector3 aimDir;
    private float angle;

    private void Awake()
    {
        projectileShootFromPosition = GetComponentInChildren<ProjectileShootFromPosition>().transform.position;
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
            projectileParent.eulerAngles = new Vector3(0, 0, angle);

            if (canShoot)
            {
                if (enemy.tag == "Enemy")
                {
                    canShoot = false;
                    Shoot(enemy.transform.position);
                    enemy.TakeDamage(damage);
                    enemy.NewSpeedWithDuration(enemySpeedWithSlow, slowTime);
                }
            }
        }
    }

    public void Shoot(Vector2 EnemyPos)
    {
        projectileShootFromPosition = GetComponentInChildren<ProjectileShootFromPosition>().transform.position;
        //projectileShootFromPosition = transform.Find("ProjectileShootFromPosition").position;
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

    public static int GetPrice() => price;

    public float GetAngle() => angle;
}
