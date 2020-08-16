using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Main Menu Functionalities
public class MainMenu: MonoBehaviour {

    public void Play() {
        SceneManager.LoadScene(1);
    }

    public void Quit() {
        Application.Quit();
    }

    public void ResetHighScore() {
        PlayerPrefs.SetInt("High Score", 0);
    }
}