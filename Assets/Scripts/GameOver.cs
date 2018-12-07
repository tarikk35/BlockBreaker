using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour {

    GameSession session;
	// Use this for initialization
	void Start () {
        session = gameObject.AddComponent<GameSession>() as GameSession;
        GameObject.FindGameObjectWithTag("ScoreText").GetComponent<TextMeshProUGUI>().text = "Skor : "+ session.GetScore().ToString();
        SpriteRenderer spriteRenderer=FindObjectOfType<SpriteRenderer>();
        spriteRenderer.sprite = session.GetPreviousSprite();
        spriteRenderer.color = Color.red;
    }
	
}
