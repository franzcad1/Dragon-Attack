using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private bool win = false;
    public Text timetext;
    private float startTime;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;   
    }

    // Update is called once per frame
    void Update()
    {
        if (win)
            return;

        float t = Time.time - startTime;

        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f2");

        timetext.text =    seconds;
    }

    public void Finish()
    {
        win = true;
        timetext.color = Color.yellow;
    }
}
