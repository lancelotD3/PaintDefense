using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Helpers.Utils;

public class ElrauDonjonCollider : MonoBehaviour
{
    private ElrauDonjon parent;
    private bool towersHidden = true;

    private void Awake()
    {
        parent = GetComponentInParent<ElrauDonjon>();
    }
    private void OnMouseDown()
    {
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
