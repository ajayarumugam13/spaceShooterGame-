using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingHorizontallyAndShooting : MonoBehaviour
{
    //getting a reference of the path of the player
    public Transform[] targetObjects;
    //initiating the float for assingning the speed of the object moveing towards the path 
    public float moveSpeed = 5f;
    private int currentTargetIndex = 0;
    public Transform spawnPoint;
    public GameObject poisonPrefab;
    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(poisonSpawn());
    }
    IEnumerator poisonSpawn()
    {
        float spawnInterval = Random.Range(1f, 4f);
        InvokeRepeating("spawnPrefab", 0f, spawnInterval);
        yield return new WaitForSeconds(0.01f);
    }
    // Update is called once per frame
    void Update()
    {

        if (targetObjects.Length > 0)
        {
            // Calculate direction to move towards the current target
            Vector2 direction = (targetObjects[currentTargetIndex].position - transform.position).normalized;

            // Move the player towards the current target
            transform.Translate(direction * moveSpeed * Time.deltaTime);

            // Check if the player is close enough to the current target
            if (Vector2.Distance(transform.position, targetObjects[currentTargetIndex].position) < 0.1f)
            {
                // Switch to the next target
                currentTargetIndex = (currentTargetIndex + 1) % targetObjects.Length;
            }
        }
    }
    void spawnPrefab()
    {
        Instantiate(poisonPrefab, spawnPoint.position, Quaternion.identity); 
    }
}
