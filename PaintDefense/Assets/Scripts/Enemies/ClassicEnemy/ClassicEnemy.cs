using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Helpers.Utils;

public class ClassicEnemy : Enemy
{
    public void Setup(Transform[] wayPoints)
    {
        this.wayPoints = wayPoints;

        //Set Position of Enemy as position og the first waypoint
        transform.position = wayPoints[wayPointIndex].transform.position;
    }

    private void Update()
    {
        //Move Enemy
        Move();

        //Check life and kill the enemy if he have -0 hp
        CheckLife();
    }
}
