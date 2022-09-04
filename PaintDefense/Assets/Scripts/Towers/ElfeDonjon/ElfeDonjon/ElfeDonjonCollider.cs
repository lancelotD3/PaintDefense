using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Helpers.Utils;

public class ElfeDonjonCollider : MonoBehaviour
{
    private ElfeDonjon parent;

    [SerializeField]
    private ElfeDonjonlvl2button elfeDonjonlvl2Button;
    private bool towersHidden = true;

    private void Awake()
    {
        parent = GetComponentInParent<ElfeDonjon>();
    }

    private void OnMouseEnter()
    {
        parent.gameObject.transform.localScale = new Vector3(1.2f, 1.2f, 1);
    }

    private void OnMouseDown()
    {
        elfeDonjonlvl2Button.gameObject.SetActive(true);
        towersHidden = false;
    }

    private void Update()
    {
        if (!towersHidden)
        {
            if (Vector3.Distance(gameObject.transform.position, MouseHelper.GetMousePos()) > 1.5f)
            {
                elfeDonjonlvl2Button.gameObject.SetActive(false);
                towersHidden = true;
            }
        }
        else
        {
            if (Vector3.Distance(gameObject.transform.position, MouseHelper.GetMousePos()) > 1.5f)
            {
                parent.gameObject.transform.localScale = new Vector3(1f, 1f, 1);
            }
        }
    }
}