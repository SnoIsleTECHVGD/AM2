using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public GameObject player;
    public GameObject popupObject;
    public int popupNum;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {

            Popups stuff = popupObject.GetComponent<Popups>();
            if (popupNum == 1)
            {
                stuff.isVisible1 = true;
                yield return new WaitForSeconds(5);
                stuff.isVisible1 = false;
            }
            else if (popupNum == 2)
            {
                stuff.isVisible2 = true;
                yield return new WaitForSeconds(5);
                stuff.isVisible1 = false;
            }
            else if (popupNum == 3)
            {
                stuff.isVisible3 = true;
                yield return new WaitForSeconds(5);
                stuff.isVisible1 = false;
            }
            else if (popupNum == 4)
            {
                stuff.isVisible4 = true;
                yield return new WaitForSeconds(5);
                stuff.isVisible1 = false;
            }
            else if (popupNum == 5)
            {
                stuff.isVisible5 = true;
                yield return new WaitForSeconds(5);
                stuff.isVisible1 = false;
            }
            Destroy(gameObject);
        }
    } 
}
