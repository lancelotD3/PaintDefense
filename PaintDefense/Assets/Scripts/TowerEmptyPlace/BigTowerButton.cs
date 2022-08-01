using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigTowerButton : MonoBehaviour
{
    private void OnMouseDown()
    {
        LeveManager levelManager = FindObjectOfType<LeveManager>();

        if (levelManager.GetGolds() >= BigTower.GetPrice())
        {
            EmtpyTowerSpace parent = GetComponentInParent<EmtpyTowerSpace>();

            Transform transform = Instantiate<Transform>(GameAssets.i.BigTower, parent.transform.position, Quaternion.identity);
            BigTower bigClassic = transform.GetComponent<BigTower>();
            bigClassic.transform.position = parent.gameObject.transform.position;

            levelManager.RemoveGolds(BigTower.GetPrice());
            parent.Desactivate();
        }
    }
}
