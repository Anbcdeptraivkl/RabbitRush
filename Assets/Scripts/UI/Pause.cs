using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Controller: Pausing the Game with Pause Menu
public class Pause : MonoBehaviour
{
    public GameObject pauseMenu;
    bool pausing;
    
    // Start is called before the first frame update
    public void MainMenu() {
        Time.timeScale = 1;
        pausing = false;
        SceneManager.LoadScene(0);
    }

    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Debug.Log("Again...");
    }

    public void Unpause() {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        pausing = false;
    }

    public void TogglePause() {
         if (pausing) {
            Unpause();
        } else {
            Pausing();
        }
    }

    void Start() {
        Time.timeScale = 1;
        // Disable by Default
        if (pauseMenu.activeSelf) {
            pauseMenu.SetActive(false);
        }
        pausing = false;
        Debug.Log("Pausing: " + pausing);
    }

    void Update() {
        // Toggling Pausing
        if (Input.GetButtonDown("Pause")) {
           TogglePause();
        }
    }

    void Pausing() {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        pausing = true;
    }
}
