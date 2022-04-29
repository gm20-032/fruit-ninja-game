using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartPopup : BasePopup
{
    public void OnExitGameButton()
    {
        Debug.Log("Exiting Game");
        Application.Quit();
    }

    public void OnStartButton()
    {
        SceneManager.LoadScene("GameScene");
        Close();
    }
}
