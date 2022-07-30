using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Helpers.Utils;

public class BigEnemy : Enemy
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
    }
}
