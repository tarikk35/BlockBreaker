using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour {
 
    [Range(0.1f,4f)][SerializeField] float gameSpeed = 1f;
    [SerializeField] int perBlockScore = 100;
    TextMeshProUGUI scoreText;
    static int currentScore = 0;

    private void Start()
    {
        scoreText = FindObjectOfType<TextMeshProUGUI>();
        scoreText.text = currentScore.ToString();
    }

    // Update is called once per frame
    void Update () {
        Time.timeScale = gameSpeed;
	}

    public void AddScore()
    {
        currentScore += perBlockScore;
        scoreText.text = currentScore.ToString();
    }

    public void ResetScore()
    {
        Debug.Log(currentScore);
        currentScore = 0;
        Debug.Log(currentScore);
    }
}
