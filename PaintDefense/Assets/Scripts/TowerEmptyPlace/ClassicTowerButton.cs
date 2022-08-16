using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassicTowerButton : MonoBehaviour
{
    private void OnMouseDown()
    {
        LeveManager levelManager = FindObjectOfType<LeveManager>();

        if(levelManager.GetGolds() >= ElfeDonjon.GetPrice())
        {
            EmtpyTowerSpace parent = GetComponentInParent<EmtpyTowerSpace>();

            Transform transform = Instantiate<Transform>(GameAssets.i.ElfeDonjon, parent.transform.position, Quaternion.identity);
            ElfeDonjon elfeDonjon = transform.GetComponent<ElfeDonjon>();
            elfeDonjon.transform.position = parent.gameObject.transform.position;

            levelManager.RemoveGolds(ElfeDonjon.GetPrice());
            parent.Desactivate();
        }
    }
}