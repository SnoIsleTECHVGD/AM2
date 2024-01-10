using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ImageFade : MonoBehaviour
{

    // the image you want to fade, assign in inspector
    public Image img;
    public Image img2;
    public Image img3;
    public Image img4;
    public Image img5;
    public Image img6;
    public int imgNum = 1;

    public void Start()
    {
        img2.color = new Color(1, 1, 1, 0);
        img3.color = new Color(1, 1, 1, 0);
        img4.color = new Color(1, 1, 1, 0);
        img5.color = new Color(1, 1, 1, 0);
        img6.color = new Color(1, 1, 1, 0);
    }
    public void OnButtonClick()
    {
        // fades the image out when you click
        StartCoroutine(FadeImageOut(true));
        imgNum += 1;
        Debug.Log(imgNum);
    }

    IEnumerator FadeImageOut(bool fadeAway)
    {
        // fade from opaque to transparent
        if (fadeAway)
        {
            if (imgNum == 1)
            {
                // loop over 1 second backwards
                for (float i = 1; i >= 0; i -= Time.deltaTime)
                {
                    // set color with i as alpha
                    img.color = new Color(1, 1, 1, i);
                    yield return null;
                }
                for (float i = 0; i <= 1; i += Time.deltaTime)
                {
                    // set color with i as alpha
                    img2.color = new Color(1, 1, 1, i);
                    yield return null;
                }
            }

            else if (imgNum == 2)
            {
                // loop over 1 second backwards
                for (float i = 1; i >= 0; i -= Time.deltaTime)
                {
                    // set color with i as alpha
                    img2.color = new Color(1, 1, 1, i);
                    yield return null;
                }
                for (float i = 0; i <= 1; i += Time.deltaTime)
                {
                    // set color with i as alpha
                    img3.color = new Color(1, 1, 1, i);
                    yield return null;
                }
            }

            else if (imgNum == 3)
            {
                // loop over 1 second backwards
                for (float i = 1; i >= 0; i -= Time.deltaTime)
                {
                    // set color with i as alpha
                    img3.color = new Color(1, 1, 1, i);
                    yield return null;
                }
                for (float i = 0; i <= 1; i += Time.deltaTime)
                {
                    // set color with i as alpha
                    img4.color = new Color(1, 1, 1, i);
                    yield return null;
                }
            }

            else if (imgNum == 4)
            {
                // loop over 1 second backwards
                for (float i = 1; i >= 0; i -= Time.deltaTime)
                {
                    // set color with i as alpha
                    img4.color = new Color(1, 1, 1, i);
                    yield return null;
                }
                for (float i = 0; i <= 1; i += Time.deltaTime)
                {
                    // set color with i as alpha
                    img5.color = new Color(1, 1, 1, i);
                    yield return null;
                }
            }

            else if (imgNum == 5)
            {
                // loop over 1 second backwards
                for (float i = 1; i >= 0; i -= Time.deltaTime)
                {
                    // set color with i as alpha
                    img5.color = new Color(1, 1, 1, i);
                    yield return null;
                }
                for (float i = 0; i <= 1; i += Time.deltaTime)
                {
                    // set color with i as alpha
                    img6.color = new Color(1, 1, 1, i);
                    yield return null;
                }
            }
        }
    }
}