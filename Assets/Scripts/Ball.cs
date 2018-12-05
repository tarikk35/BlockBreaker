using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    [SerializeField] Paddle paddle;
    [SerializeField] float bouncePowerY = 12f;
    [SerializeField] float randomFactor = 0.2f;

    Vector2 paddleDistance;
    Rigidbody2D rb2d;

    public bool isStarted =false;

	// Use this for initialization
	void Start ()
    {
        paddleDistance = transform.position - paddle.transform.position;
        rb2d = GetComponent<Rigidbody2D>();
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
            float mousePos = (Input.mousePosition.x / Screen.width) * paddle.screenWidthUnits;
            Vector2 vectorPos = new Vector2(transform.position.x, transform.position.y);
            vectorPos.x = Mathf.Clamp(mousePos, paddle.minimumX, paddle.maximumX);
            rb2d.velocity = new Vector2(vectorPos.x, bouncePowerY);
            GetComponent<AudioSource>().Play();
            isStarted = true;
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = paddlePos + paddleDistance;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityFix = new Vector2(UnityEngine.Random.Range(0f, randomFactor), UnityEngine.Random.Range(0f, randomFactor));
        rb2d.velocity += velocityFix;
    }
}
