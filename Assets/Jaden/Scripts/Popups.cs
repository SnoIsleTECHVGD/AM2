using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popups : MonoBehaviour
{
    private bool isClick;
    private RectTransform transf;
    private bool canMove = false;
    // Start is called before the first frame update
    void Start()
    {
        transf = gameObject.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isClick)
        {
            movePopup("l");
            canMove = true;
        }
        else
        {
            movePopup("r");
            canMove = true;
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            isClick = !isClick;
        }
    }
    
    void movePopup(string direction)
    {
        if(canMove)
        {
            if(direction == "l")
            {
                gameObject.transform.position = new Vector2(gameObject.transform.position.x - .01f, gameObject.transform.position.y);
                transf.anchorMin = new Vector2(transf.anchorMin.x - .01f, transf.anchorMin.y);
                transf.anchorMax = new Vector2(transf.anchorMax.x - .01f, transf.anchorMax.y);
            }
            if(direction == "r")
            {
                gameObject.transform.position = new Vector2(gameObject.transform.position.x + .01f, gameObject.transform.position.y);
                transf.anchorMin = new Vector2(transf.anchorMin.x + .01f, transf.anchorMin.y);
                transf.anchorMax = new Vector2(transf.anchorMax.x + .01f, transf.anchorMax.y);
            }
            if(transf.anchorMin.x > 1)
            {
                transf.anchorMin = new Vector2(1, transf.anchorMin.y);
                transf.anchorMax = new Vector2(1.33f, transf.anchorMax.y);
                transf.anchoredPosition = new Vector2(162.45f, transf.anchoredPosition.y);
                canMove = false;
            }
            if (transf.anchorMin.x < .67f)
            {
                transf.anchorMin = new Vector2(.67f, transf.anchorMin.y);
                transf.anchorMax = new Vector2(1, transf.anchorMax.y);
                transf.anchoredPosition = new Vector2(163.35f, transf.anchoredPosition.y);

                canMove = false;
            }
        }
        
    }
}
