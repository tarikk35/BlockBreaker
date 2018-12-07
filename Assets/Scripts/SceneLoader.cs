using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    GameSession gs;
    float clipLength;
    int sceneIndex;

    private void Start()
    {
        gs = gameObject.GetComponent<GameSession>();
    }

    public void StartGame()
    {
        PlayClickSound();
        Invoke("LoadNextScene",clipLength);
    }

    public void LoadNextScene()
    {
        gs = gameObject.GetComponent<GameSession>();
        sceneIndex = SceneManager.GetActiveScene().buildIndex+1;
        LoadScene();
    }

    public void LoadStartingScene()
    {
        gs = gameObject.GetComponent<GameSession>();
        gs.ResetScore();
        PlayClickSound();
        sceneIndex = 0;
        Invoke("LoadScene", clipLength);     
    }

    public void PlayAgain()
    {
        gs = gameObject.GetComponent<GameSession>();
        sceneIndex = gs.GetLevel()+1;
        gs.PreviousScore();
        PlayClickSound();
        Invoke("LoadScene", clipLength);
    }
    
    void PlayClickSound()
    {
        ClipPlayer ac = GameObject.Find("ClickSound").GetComponent<ClipPlayer>();
        clipLength=ac.GetClipLenght();
        ac.PlayClickSound();
    }

    void LoadScene()
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
