using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public enum PowerUpType
    {
        Increasesize,
        SuperBall,
        Laser
    }

    [SerializeField] float speed = 5;

    public PowerUpType powerUpType;
    

    private void Start()
    {
        Destroy(gameObject, 10);
    }

    private void Update()
    {
        transform.position += Time.deltaTime * Vector3.down * speed;
    }
}
