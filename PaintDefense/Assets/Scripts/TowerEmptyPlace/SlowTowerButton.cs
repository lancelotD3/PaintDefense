using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowTowerButton : MonoBehaviour
{
    private void OnMouseDown()
    {
        LeveManager levelManager = FindObjectOfType<LeveManager>();

        if (levelManager.GetGolds() >= SlowTower.GetPrice())
        {
            EmtpyTowerSpace parent = GetComponentInParent<EmtpyTowerSpace>();

            Transform transform = Instantiate<Transform>(GameAssets.i.SlowTower, parent.transform.position, Quaternion.identity);
            SlowTower slowClassic = transform.GetComponent<SlowTower>();
            slowClassic.transform.position = parent.gameObject.transform.position;

            levelManager.RemoveGolds(SlowTower.GetPrice());
            parent.Desactivate();
        }
    }
}
