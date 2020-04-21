using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Scoring system: the longer Player survive the more score gained
public class Score: MonoBehaviour {
    public float timeStep = 1f;
    public Text scoreText;
    static int score = 0;
    Player player;
    float currentStep = 0f;

    void Start() {
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