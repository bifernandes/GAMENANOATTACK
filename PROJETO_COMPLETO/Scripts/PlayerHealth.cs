using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{        
    private float energy = 1f;
    private float energyMax = 80f;
    [SerializeField]
    private Image energyBar;
    [SerializeField]
    private GameObject lose;
    public static bool loadNextScene = false;  

    private float Energy
    {
        get
        {
            return energy;
        }
        set
        {
            energy = Mathf.Clamp(value, 0, energyMax);
        }
    }    

    private void Start()
    {
        energy = energyMax;
        lose.SetActive(false);        
    }

    private void Update()
    {
        UpdateEnergyBar();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            DamageToPlayer();            
        }

        if (collision.gameObject.tag == "Explosion")
        {
            ExplosionPlayer();
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            DamageToPlayer();
        }
    }

    private void DamageToPlayer()
    {
        energy -= 1;
        if (energy <= 0)
        {
            ExplosionPlayer();            
        }       
    }

    private void ExplosionPlayer()
    {
        energy = 0;
        Destroy(gameObject, 3f);
        lose.SetActive(true);
        Timer.StopTimer();        
    }

    private void UpdateEnergyBar()
    {
        energyBar.fillAmount = Energy / energyMax;
    } 
}
