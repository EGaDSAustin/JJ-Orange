using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OvenManager : MonoBehaviour
{

    [SerializeField]
    private SpriteRenderer open;
    [SerializeField]
    private SpriteRenderer closed;
    [SerializeField]
    private TextMeshProUGUI timerText;

    private int curTime;
    private bool overcooked = false;

    private Pizza curPizza = null;

    // Start is called before the first frame update
    void Start()
    {
        //RunOven(60);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OpenOven()
    {
        open.enabled = true;
        closed.enabled = false;
    }

    void CloseOven()
    {
        open.enabled = false;
        closed.enabled = true;
    }

    void RunOven(int time)
    {
        curTime = time;
        overcooked = false;
        TimeSpan ts = TimeSpan.FromSeconds(curTime);
        timerText.text = ts.ToString(@"m\:ss");
        Invoke("Decrement", 1f);
    }

    void Decrement()
    {
        curTime--;
        if (curTime < 0)
        {
            overcooked = true;
            curTime++;
        }
        TimeSpan ts = TimeSpan.FromSeconds(curTime);
        timerText.text = ts.ToString(@"m\:ss");
        Invoke("Decrement", 1f);
    }
}
