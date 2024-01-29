using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class destroyOfEnemy3 : MonoBehaviour
{
    public int lifeLine;
    public GameObject retryButton;
    public GameObject exitButton;
    public GameObject player;
    public GameObject pauseButton;
    public AudioSource deadSound;
    public ParticleSystem burstEffect;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            lifeLine--;
            if (lifeLine < 0)
            {
                Destroy(gameObject);
                Time.timeScale = 0;
                retryButton.SetActive(true); exitButton.SetActive(true);    
                player.SetActive(false);
                pauseButton.SetActive(false);
                deadSound.Play();
                burstEffect.Play(); 
            }
        }
    }

}
