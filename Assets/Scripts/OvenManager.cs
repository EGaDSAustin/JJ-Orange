using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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

    // TODO: Make time cooked persistent across all scenes
    //  Just found out that this wouldn't work after implementing

    void Start()
    {
        //RunOven(60);
    }

    void Update()
    {
        
    }

    public void ToggleOpenState()
    {
        if (open.enabled) CloseOven();
        else OpenOven();
    }

    public void OpenOven()
    {
        if(open != null) {
            open.enabled = true;
        }
        if(closed != null) {
            closed.enabled = false;
        }
        curPizza = null;
    }

    public void CloseOven(Pizza nextPizza = null)
    {
        open.enabled = false;
        closed.enabled = true;
        if (nextPizza != null) { 
            curPizza = nextPizza;
            RunOven(60);
        }
    }

    public void RunOven(int time)
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
        if (curPizza != null) {
            curPizza.timeCooked++;
        }
        if (curPizza == null) curTime = 60;
        if (curTime < 0 && curPizza != null)
        {
            overcooked = true;
            curTime++;
        }
        TimeSpan ts = TimeSpan.FromSeconds(curTime);
        timerText.text = ts.ToString(@"m\:ss");
        if (!overcooked && curPizza != null) Invoke("Decrement", 1f);
    }
}
