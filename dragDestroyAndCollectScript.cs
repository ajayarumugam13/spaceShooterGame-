using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class dragDestroyAndCollectScript : MonoBehaviour
{
    /*this is code given to the player it inclodes*/
    //initializing bool function for touch input
    private bool isBeingDragged = false;
    //initializing int variable for points 
    public int Points;
    //initializing int variable for coins 
    public int coinsCollected;
    //initializing float variable for spawning interval of buller prefab 
    public float spawnInterval;
    //getting reference of bullet prefab
    public GameObject bulletPrefab;
    //getting the position of bullet spawn point
    public Transform spawnPoint;
    //gettint the reference of retry button
    public GameObject retryButton;
    //gettint the reference of exit button
    public GameObject exitButton;
    //gettint the reference of pause button
    public GameObject pauseButton;
    //getting the reference of text for displaying score
    public Text Score;
    //getting the reference of text for displaying coins
    public Text Coins;
    public AudioSource shootingSound;
    private void Start()
    {
        //initiating the prefab with constant interval of time
        InvokeRepeating("spawnPrefab", 0f, spawnInterval);
    }
    
    public void decreaseSpawnInterval(float decreaseValue)
    {
        /*this code is refered from other game object scripts for decreasing
         spawn intercal*/
        spawnInterval -= decreaseValue;
    }
    public void IncreaseScore(int points)
    {
        //increase the points from other game object sctipt
        Points += points;
    }
    public void decreaseCoin(int decrease)
    {
        //decrease the coins from other game object sctipt
        coinsCollected -= decrease;
    }
    private void Update()
    {
        //stopping the coins collected to 0 not decreasing more dhan that
        if (coinsCollected <= 0)
        {
            coinsCollected = 0;
        }
        UpdatePointsText();
        UpdateCoinText();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Asteroid")|| other.gameObject.CompareTag("poyson")|| other.gameObject.CompareTag("enemy1")
            || other.gameObject.CompareTag("eneny2Bome") || other.gameObject.CompareTag("enemy2") || other.gameObject.CompareTag("fireBallLHS")
            || other.gameObject.CompareTag("Enemy3FireBall"))
        {
            gameObject.SetActive(false);
            Time.timeScale = 0f;
            //activating the retry and exit button when player triggers with certain tagged objects
            retryButton.SetActive(true);
            exitButton.SetActive(true);
            pauseButton.SetActive(false);
        }
        if (other.gameObject.CompareTag("Coin"))
        {
            //increasing the points and coins then coin tagger object triggers
            Points+=10;coinsCollected++;
        }
    }
    public void brigbackSpawn(float normalValue)
    {
        spawnInterval = normalValue;
    }
    void UpdatePointsText()
    {
            // Update the text to show the current points
            Score.text = "Score: " + Points.ToString();

    }
    void UpdateCoinText()
    {
        // Update the text to show the current points
        Coins.text = "Coins: " + coinsCollected.ToString();

    }
    void OnMouseDown()
    {        
        isBeingDragged = true;
        Time.timeScale = 1f;
        shootingSound.Play();
    }

    void OnMouseUp()
    {
        isBeingDragged = false;
        Time.timeScale = 0.4f;
        shootingSound.Stop();
    }

    void OnMouseDrag()
    {
        if (isBeingDragged)
        {
            //move the player along with the pointer
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0; 
            transform.position = mousePosition;
        }
    }
    void spawnPrefab()
    { 
        if(isBeingDragged) 
        {
            //instentiating the bullet prefab fron spawn point
            Instantiate(bulletPrefab, spawnPoint.position, Quaternion.identity);
        }
        
    }
}
