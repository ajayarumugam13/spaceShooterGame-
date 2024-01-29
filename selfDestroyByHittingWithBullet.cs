using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class selfDestroyByHittingWithBullet : MonoBehaviour
{
    public GameObject coinPrefab;
    public int noOfAttByBullet = 3;
    public ParticleSystem asteroidBurstingEffect;
    public Collider2D col;
    public AudioSource rockBursting;
    public SpriteRenderer sp;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            StartCoroutine(Backward());
            noOfAttByBullet--;
            if (noOfAttByBullet <= 0)
            {
                DestroyAsteroid(); // Destroy the asteroid and spawn a coin
                asteroidBurstingEffect.Play();
                rockBursting.Play();
            }
        }
    }
    private void DestroyAsteroid()
    {
        col.enabled=false;
        dragDestroyAndCollectScript scoreManager = FindObjectOfType<dragDestroyAndCollectScript>();
        scoreManager.IncreaseScore(10);
        Instantiate(coinPrefab, transform.position, Quaternion.identity); // Spawn a coin
        Destroy(gameObject,0.29f); // Destroy the asteroid
        sp.enabled=false;

    }
    IEnumerator Backward()
    {
        transform.Translate(Vector3.up* 3*Time.deltaTime);
        yield return new WaitForSeconds(0.2f); // Adjust the duration as needed
        transform.Translate(Vector3.up * 0);
    }
}
