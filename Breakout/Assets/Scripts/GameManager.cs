using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] float gameTime;
    [SerializeField] public byte bricksOnLevel;

    public bool laser;
    public bool bigSize;

    private bool superBall;
    UIController uiController;
    Ball ball;

    private void Start()
    {
        uiController = FindObjectOfType<UIController>();
        ball = FindObjectOfType<Ball>();
    }

    public bool SuperBall
    {
        get => superBall;
        set
        {
            superBall = value;
            ball.ToggleTrail();
        }
    }

    public byte BricksOnLevel
    {
        get => bricksOnLevel;
        set
        {
            bricksOnLevel = value;
            if( bricksOnLevel == 0)
            {
                //congelar la bola
                Destroy(GameObject.Find("PowerUpSuperBall"));
                Destroy(GameObject.Find("Ball"));
                gameTime = Time.time * gameTime;
                uiController.ActivateWinnerPanel(gameTime);
                gameTime = Time.time - gameTime;
            }
        }
    }

    [SerializeField] byte playerLives = 3;

    public byte PlayerLives
    {
        get => playerLives;
        set
        {
            playerLives = value;
            if(playerLives == 0)
            {
                Destroy(ball.gameObject);
                uiController.ActivateLosePanel();
            }
            else
            {
                ball.ResetBall();
            }
            uiController.UpdateUILives(playerLives);
        }
    }

    [SerializeField] bool gameStarted;

    public bool GameStarted
    {
        get => gameStarted;
        set
        {
            gameStarted = value;
            gameTime = Time.time;
        }
    }

    [SerializeField] bool ballOnPlay;

    public bool BallOnPlay
    {
        get => ballOnPlay;
        set
        {
            ballOnPlay = value;
            if(ballOnPlay == true)
            {
                ball.LaunchBall();
            }
        }
    }
}
