using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElrauDonjonButton : MonoBehaviour
{
    private void OnMouseDown()
    {
        LeveManager levelManager = FindObjectOfType<LeveManager>();

        if (levelManager.GetGolds() >= ElfeDonjonlvl2.GetUpgradePrice())
        {
            ElfeDonjonlvl2 parent = GetComponentInParent<ElfeDonjonlvl2>();

            Transform transform = Instantiate<Transform>(GameAssets.i.ElrauDonjon, parent.transform.position, Quaternion.identity);
            //ElrauDonjon elrauDonjon = transform.GetComponent<ElrauDonjon>();
            //elrauDonjon.transform.position = parent.gameObject.transform.position;

            levelManager.RemoveGolds(ElfeDonjonlvl2.GetUpgradePrice());
            parent.isAlive = false;
        }
    }
}
