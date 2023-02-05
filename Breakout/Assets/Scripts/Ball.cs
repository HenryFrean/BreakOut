using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigidbody2D;
    [SerializeField] float speed = 3f; 
    [SerializeField] AudioClip paddleBounce;
    [SerializeField] AudioClip bounce;
    [SerializeField] AudioClip loseLife;
    [SerializeField] float yMinSpeed = 2;
    [SerializeField] TrailRenderer trail;

    AudioController audioController;
    GameManager gameManager;
    Vector2 moveDirection;
    Vector2 currentVelocity;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        audioController = FindObjectOfType<AudioController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        currentVelocity = rigidbody2D.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("Brick") && gameManager.SuperBall == true)
        {
            rigidbody2D.velocity = currentVelocity;
            return;
        }

        moveDirection = Vector2.Reflect(currentVelocity, collision.GetContact(0).normal);

        if(gameManager.BallOnPlay)
        {
            if(Mathf.Abs(moveDirection.y) < yMinSpeed)
            {
                moveDirection.y = yMinSpeed * Mathf.Sign(moveDirection.y);
            }
        }

        rigidbody2D.velocity = moveDirection;

        if(collision.transform.CompareTag("DeathLimit"))
        {
            audioController.PlaySfx(loseLife);
            if(gameManager != null)
            {
                gameManager.PlayerLives--;
            }          
        }

        if(collision.transform.CompareTag("Player"))
        {
            audioController.PlaySfx(paddleBounce);
        }

        if(collision.transform.CompareTag("Brick"))
        {
            audioController.PlaySfx(bounce);
        }
    }

    public void LaunchBall()
    {
        transform.SetParent(null);
        rigidbody2D.velocity = Vector2.up * speed;
    }

    public void ResetBall()
    {
        rigidbody2D.velocity = Vector3.zero;
        Transform paddle = GameObject.Find("Paddle").transform;
        paddle.localScale = new Vector3(1, 1, 1);
        transform.SetParent(paddle);
        Vector2 ballPosition = paddle.position;
        ballPosition.y += 0.5f;
        transform.position = ballPosition;
        gameManager.BallOnPlay = false;
    }

    public void ToggleTrail()
    {
        if(trail.enabled == true)
        {
            trail.enabled = false;
        }
        else
        {
            trail.enabled = true;
        }
    }
}
