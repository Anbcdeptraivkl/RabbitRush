using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// COntroller for Scoring system: the longer Player survive the more score gained
// - Also Control High Score Setting and Saving
public class Score: MonoBehaviour {
    public float timeStep = 1f;
    public Text scoreText;
    static int score = 0;
    Player player;
    float currentStep = 0f;

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

    void Start() {
        score = 0;
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        scoreText.text = score.ToString();
    }

    void Update() {
        if (player.CheckAlive()) {
            UpdateScore();
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