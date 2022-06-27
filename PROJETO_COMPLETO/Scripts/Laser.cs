using UnityEngine;

public class Laser : MonoBehaviour
{
    private Rigidbody2D laserRb;    
    private float laserSpeed = 400f;
    private int damage = 1;    

    private void Awake()
    {
        laserRb = GetComponent<Rigidbody2D>();        
    }

    private void FixedUpdate()
    {
        laserRb.velocity = new Vector2(laserSpeed * Time.deltaTime, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            EnemyHealth hp = collision.gameObject.GetComponent<EnemyHealth>();
            if (hp != null)
            {
                hp.Damage(damage);                
            }
            Destroy(gameObject, 0.03f);

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "DestroyEnemies")
        {
            Destroy(gameObject, 0.10f);
        }
    }

}
