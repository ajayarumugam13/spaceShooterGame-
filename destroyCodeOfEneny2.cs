using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class destroyCodeOfEneny2 : MonoBehaviour
{
    public int lifePoint2;
    public LevelProgressionBar progressionBar;
    public LHSInstentiate fireBallPoint;
    public GameObject startButton;
    public GameObject retryButton;
    public GameObject exitButton;
    public GameObject pauseButton;
    public GameObject bulletSpeedUpgradeButton;
    public GameObject bulletSpawnUpgradeButton;
    public GameObject player;
    public GameObject movingTowardsEn2;
    public GameObject moveTowardsEnemy3;
    public ParticleSystem enemyDeadEffect;
    public AudioSource DeadSound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            lifePoint2--;
            if (lifePoint2 <= 0)
            {
                Time.timeScale = 0f;
                fireBallPoint.reduceIntervalTime(2);
                Destroy(gameObject);
                progressionBar.valueLe3Pro(0.1f);
                startButton.SetActive(true);
                retryButton.SetActive(true);
                exitButton.SetActive(true);
                pauseButton.SetActive(false);
                bulletSpeedUpgradeButton.SetActive(true);
                bulletSpawnUpgradeButton.SetActive(true);
                player.SetActive(false);
                movingTowardsEn2.SetActive(false);
                moveTowardsEnemy3.SetActive(true);
                enemyDeadEffect.Play();
                    DeadSound.Play();
            }
        }
    }
}

