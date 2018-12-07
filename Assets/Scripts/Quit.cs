using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour {

	public void QuitApplication()
    {
        GameSession gs = gameObject.GetComponent<GameSession>();
        gs.ResetScore();
        GameObject.Find("ClickSound").GetComponent<ClipPlayer>().PlayClickSound();
        Application.Quit();
    }
}
