using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArbaœcaCollider : MonoBehaviour
{
    private Arbaœca parent;
    private void Awake()
    {
        parent = GetComponentInParent<Arbaœca>();
    }

    private void OnMouseEnter()
    {
        parent.gameObject.transform.localScale = new Vector3(1.2f, 1.2f, 1);
    }

    private void OnMouseExit()
    {
        parent.gameObject.transform.localScale = new Vector3(1f, 1f, 1);
    }
}
