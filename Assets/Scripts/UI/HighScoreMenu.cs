using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreMenu : MonoBehaviour
{
    public Text highScoreText;

    private void OnEnable() {
        ShowHighScore();
    }

    void ShowHighScore() {
        highScoreText.text = GetHighScore().ToString();
    }

    public int GetHighScore() {
        return PlayerPrefs.GetInt("High Score", 0);
    }

    public void ResetHighScore() {
        PlayerPrefs.SetInt("High Score", 0);
        ShowHighScore();
    }
}
