using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    //Configuration parameters
    [SerializeField] Paddle paddle1;
    [SerializeField] float xPush, yPush;
    [SerializeField] AudioClip []ballSounds;

    //Cache components
    AudioSource myAudioSource;

    bool hasStarted;
    Vector2 paddleToBallPosition;

	// Use this for initialization
	void Start () {
        paddleToBallPosition = transform.position - paddle1.transform.position;
        hasStarted = false;
        myAudioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!hasStarted)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasStarted)
        {
            AudioClip ballSound = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            myAudioSource.PlayOneShot(ballSound);
        }
    }

    private void LaunchOnMouseClick()
    {
        if(Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(xPush, yPush);
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePosition = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePosition + paddleToBallPosition;
    }
}
