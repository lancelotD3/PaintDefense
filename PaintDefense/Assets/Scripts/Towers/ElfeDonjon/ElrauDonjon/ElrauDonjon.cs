using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Helpers;
using Helpers.Utils;

public class ElrauDonjon : MonoBehaviour
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

    [SerializeField]
    private static int upgradeDoubleBulletPricelvl1 = 100;
    [SerializeField]
    private static int upgradeDoubleBulletPricelvl2 = 100;
    [SerializeField]
    private static int upgradeDoubleBulletPricelvl3 = 100;

    private static int levelDoubleBullet = 0;

    private Vector3 aimDir;
    private float angle;

    private bool isAlive = true;


    private bool doubleArrow = true;
    private bool canShootDoubleArrow = true;
    [SerializeField]
    private float cooldwoonDoubleArrow = 3f;
    private float timerDoubleArrow = 3f;

    

    private void Awake()
    {
        projectileShootFromPosition = transform.Find("ProjectileShootFromPosition").position;
    }

    private void Start()
    {
        timerDoubleArrow = cooldwoonDoubleArrow;
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
            //transform.eulerAngles = new Vector3(0, 0, angle);

            if (canShoot)
            {
                if (enemy.tag == "Enemy")
                {
                    canShoot = false;
                    Shoot(enemy.transform.position);
                    enemy.TakeDamage(damage);
                }
            }

            if (doubleArrow && canShootDoubleArrow)
            {
                canShootDoubleArrow = false;
                StartCoroutine(DoubleArrowShoot(enemy));
            }
        }

        if (isAlive == false)
        {
            Destroy(this);
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

        if (!canShootDoubleArrow)
        {
            timerDoubleArrow -= Time.deltaTime;
            if(timerDoubleArrow < .0f)
            {
                canShootDoubleArrow = true;
                timerDoubleArrow = cooldwoonDoubleArrow;
            }
        }
    }

    IEnumerator DoubleArrowShoot(Enemy enemy)
    {
        Shoot(enemy.transform.position);
        enemy.TakeDamage(damage);
        yield return new WaitForSeconds(1f);
        Shoot(enemy.transform.position);
        enemy.TakeDamage(damage);
    }

    public void Destroy()
    {
        isAlive = false;
    }

    public static int GetPrice() => price;
    public static int GetUpgradeDoubleBulletPricelvl1() => upgradeDoubleBulletPricelvl1;
    public static int GetUpgradeDoubleBulletPricelvl2() => upgradeDoubleBulletPricelvl2;
    public static int GetUpgradeDoubleBulletPricelvl3() => upgradeDoubleBulletPricelvl3;
    public static int GetlevelDoubleBullet() => levelDoubleBullet;
}
