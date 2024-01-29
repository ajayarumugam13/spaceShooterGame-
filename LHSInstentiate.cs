using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LHSInstentiate : MonoBehaviour
{
    public GameObject LHSprefab;
    public float spawnInterval;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnPrefab", 0f, spawnInterval);
    }
    public void reduceIntervalTime(float reduceBY)
    {
        spawnInterval -= reduceBY;
    }
    public void increaseIntervalTime(float invreaseBY)
    {
        spawnInterval += invreaseBY;
    }
    void spawnPrefab()
    {
        Instantiate(LHSprefab, transform.position, Quaternion.identity);
    }
}
