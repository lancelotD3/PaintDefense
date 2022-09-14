using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Helpers.Utils;

public class ElfeDonjonlvl3Collider : MonoBehaviour
{
    private ElfeDonjonlvl3 parent;

    [SerializeField]
    private ElrauDonjonButton elrauDonjonButton;
    private bool towersHidden = true;

    private void Awake()
    {
        parent = GetComponentInParent<ElfeDonjonlvl3>();
    }

    private void OnMouseEnter()
    {
        parent.gameObject.transform.localScale = new Vector3(1.2f, 1.2f, 1);
    }

    private void OnMouseDown()
    {
        elrauDonjonButton.gameObject.SetActive(true);
        towersHidden = false;
    }

    private void Update()
    {
        if (!towersHidden)
        {
            if (Vector3.Distance(gameObject.transform.position, MouseHelper.GetMousePos()) > 1.5f)
            {
                elrauDonjonButton.gameObject.SetActive(false);
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
