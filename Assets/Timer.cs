using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class Timer : MonoBehaviour
{
    public float TimerValue = 60;
    public TMP_Text Timer_txt;
    public TouchManager tm;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TimerValue -= Time.deltaTime;
        Timer_txt.text=TimerValue.ToString("00");

        if(TimerValue <= 0)
        {
            Time.timeScale = 0;
            tm.audio.clip = tm.GameoverClip;
            tm.audio.Play();
            tm.Gameover.SetActive(true);
            tm.CalculateHighScore(tm.Score);
        }
    
    }
}
