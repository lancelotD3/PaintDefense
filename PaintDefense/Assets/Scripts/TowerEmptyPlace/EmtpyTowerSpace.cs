using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Helpers.Utils;

public class EmtpyTowerSpace : MonoBehaviour
{
    [SerializeField]
    private ClassicTowerButton classicTowerButton;
    [SerializeField]
    private BigTowerButton     BigTowerButton;
    [SerializeField]
    private SlowTowerButton SlowTowerButton;

    private bool towersHidden = true;

    private void OnMouseEnter()
    {
        gameObject.transform.localScale = new Vector3(1.2f, 1.2f, 1);
    }

    private void OnMouseDown()
    {
        classicTowerButton.gameObject.SetActive(true);
        BigTowerButton.gameObject.SetActive(true);
        SlowTowerButton.gameObject.SetActive(true);

        towersHidden = false;
    }

    private void Update()
    {
        if (!towersHidden)
        {

            if (Vector3.Distance(gameObject.transform.position, MouseHelper.GetMousePos()) > 1f)
            {
                classicTowerButton.gameObject.SetActive(false);
                BigTowerButton.gameObject.SetActive(false);
                SlowTowerButton.gameObject.SetActive(false);
                towersHidden = true;
            }
        }
        else
        {
            if (Vector3.Distance(gameObject.transform.position, MouseHelper.GetMousePos()) > 1f)
            {
                gameObject.transform.localScale = new Vector3(1f, 1f, 1);
            }
        }
    }

    public void Activate()    => gameObject.SetActive(true);
    public void Desactivate() => gameObject.SetActive(false);
}
