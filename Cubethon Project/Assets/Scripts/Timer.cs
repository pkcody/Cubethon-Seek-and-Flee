using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public delegate void TimerStarted();
    public static event TimerStarted OnTimerStarted;

    public Text timerText;
    public Transform player;
    public float timerTime;
    public Material enemyMat;

    void Update()
    {
        OnTimerStarted();
    }

    void PlayStartUI()
    {
        if (player != null && timerText != null)
        {
            timerTime = Time.timeSinceLevelLoad;
            timerText.text = timerTime.ToString("0");

            MeshRenderer meshRenderer = GetComponent<MeshRenderer>();

            if (timerTime >= 0 && timerTime <= 2)
                enemyMat.color = Color.red;
            if (timerTime >= 2 && timerTime <= 4)
                enemyMat.color = Color.green;
            if (timerTime >= 4 && timerTime <= 5)
                enemyMat.color = Color.blue;
            if (timerTime >= 5 && timerTime <= 6)
                enemyMat.color = Color.black;
            if (timerTime >= 7 && timerTime <= 8)
                enemyMat.color = Color.cyan;
            if (timerTime >= 8 && timerTime <= 12)
                enemyMat.color = Color.magenta;
        }
    }

    void Start()
    {
        timerTime = Time.timeSinceLevelLoad;
        
        OnTimerStarted += PlayStartUI;
    }
}
