using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selfDestroyingByHittingWithAstroid : MonoBehaviour
{
    public float speed;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Asteroid"))
        {
            Destroy(gameObject);
        }
        if (collision.CompareTag("enemy1")|| collision.CompareTag("enemy2") || collision.CompareTag("enemy3"))
        {
            Destroy(gameObject);
        }
    }
    public void bringBacknormal(int normalValue)
    {
        speed= normalValue;
    }
    public void speedUpgrade(float speedIncreased)
    {
        speed += speedIncreased;
    }
    private void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
