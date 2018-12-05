using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour {

	// Use this for initialization
	void Start () {

        gameObject.GetComponent<TextMeshProUGUI>().text ="Skor : "+ new GameSession().GetScore().ToString();
	}
	
}
