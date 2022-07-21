using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Helpers;
using Helpers.Utils;

public class TowerClassic : MonoBehaviour
{
    private Vector3 projectileShootFromPosition;

    private void Awake()
    {
        projectileShootFromPosition = transform.Find("ProjectileShootFromPosition").position;
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            CMDebug.TextPopupMouse("click");
            Projectile.Create(UtilsClass.GetMouseWorldPosition());
        }
    }
}
