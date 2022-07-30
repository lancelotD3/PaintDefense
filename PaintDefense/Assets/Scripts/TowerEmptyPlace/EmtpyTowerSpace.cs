using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Helpers.Utils;

public class EmtpyTowerSpace : MonoBehaviour
{
    [SerializeField]
    private ClassicTowerButton classicTowerButton;
    
    private void OnMouseEnter()
    {
        gameObject.transform.localScale = new Vector3(1.2f, 1.2f, 1);
    }

    private void OnMouseDown()
    {
        classicTowerButton.gameObject.SetActive(true);
    }

    private void Update()
    {
        if (classicTowerButton.gameObject.active)
        {

            if (Vector3.Distance(classicTowerButton.gameObject.transform.position, MouseHelper.GetMousePos()) > 1f)
            {
                classicTowerButton.gameObject.SetActive(false);
            }
        }
        else
        {
            if (Vector3.Distance(classicTowerButton.gameObject.transform.position, MouseHelper.GetMousePos()) > 1f)
            {
                gameObject.transform.localScale = new Vector3(1f, 1f, 1);
            }
        }
    }

    public void Activate()    => gameObject.SetActive(true);
    public void Desactivate() => gameObject.SetActive(false);

}
