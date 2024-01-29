using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selfDestroedByPlayer : MonoBehaviour
{
    public AudioSource collectable;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            collectable.Play();
        }
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
