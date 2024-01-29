using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class onCollOfProjectileAsteroid : MonoBehaviour
{
    //getting thr reference of rigidbidy
    private Rigidbody2D rd;
    //assigning the speed of projectile object
    public float projectileSpeed;

    public Transform player;
    public Transform destroyPoint;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        destroyPoint = GameObject.FindGameObjectWithTag("fireBallDestroy").transform;
        rd = GetComponent<Rigidbody2D>();
        Vector2 direction = (player.position - transform.position).normalized;
        rd.velocity= direction * projectileSpeed;
    }
    private void Update()
    {
        float gotOverThePoint=transform.position.y-destroyPoint.position.y;
        if(gotOverThePoint < 0 )
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
