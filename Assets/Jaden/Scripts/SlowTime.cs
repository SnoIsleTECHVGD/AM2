using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowTime : MonoBehaviour
{
    private bool time;
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
            Time.timeScale = .5f;
        else
            Time.timeScale = 1;
    }
}
