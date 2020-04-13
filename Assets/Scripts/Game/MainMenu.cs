using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Main Menu Functionalities
public class MainMenu: MonoBehaviour {

    public void Play() {
        SceneManager.LoadScene("Play");
    }

    public void Quit() {
        Application.Quit();
    }
}