using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerClassicUpgradeButton1 : MonoBehaviour
{
    private void OnMouseDown()
    {
        LeveManager levelManager = FindObjectOfType<LeveManager>();

        if (levelManager.GetGolds() >= ElfeDonjon.GetUpgradePrice())
        {
            //TowerClassic parent = GetComponentInParent<TowerClassic>();

            //Transform transform = Instantiate<Transform>(GameAssets.i.ClassicTowerUpgrade1, parent.transform.position, Quaternion.identity);
            //TowerClassic towerClassic = transform.GetComponent<TowerClassic>(); // completly broken, have to change to a new class => TowerClassicUpgrade1
            //towerClassic.transform.position = parent.gameObject.transform.position;

            //levelManager.RemoveGolds(TowerClassic.GetUpgradePrice());
            //parent.Destroy();

            Debug.Log("Upgrade ClassicTower");
        }
    }
}
