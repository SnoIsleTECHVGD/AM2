using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dogeroll : MonoBehaviour
{
    private Rigidbody2D rb;
    public float dashSpeed;
    private float dashTime;
    public float startDashTime;
    private int direction;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dashTime = startDashTime;
    }

    private void Update()
    {
        if(direction == 0)
        {
            if(Input.GetKeyDown(KeyCode.A))
        }
    }
}
