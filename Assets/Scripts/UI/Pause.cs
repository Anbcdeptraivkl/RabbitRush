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
        SceneManager.LoadScene("MainMenu");
        Debug.Log("Back to Menu!");
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

    void Start() {
        // Disable by Default
        if (pauseMenu.activeSelf) {
            pauseMenu.SetActive(false);
        }
        pausing = false;
    }

    void Update() {
        // Toggling Pausing
        if (Input.GetButtonDown("Pause")) {
            if (pausing) {
                Unpause();
            } else {
                Pausing();
            }
        }
    }

    void Pausing() {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        pausing = true;
    }
}
