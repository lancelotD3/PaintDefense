using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonChangeScene : MonoBehaviour
{
    [SerializeField]
    string NewSceneName;
    public void ChangeScene()
    {
        SceneManager.LoadScene(NewSceneName);
    }
}
