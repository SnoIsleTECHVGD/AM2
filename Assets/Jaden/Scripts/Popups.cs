using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Popups : MonoBehaviour
{
    public bool isVisible1;
    public bool isVisible2;
    public bool isVisible3;
    public bool isVisible4;
    public bool isVisible5;
    public GameObject Popup1;
    public GameObject Popup2;
    public GameObject Popup3;
    public GameObject Popup4;
    public GameObject Popup5;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(isVisible1 == true)
        {
            Popup1.SetActive(true);
            
        }
        else
        {
            Popup1.SetActive(false);
            
        }
        if (isVisible2 == true)
        {
            Popup2.SetActive(true);

        }
        else
        {
            Popup2.SetActive(false);

        }
        if (isVisible3 == true)
        {
            Popup3.SetActive(true);

        }
        else
        {
            Popup3.SetActive(false);

        }
        if (isVisible4 == true)
        {
            Popup4.SetActive(true);

        }
        else
        {
            Popup4.SetActive(false);

        }
        if (isVisible5 == true)
        {
            Popup5.SetActive(true);

        }
        else
        {
            Popup5.SetActive(false);

        }
         
    }
}
