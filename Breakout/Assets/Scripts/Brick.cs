using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    
    [SerializeField] GameObject explosionPrefab;
    [SerializeField] GameObject[] powerUpPrefabs;
    [SerializeField] byte powerUpPossibilityPercentage = 10;

    GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        if(gameManager != null)
        {
            gameManager.BricksOnLevel++;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);

        if(gameManager != null)
        {
            gameManager.BricksOnLevel--; 
        }
        if(gameManager.bigSize == false && gameManager.SuperBall == false && gameManager.laser == false)
        {
            int randomNumber = Random.Range(0, 100);

            if (randomNumber < powerUpPossibilityPercentage)
            {
                int randomPower = Random.Range(0, powerUpPrefabs.Length);
                Instantiate(powerUpPrefabs[randomPower], transform.position, Quaternion.identity);
            }
        }      
        Destroy(gameObject);
    }
}
