using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowTowerButton : MonoBehaviour
{
    private void OnMouseDown()
    {
        LeveManager levelManager = FindObjectOfType<LeveManager>();

        if (levelManager.GetGolds() >= Arba�ca.GetPrice())
        {
            EmtpyTowerSpace parent = GetComponentInParent<EmtpyTowerSpace>();

            Transform transform = Instantiate<Transform>(GameAssets.i.Arba�ca, parent.transform.position, Quaternion.identity);
            Arba�ca arba�ca = transform.GetComponent<Arba�ca>();
            arba�ca.transform.position = parent.gameObject.transform.position;

            levelManager.RemoveGolds(Arba�ca.GetPrice());
            parent.Desactivate();
        }
    }
}
