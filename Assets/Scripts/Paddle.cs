using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    [SerializeField] public float screenWidthUnits;
    [SerializeField] public float minimumX = 1.75f;
    [SerializeField] public float maximumX = 14.25f;

    //cached references
    GameSession session;
    Ball ball;

    private void Start()
    {
        session = FindObjectOfType<GameSession>();
        ball = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update () {
        Vector2 vectorPos = new Vector2(transform.position.x, transform.position.y);
        vectorPos.x = Mathf.Clamp(GetXPosition(),minimumX,maximumX); 
        transform.position = vectorPos;
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<AudioSource>().Play();
    }

    private float GetXPosition()
    {
        if(session.IsAutoPlayEnabled())
        {
            return ball.transform.position.x;
        }
        else
        {
            return (Input.mousePosition.x / Screen.width) * screenWidthUnits;
        }
    }
}
