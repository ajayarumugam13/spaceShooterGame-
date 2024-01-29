using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class codeInTheAcidBottleSpawnFromEnemy : MonoBehaviour
{
    public float speed;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
