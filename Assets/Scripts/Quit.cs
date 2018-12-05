using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour {

	public void QuitApplication()
    {
        GameSession gs=new GameSession();
        gs.ResetScore();
        Application.Quit();       
    }
}
