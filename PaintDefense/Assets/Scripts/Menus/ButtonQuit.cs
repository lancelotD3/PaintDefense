using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonQuit : MonoBehaviour
{
    public void ExitGame()
    {
        Application.Quit();

        //Just to make sure its working
        Debug.Log("Game is exiting");
    }
}
