using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prefabRandomInstentiate : MonoBehaviour
{
    public GameObject[] prefabs;  // Array to store your prefabs
    public Transform point1;       // Starting point
    public Transform point2;       // Ending point


    void Start()
    {
        // Start the spawning coroutine
        StartCoroutine(SpawnPrefabsContinuously());
    }

    IEnumerator SpawnPrefabsContinuously()
    {
        while (true)
        {
            // Instantiate three prefabs randomly at point1
            GameObject prefab1 = Instantiate(prefabs[Random.Range(0, prefabs.Length)], point1.position, Quaternion.identity);
            // Move prefabs towards point2
            MovePrefabTowardsPoint2(prefab1);
            // Wait for a random interval between 1 and 3 seconds
            float interval = Random.Range(2f, 4f);
            yield return new WaitForSeconds(interval);
        }
    }

    void MovePrefabTowardsPoint2(GameObject prefab)
    {
        // Attach a script to move the prefab towards point2
        prefab.AddComponent<maveAndDestroyAtP2>();
        // Set the point2 in the script
        prefab.GetComponent<maveAndDestroyAtP2>().SetPoint2(point2);
    }
}
