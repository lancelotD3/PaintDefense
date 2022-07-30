using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Helpers.Utils;

public class Enemy : MonoBehaviour
{
    //WayPoints Infos
    public Transform[] wayPoints;
    public int wayPointIndex = 0;

    //Transforms infos
    [SerializeField]
    private float movementSpeed = 2f;
    private Vector3 moveDir;

    //GameObject Infos
    [SerializeField]
    private int life = 20;

    [SerializeField]
    private int damageOnGeneralLife;

    private int maxLife;

    private HealthBarEnemy bar;

    private void Start()
    {
        maxLife = life;
    }

    private void Awake()
    {
        GameObject TempBar = transform.Find("HealthBar").gameObject;
        bar = TempBar.GetComponent<HealthBarEnemy>();
    }

    public int GetDamageOnGeneralLife() => damageOnGeneralLife;
    public int GetLife() => life;
    public int GetMaxLife() => maxLife;
    public float GetMoveDirectionX() => moveDir.x;
    public float GetMoveDirectionY() => moveDir.y;

    public void TakeDamage(int damage)
    {
        life -= damage;

        // Calculate the ratio of the life bar et resize the bar
        float ratio = ((float)life / (float)maxLife);
        bar.SetSize(ratio);

        if (life <= 0)
        {
            Destroy(gameObject);
            EnemyManager.Remove(this);
        }
    }

    public void Move()
    {
        //If Enemy did't reach last waypoint it can move
        //If Enemy reached last waypoint then it stops
        if (wayPointIndex <= wayPoints.Length - 1)
        {
            //Move Enemy from current waypoint to the next one
            //Using MoveToward method

            transform.position = Vector2.MoveTowards(transform.position, wayPoints[wayPointIndex].transform.position, movementSpeed * Time.deltaTime);

            //Calcul the VecDir to set the rotation
            if (wayPointIndex > 0)
            {
                moveDir = (wayPoints[wayPointIndex].position - wayPoints[wayPointIndex - 1].position).normalized;
            }

            //If Enemy reaches position of waypoint he walked towards
            //then wayPointIndex is increased by 1
            //and Enemy starts to walk to the next waypoint
            if (transform.position == wayPoints[wayPointIndex].transform.position)
                wayPointIndex += 1;
        }
    }
}
