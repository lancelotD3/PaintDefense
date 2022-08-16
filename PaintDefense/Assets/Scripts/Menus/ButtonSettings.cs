using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSettings : MonoBehaviour
{
    public void OpenSettings()
    {
        Settings settings = FindObjectOfType<Settings>();
        settings.OpenSettings();
    }
}
