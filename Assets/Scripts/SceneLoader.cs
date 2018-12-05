using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    GameSession gs;

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;       
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadStartingScene()
    {
        gs = new GameSession();
        gs.ResetScore();
        SceneManager.LoadScene(0);     
    }
    public void PlayAgain()
    {
        gs = new GameSession();
        int currentSceneIndex = gs.GetLevel();
        gs.PreviousScore();
        SceneManager.LoadScene(currentSceneIndex+1);
    }
}
