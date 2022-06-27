using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private int enemyHealth = 1;
    private bool isBoss = false;
    private bool canBeDestroyed = false;

    [SerializeField]
    private GameObject win;

    private void Start()
    {
        win.SetActive(false);

        if (this.gameObject.name == "BigBoss")
        {
            enemyHealth = 10;
            isBoss = true;
        }
        else
        {
            enemyHealth = 1;
        }
    }

    public void Damage(int damageCount)
    {
        enemyHealth -= damageCount;       

        if (enemyHealth <= 0 && (canBeDestroyed == true))
        {
            Destroy(gameObject);
            if (isBoss == true)
            {
                GameWin();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "DestroyEnemies")
        {
            canBeDestroyed = true;
        }       
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "DestroyEnemies")
        {
            canBeDestroyed = false;
        }
    }

    private void GameWin()
    {        
        win.SetActive(true);        
        PlayerHealth.loadNextScene = true;
        Timer.StopTimer();
    }

}
