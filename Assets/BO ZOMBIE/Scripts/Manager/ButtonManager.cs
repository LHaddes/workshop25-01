using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public GameObject panelCommands;
    public void Play()
    {
        SceneManager.LoadScene("SceneProto");
    }

    public void Commands()
    {
        panelCommands.SetActive(true);
    }

    public void Back()
    {
        panelCommands.SetActive(false);
    }
    public void OnQuit()
    {
        Application.Quit();
    }
}
