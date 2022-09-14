using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElrauDonjonButton : MonoBehaviour
{
    private void OnMouseDown()
    {
        LeveManager levelManager = FindObjectOfType<LeveManager>();

        if (levelManager.GetGolds() >= ElfeDonjonlvl3.GetUpgradePrice())
        {
            ElfeDonjonlvl3 parent = GetComponentInParent<ElfeDonjonlvl3>();

            Transform transform = Instantiate<Transform>(GameAssets.i.ElrauDonjon, parent.transform.position, Quaternion.identity);

            levelManager.RemoveGolds(ElfeDonjonlvl3.GetUpgradePrice());
            parent.isAlive = false;
        }
    }
}
