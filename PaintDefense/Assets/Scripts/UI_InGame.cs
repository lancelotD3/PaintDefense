using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_InGame : MonoBehaviour
{
    [SerializeField]
    private LeveManager levelManager;

    [SerializeField]
    Text lifeText;

    [SerializeField]
    Text GoldsText;
    private void Update()
    {
        lifeText.text = levelManager.GetLifeText();
        GoldsText.text = levelManager.GetGoldsText();
    }
}
