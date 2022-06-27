using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D playerRb;
    private float playerSpeed = 300f;
    private Vector2 movement;
    private bool regionBoss = false;    

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();        
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Move(h,v);
    }

    private void Move(float h, float v)
    {
        movement.Set(h, v);
        playerRb.velocity = playerSpeed * Time.deltaTime * movement;
    }   

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Acceleration" && (regionBoss == false))
        {            
            SideScroller.SetSceneSpeed(400f);
            Enemy.SetEnemySpeed(800f);
        }        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Acceleration" && (regionBoss == false))
        {            
            SideScroller.SetSceneSpeed(200f);
            Enemy.SetEnemySpeed(400f);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "AccelerationInter" && (regionBoss == false))
        {
            SideScroller.SetSceneSpeed(200f);
            Enemy.SetEnemySpeed(400f);
        }

        if (col.gameObject.tag == "BossRegion")
        {
            regionBoss = true;            
            SideScroller.SetSceneSpeed(5f);
            Enemy.SetEnemySpeed(10f);
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "AccelerationInter" && (regionBoss == false))
        {
            SideScroller.SetSceneSpeed(100f);
            Enemy.SetEnemySpeed(200f);
        }
    }

}