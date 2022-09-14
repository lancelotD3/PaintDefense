using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElfeDonjonlvl2button : MonoBehaviour
{
    private void OnMouseDown()
    {
        LeveManager levelManager = FindObjectOfType<LeveManager>();

        if (levelManager.GetGolds() >= ElfeDonjon.GetUpgradePrice())
        {
            ElfeDonjon parent = GetComponentInParent<ElfeDonjon>();

            Transform transform = Instantiate<Transform>(GameAssets.i.ElfeDonjonlvl2, parent.transform.position, Quaternion.identity);

            levelManager.RemoveGolds(ElfeDonjon.GetUpgradePrice());
            parent.isAlive = false;
        }
    }
}
