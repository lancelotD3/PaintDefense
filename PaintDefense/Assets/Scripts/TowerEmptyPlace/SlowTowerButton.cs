using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowTowerButton : MonoBehaviour
{
    private void OnMouseDown()
    {
        LeveManager levelManager = FindObjectOfType<LeveManager>();

        if (levelManager.GetGolds() >= Arbaœca.GetPrice())
        {
            EmtpyTowerSpace parent = GetComponentInParent<EmtpyTowerSpace>();

            Transform transform = Instantiate<Transform>(GameAssets.i.ArbaÔca, parent.transform.position, Quaternion.identity);
            Arbaœca arbaœca = transform.GetComponent<Arbaœca>();
            arbaœca.transform.position = parent.gameObject.transform.position;

            levelManager.RemoveGolds(Arbaœca.GetPrice());
            parent.Desactivate();
        }
    }
}
