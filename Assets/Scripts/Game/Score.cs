using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// COntroller for Scoring system: 
// - the longer Player survive the more score gained
// - Add Score when Getting Collectibles
// - Also Control High Score Setting and Saving
public class Score: MonoBehaviour {
    public float timeStep = 1f;
    public Text scoreText;
    public int scoreThreshold = 100;
    public int difficultyStep = 100;
    public float difficultyIncrement = 0.1f;
    static int score = 0;
    Player player;
    float currentStep = 0f;
    static float difficultyModifier;

    public static float Difficulty {
        get {
            return difficultyModifier;
        }
    }

    public int CurrentScore {
        get {
            return score;
        }
    }

    // Using PlayerPrefs for Storing and Saving Highscore on Game Over
    public bool HighScoreCheck() {
        int highScore = PlayerPrefs.GetInt("High Score", 0);
        if (score > highScore) {
            PlayerPrefs.SetInt("High Score", score);
            Debug.Log("New High Score!");
            return true;
        } else {
            Debug.Log("No High Score");
            return false;
        }
    }

    // Add Score to the Score Base
    public void AddScore(int adding = 1) {
        score += adding;
    }

    void Start() {
        score = 0;
        difficultyModifier = 1f;
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        scoreText.text = score.ToString();
    }

    void Update() {
        if (player.CheckAlive()) {
            UpdateScore();
        }
        if (score > scoreThreshold) {
            // increase Difficulty every 100 points
            difficultyModifier += 0.1f;
            Debug.Log("Difficulty Speed Mod: " + difficultyModifier);
            scoreThreshold += difficultyStep;
        }
    }

    void UpdateScore() {
        currentStep += Time.deltaTime;
        if (currentStep >= timeStep) {
            score++;
            scoreText.text = score.ToString();
            currentStep = 0f;
        }
    }
}