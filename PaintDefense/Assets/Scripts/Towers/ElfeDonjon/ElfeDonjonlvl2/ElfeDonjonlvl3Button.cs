using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElfeDonjonlvl3Button : MonoBehaviour
{
    private void OnMouseDown()
    {
        LeveManager levelManager = FindObjectOfType<LeveManager>();

        if (levelManager.GetGolds() >= ElfeDonjonlvl2.GetUpgradePrice())
        {
            ElfeDonjonlvl2 parent = GetComponentInParent<ElfeDonjonlvl2>();

            Transform transform = Instantiate<Transform>(GameAssets.i.ElfeDonjonlvl3, parent.transform.position, Quaternion.identity);

            levelManager.RemoveGolds(ElfeDonjonlvl2.GetUpgradePrice());
            parent.isAlive = false;
        }
    }
}
