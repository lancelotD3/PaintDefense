using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Helpers.Utils;

public class FireBallProjectile : MonoBehaviour
{
    public static void Create(Vector3 spawnPosition, Vector3 targetPos)
    {
        Transform arrowTransorm = Instantiate(GameAssets.i.FireBallProjectile, spawnPosition, Quaternion.identity);

        FireBallProjectile projectile = arrowTransorm.GetComponent<FireBallProjectile>();
        projectile.Setup(targetPos);
    }

    private Vector3 targetPosition;
    private void Setup(Vector3 targetPos)
    {
        this.targetPosition = targetPos;
    }

    float moveSpeed = 10f;
    Vector3 moveDir;
    float angle;
    float destroySelfDistance = 0.1f;

    private void Update()
    {
        moveDir = (targetPosition - transform.position).normalized;

        transform.position += moveDir * moveSpeed * Time.deltaTime;

        angle = UtilsClass.GetAngleFromVectorFloat(moveDir);
        transform.eulerAngles = new Vector3(0, 0, angle);

        if (Vector3.Distance(transform.position, targetPosition) < destroySelfDistance)
        {
            Destroy(gameObject);
        }
    }
}
