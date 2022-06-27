using UnityEngine;
using System;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private static bool timerActive = false;
    private float currentTime;
    private int startMinutes = 2;
    [SerializeField]
    private Text textCurrentTime;
    [SerializeField]
    private Text textInfoTimer;
    [SerializeField]
    private GameObject timerFin;

    private void Awake()
    {
        textInfoTimer.text = "T I M E  L I M I T";
    }

    void Start()
    {
        currentTime = startMinutes * 60;
        StartTimer();
    }

    void Update()
    {       
        if (timerActive == true)
        {
            currentTime -= 1 * Time.deltaTime;
            if (currentTime <= 0)
            {
                textInfoTimer.text = "T I M E  F I N I S H E D";
                StopTimer();
                timerFin.SetActive(true);
            }
        }
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        textCurrentTime.text = time.Minutes.ToString("00") + ":" + time.Seconds.ToString("00");

        if (time.Minutes == 0)
        {
            textCurrentTime.color = Color.red;
            textInfoTimer.color = Color.red;            
        }
    }

    private void StartTimer()
    {
        timerActive = true;
    }

    public static void StopTimer()    
    {   
        timerActive = false;
        PlayerHealth.loadNextScene = true;
    }
}
