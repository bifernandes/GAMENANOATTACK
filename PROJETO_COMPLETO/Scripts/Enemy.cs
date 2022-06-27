using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D enemyRb;
    private static float enemySpeed = 100f; 

    private void Awake()
    {
        enemyRb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        enemyRb.velocity = new Vector2(-enemySpeed * Time.deltaTime, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Explosion")
        {            
            Destroy(gameObject, 0.03f);
        }
    }

    public static float SetEnemySpeed(float val)
    {
        enemySpeed = val;
        return enemySpeed;
    }
}
