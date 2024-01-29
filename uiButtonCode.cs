using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class uiButtonCode : MonoBehaviour
{
    public GameObject exitButton;
    //level1 buttonce
    public GameObject startButtonLevel1;
    public GameObject pauseButtonLevel1;
    public GameObject playButtonLevel1;
    public GameObject retryButtonLevel1;
    public GameObject player;
    public GameObject bulletSpeedUpgradeButton;
    public GameObject bulletSpeedSpawnUpgradeButton;
    public selfDestroyingByHittingWithAstroid bulletSpeed;
    public dragDestroyAndCollectScript bulletSpawn;
    private void Start()
    {
        Time.timeScale = 0f;
        exitButton.SetActive(true);
        startButtonLevel1.SetActive(true);
        pauseButtonLevel1.SetActive(false);
        playButtonLevel1.SetActive(false);
        retryButtonLevel1.SetActive(false);
        player.SetActive(false);
        bulletSpeedUpgradeButton.SetActive(false);
        bulletSpeedSpawnUpgradeButton.SetActive(false);
    }
    public void exidButtonCodeLevel1()
    {
        Application.Quit();
    }
    public void startButtonCodeLevel1()
    {
        pauseButtonLevel1.SetActive(true);
        Time.timeScale = 0.4f;
        exitButton.SetActive(false);
        startButtonLevel1.SetActive(false);
        player.SetActive(true);
        retryButtonLevel1.SetActive(false);
        bulletSpeedSpawnUpgradeButton.SetActive(false);
        bulletSpeedUpgradeButton.SetActive(false);
    }
    public void pauseButtonCodeLevel1()
    {
        playButtonLevel1.SetActive(true);
        exitButton.SetActive(true);
        retryButtonLevel1.SetActive(true);
        pauseButtonLevel1.SetActive(false);
        player.SetActive(false);
        Time.timeScale = 0f;
    }
    public void playButtonCodeLevel1()
    {
        player.SetActive(true);
        playButtonLevel1.SetActive(false);
        exitButton.SetActive(false);
        retryButtonLevel1.SetActive(false);
        pauseButtonLevel1.SetActive(true);
        Time.timeScale = 0.4f;
    }
    public void upgradeBulletSpeedCode()
    {
        if (bulletSpawn.coinsCollected > 20)
        {
            bulletSpeedUpgradeButton.SetActive(false);
            bulletSpeed.speedUpgrade(1f);
            bulletSpawn.decreaseCoin(20);
        }

    }
    public void upgradeBulletSpawn()
    {
        if(bulletSpawn.coinsCollected > 20)
        {
            bulletSpawn.decreaseSpawnInterval(0.1f);
            bulletSpeedSpawnUpgradeButton.SetActive(false);
            bulletSpawn.decreaseCoin(20);
        }

    }
    public void retryButtonCodeLevel1()
    {
        bulletSpeed.bringBacknormal(6);
        bulletSpawn.brigbackSpawn(0.5f);
        SceneManager.LoadScene(0);

    }
}
