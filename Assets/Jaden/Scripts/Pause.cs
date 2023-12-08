using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject pauseText;
    public GameObject button1;
    public GameObject button2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            pauseText.SetActive(true);
            button1.SetActive(true);
            button2.SetActive(true);
        }
    }
    public void unPause()
    {
        Time.timeScale = 1;
        pauseText.SetActive(false);
        button1.SetActive(false);
        button2.SetActive(false);
    }
}
