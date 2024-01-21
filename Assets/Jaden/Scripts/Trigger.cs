using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public GameObject player;
    public GameObject popupObject;
    public int popupNum;
    public GameObject text;
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
                yield return waitForKeyPress(KeyCode.E);
                text.GetComponent<Animator>().SetInteger("Snake", 2);
                yield return waitForKeyPress(KeyCode.E);
                text.GetComponent<Animator>().SetInteger("Snake", 3);
                yield return waitForKeyPress(KeyCode.E);
                text.GetComponent<Animator>().SetInteger("Snake", 4);
                yield return waitForKeyPress(KeyCode.E);
                stuff.isVisible2 = false;
            }
            else if (popupNum == 3)
            {
                stuff.isVisible3 = true;
                yield return waitForKeyPress(KeyCode.E);
                text.GetComponent<Animator>().SetInteger("MrKom", 2);
                yield return waitForKeyPress(KeyCode.E);
                text.GetComponent<Animator>().SetInteger("MrKom", 3);
                yield return waitForKeyPress(KeyCode.E);
                text.GetComponent<Animator>().SetInteger("MrKom", 4);
                yield return waitForKeyPress(KeyCode.E);
                text.GetComponent<Animator>().SetInteger("MrKom", 5);
                yield return waitForKeyPress(KeyCode.E);
                text.GetComponent<Animator>().SetInteger("MrKom", 6);
                yield return waitForKeyPress(KeyCode.E);
                stuff.isVisible3 = false;
            }
            else if (popupNum == 4)
            {
                stuff.isVisible4 = true;
                yield return waitForKeyPress(KeyCode.E);
                text.GetComponent<Animator>().SetInteger("Sheriff", 2);
                yield return waitForKeyPress(KeyCode.E);
                text.GetComponent<Animator>().SetInteger("Sheriff", 3);
                yield return waitForKeyPress(KeyCode.E);
                stuff.isVisible4 = false;
            }
            else if (popupNum == 5)
            {
                stuff.isVisible5 = true;
                yield return new WaitForSeconds(5);
                stuff.isVisible5 = false;
            }
            Destroy(gameObject);
        }
    }

    private IEnumerator waitForKeyPress(KeyCode key)
    {
        bool done = false;
        while (!done) // essentially a "while true", but with a bool to break out naturally
        {
            if (Input.GetKeyDown(key))
            {
                done = true; // breaks the loop
            }
            yield return null; // wait until next frame, then continue execution from here (loop continues)
        }

        // now this function returns
    }
}
