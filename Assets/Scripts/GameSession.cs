using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour {
 
    [Range(0.1f,4f)][SerializeField] float gameSpeed = 1f;
    [SerializeField] int perBlockScore = 100;
    TextMeshProUGUI scoreText;
    [SerializeField] bool isAutoPlay = false;

    static int previousLevelScore=0;
    static int currentScore = 0;
    static int levelCount = 0;
    static int highestLevel = 0;
    static Sprite levelSprite;

    private void Start()
    {
        if(SceneManager.GetActiveScene().buildIndex>0&&SceneManager.GetActiveScene().buildIndex<(SceneManager.sceneCountInBuildSettings-2))
        {
            scoreText = FindObjectOfType<TextMeshProUGUI>();
            scoreText.text = currentScore.ToString();
        }            
        if(SceneManager.GetActiveScene().buildIndex!=SceneManager.sceneCount-1)
        {
           levelSprite = GameObject.Find("BackgroundImage").GetComponent<SpriteRenderer>().sprite;
        }    
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
        currentScore = 0;
        previousLevelScore = 0;
    }

    public void PreviousScore()
    {
        currentScore = previousLevelScore;
    }

    public int GetLevel()
    {       
        return levelCount;
    }

    public void ResetLevel()
    {
        levelCount = 0;
    }

    public void LevelUp()
    {
        levelCount++;
        previousLevelScore = currentScore;
        if (levelCount > highestLevel)
        {
            highestLevel = levelCount;
        }
    }

    public Sprite GetPreviousSprite()
    {
        return levelSprite;
    }

    public int GetScore()
    {
        return currentScore;
    }

    public bool IsAutoPlayEnabled()
    {
        return isAutoPlay;
    }
}
