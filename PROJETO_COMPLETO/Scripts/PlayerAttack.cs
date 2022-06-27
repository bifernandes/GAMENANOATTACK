using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform laser;
    private GameObject originLaser;    
    private float laserRate = 0.25f;
    private float laserCoolDown;

    private AudioSource sound;

    private void Awake()
    {
        originLaser = GameObject.Find("OriginLaser");
        sound = GetComponent<AudioSource>();
    }

    void Start()
    {
        laserCoolDown = 0;
    }
    
    void Update()
    {
        if (Input.GetButtonDown("Fire1") || Input.GetKey(KeyCode.Space))
        {
            Attack();            
        }

        if (laserCoolDown > 0)
        {
            laserCoolDown -= Time.deltaTime;
        }
    }

    private void Attack()
    {
        if (laserCoolDown <= 0)
        {
            laserCoolDown = laserRate;
            var laserTransform = Instantiate(laser) as Transform;            
            laserTransform.position = originLaser.transform.position;
            sound.Play();
        } 
    }
    
}
