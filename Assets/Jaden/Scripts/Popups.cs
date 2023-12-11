using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Popups : MonoBehaviour
{
    public bool help;
    public GameObject helpMe;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(help == true)
        {
            helpMe.SetActive(true);
        } else
        {
            helpMe.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            help = !help;
        }
    }
}
