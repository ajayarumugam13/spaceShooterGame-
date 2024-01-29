using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyCodeOfEnemy1 : MonoBehaviour
{

    public int lifePoint;
    public LevelProgressionBar progressionBar;
    public GameObject fireBall;
    public LHSInstentiate fireballInsPoint;
    public GameObject speedUpgradeButton;
    public GameObject spawnUpgradeButton;
    public GameObject startButton;
    public GameObject exitButton;
    public GameObject retryButton;
    public GameObject pauseButton;
    public GameObject player;
    public GameObject movingTowardsEn1;
    public GameObject movingTowardsEn2;
    public ParticleSystem en1BurstEffect;
    public AudioSource en1BurstSound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            lifePoint--;
            if (lifePoint <= 0)
            {

                progressionBar.valueLe2Pro(0.1f);
                Destroy(gameObject,0.29f);
                fireBall.SetActive(true);
                fireballInsPoint.increaseIntervalTime(2);
                Time.timeScale = 0f;
                speedUpgradeButton.SetActive(true);
                spawnUpgradeButton.SetActive(true);
                startButton.SetActive(true);
                exitButton.SetActive(true);
                retryButton.SetActive(true);
                pauseButton.SetActive(false);
                player.SetActive(false);
                movingTowardsEn1.SetActive(false);
                movingTowardsEn2.SetActive(true);
                en1BurstEffect.Play();
                en1BurstSound.Play();
            }
        }
    }
}
