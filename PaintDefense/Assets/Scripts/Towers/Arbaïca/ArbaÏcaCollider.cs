using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arba�caCollider : MonoBehaviour
{
    private Arba�ca parent;
    private void Awake()
    {
        parent = GetComponentInParent<Arba�ca>();
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
