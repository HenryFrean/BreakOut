using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] float xLimit = 7.5f;
    [SerializeField] float xLimitWhenBig = 6;
    [SerializeField] byte bigSizeTime = 10;
    [SerializeField] byte superBallTime = 10;
    [SerializeField] byte laserTime = 10;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Vector3 shootingOffSet;

    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.D) && transform.position.x < xLimit)
        {
            transform.position += Time.deltaTime * Vector3.right * speed;
        }
        if (Input.GetKey(KeyCode.A) && transform.position.x > -xLimit)
        {
            transform.position += Time.deltaTime * Vector3.left * speed;
        }
        if(Input.GetMouseButtonDown(0))
        {
            if(gameManager.BallOnPlay == false)
            {
                gameManager.BallOnPlay = true;
            }
            if(gameManager.GameStarted == false)
            {
                gameManager.GameStarted = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("PowerUp"))
        {
            if(collision.GetComponent<PowerUp>().powerUpType == PowerUp.PowerUpType.Increasesize)
            {
                gameManager.bigSize = true;
                StartCoroutine(BigSizePower());
            }
            else if(collision.GetComponent<PowerUp>().powerUpType == PowerUp.PowerUpType.SuperBall)
            {
                gameManager.SuperBall = true;
                StartCoroutine(StopSuperBall());
            }
            else if(collision.GetComponent<PowerUp>().powerUpType == PowerUp.PowerUpType.Laser)
            {
                gameManager.laser = true;
                StartCoroutine(ContinouShooting());
            }
            Destroy(collision.gameObject);
        }
    }

    IEnumerator BigSizePower()
    {
        float originalXLimit = xLimit;
        xLimit = xLimitWhenBig;
        Vector3 newSize = transform.localScale;

        while (transform.localScale.x < 1.5f)
        {
            newSize.x += Time.deltaTime;
            transform.localScale = newSize;
        }

        yield return new WaitForSeconds(bigSizeTime);

        while(transform.localScale.x > 1)
        {
            newSize.x -= Time.deltaTime;
            transform.localScale = newSize;
        }
        gameManager.bigSize = false;
        xLimit = originalXLimit;
    }

    IEnumerator StopSuperBall()
    {
        yield return new WaitForSeconds(superBallTime);
        gameManager.SuperBall = false;
    }

    IEnumerator ContinouShooting()
    {
        float stopShootingTime = Time.time + laserTime;
        while(Time.time < stopShootingTime)
        {
            Instantiate(bulletPrefab, transform.position + shootingOffSet, Quaternion.identity);
            yield return new WaitForSeconds(1);
        }    
        gameManager.laser = false;
    }
}
