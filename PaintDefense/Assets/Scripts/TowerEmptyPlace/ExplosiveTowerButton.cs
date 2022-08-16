using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveTowerButton : MonoBehaviour
{
    private void OnMouseDown()
    {
        LeveManager levelManager = FindObjectOfType<LeveManager>();

        if (levelManager.GetGolds() >= EplosiveTower.GetPrice())
        {
            EmtpyTowerSpace parent = GetComponentInParent<EmtpyTowerSpace>();

            Transform transform = Instantiate<Transform>(GameAssets.i.ExplosiveTower, parent.transform.position, Quaternion.identity);
            EplosiveTower explosiveClassic = transform.GetComponent<EplosiveTower>();
            explosiveClassic.transform.position = parent.gameObject.transform.position;

            levelManager.RemoveGolds(EplosiveTower.GetPrice());
            parent.Desactivate();
        }
    }
}
