using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Handle Functionalities on Game Over
public class GameOver: MonoBehaviour {
    public GameObject gameOverCanvas;
    // References
    Player player;
    SpawnController spawnController;

    void Start() {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        // Component in the current Game Controller
        spawnController = GetComponent<SpawnController>();
        // Disable the UI at the beginning
        if (gameOverCanvas.activeSelf) {
            gameOverCanvas.SetActive(false);
        }
    }

    void Update() {
        // Game Over when Player died
        if (!player.CheckAlive()) {
            // Stop Spawning
            spawnController.StopSpawning();
            // Freeze all active Obstacles
            Obstacle[] obstacles = GameObject.FindObjectsOfType<Obstacle>();
            foreach (Obstacle obstacle in obstacles) {
                obstacle.StopMoving();
            }
            // Activate Game Over UI
            gameOverCanvas.SetActive(true);
            Debug.Log("Game Over!");
        }
    }

    public void MainMenu() {
        SceneManager.LoadScene("MainMenu");
        Debug.Log("Back to Menu!");
    }

    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Debug.Log("Again...");
    }
}