using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Helpers.Utils;

public class TowerCollider : MonoBehaviour
{
    private TowerClassic parent;
    private bool towersHidden = true;

    [SerializeField]
    private TowerClassicUpgradeButton1 towerClassicUpgradeButton;

    private void Awake()
    {
        parent = GetComponentInParent<TowerClassic>();
    }
    private void OnMouseDown()
    {
        towerClassicUpgradeButton.gameObject.SetActive(true);

        towersHidden = false;
    }

    private void OnMouseEnter()
    {
        parent.gameObject.transform.localScale = new Vector3(1.2f, 1.2f, 1);
    }

    private void Update()
    {
        if (!towersHidden)
        {
            if (Vector3.Distance(gameObject.transform.position, MouseHelper.GetMousePos()) > 1f)
            {
                towerClassicUpgradeButton.gameObject.SetActive(false);

                towersHidden = true;
            }
        }
        else
        {
            if (Vector3.Distance(gameObject.transform.position, MouseHelper.GetMousePos()) > 1f)
            {
                parent.gameObject.transform.localScale = new Vector3(1f, 1f, 1);
            }
        }
    }

}