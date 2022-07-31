using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassicTowerButton : MonoBehaviour
{
    private void OnMouseDown()
    {

        LeveManager levelManager = FindObjectOfType<LeveManager>();

        if(levelManager.GetGolds() >= TowerClassic.GetPrice())
        {
            EmtpyTowerSpace parent = GetComponentInParent<EmtpyTowerSpace>();

            Transform transform = Instantiate<Transform>(GameAssets.i.ClassicTower, parent.transform.position, Quaternion.identity);
            TowerClassic towerClassic = transform.GetComponent<TowerClassic>();
            towerClassic.transform.position = parent.gameObject.transform.position;

            levelManager.RemoveGolds(TowerClassic.GetPrice());
            parent.Desactivate();
        }

    }
}
