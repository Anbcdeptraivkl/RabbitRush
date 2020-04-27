using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// General Controller: Handle Functionalities on Game Over
public class GameOver: MonoBehaviour {
    public GameObject gameOverCanvas;
    // References
    Player player;
    SpawnController spawnController;
    Score scoreController;
    // Score Showcase
    Text score;
    // Highscore on Finish
    GameObject highscoreShow;

    public void MainMenu() {
        SceneManager.LoadScene("MainMenu");
        Debug.Log("Back to Menu!");
    }

    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Debug.Log("Again...");
    }

    void Start() {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        // Component in the current Game Controller
        spawnController = GetComponent<SpawnController>();
        scoreController = GetComponent<Score>();
        // Disable the UI at the beginning
        if (gameOverCanvas.activeSelf) {
            gameOverCanvas.SetActive(false);
        }
        // Score Text inside Game Over Canvas
        score = gameOverCanvas.transform.Find("Score").gameObject.GetComponent<Text>();
        // Highscore Announcement
        highscoreShow = gameOverCanvas.transform.Find("High Score").gameObject;
        if (highscoreShow.activeSelf) {
            highscoreShow.SetActive(false);
        }
    }

    void Update() {
        // Game Over when Player died
        if (!player.CheckAlive() && !gameOverCanvas.activeSelf) {
            // Stop Spawning
            spawnController.StopSpawning();
            // Freeze all active Obstacles
            Obstacle[] obstacles = GameObject.FindObjectsOfType<Obstacle>();
            foreach (Obstacle obstacle in obstacles) {
                obstacle.StopMoving();
            }
            Over();
        }
    }

    void Over() {
        // Final Score
        score.text = "Score: " + scoreController.CurrentScore;
        // Activate Game Over UI
        gameOverCanvas.SetActive(true);
        // Checking for New High Score Showing
        if (scoreController.HighScoreCheck()) {
            highscoreShow.SetActive(true);
        }
        Debug.Log("Game Over!");
    }
}