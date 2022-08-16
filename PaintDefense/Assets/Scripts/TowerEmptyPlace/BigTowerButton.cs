using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigTowerButton : MonoBehaviour
{
    private void OnMouseDown()
    {
        LeveManager levelManager = FindObjectOfType<LeveManager>();

        if (levelManager.GetGolds() >= Furnace.GetPrice())
        {
            EmtpyTowerSpace parent = GetComponentInParent<EmtpyTowerSpace>();

            Transform transform = Instantiate<Transform>(GameAssets.i.Furnace, parent.transform.position, Quaternion.identity);
            Furnace fournaise = transform.GetComponent<Furnace>();
            fournaise.transform.position = parent.gameObject.transform.position;

            levelManager.RemoveGolds(Furnace.GetPrice());
            parent.Desactivate();
        }
    }
}
