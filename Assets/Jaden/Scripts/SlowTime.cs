using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowTime : MonoBehaviour
{
    private bool time;
    public float currentTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
            time = !time;
        if (time)
        {
            if(Time.timeScale == 1)
            Time.timeScale = .5f;
        }
        else
            if(Time.timeScale == .5f)
            Time.timeScale = 1;
        currentTime = Time.timeScale;
    }
}
