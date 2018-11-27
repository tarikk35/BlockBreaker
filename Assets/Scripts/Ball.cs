using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    [SerializeField] Paddle paddle;
    [SerializeField] float bouncePowerY = 12f;
    [SerializeField] float bouncePowerX = 0f;

    Vector2 paddleDistance;

    bool isStarted = false;

	// Use this for initialization
	void Start ()
    {
        paddleDistance = transform.position - paddle.transform.position;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(!isStarted)
        {           
            LockBallToPaddle();
            LaunchOnClick();
        }
        
    }

    private void LaunchOnClick()
    {
        // button0 = Left Mouse
        if(Input.GetMouseButtonDown(0))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(bouncePowerX, bouncePowerY);
            isStarted = true;
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = paddlePos + paddleDistance;
    }
}
