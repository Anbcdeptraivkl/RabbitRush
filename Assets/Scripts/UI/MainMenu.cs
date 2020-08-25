using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Main Menu Functionalities
public class MainMenu: MonoBehaviour {

    public GameObject highScorePanel;

    public void Play() {
        SceneManager.LoadScene(1);
    }

    public void Quit() {
        Application.Quit();
    }

    public void ShowHighScorePanel() {
        highScorePanel.SetActive(true);
    }

    public void HideHighScorePanel() {
        highScorePanel.SetActive(false);
    }
}