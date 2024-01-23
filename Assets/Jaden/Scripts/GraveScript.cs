using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraveScript : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform")) 
        {
            GetComponent<Rigidbody2D>().isKinematic = true;
            Debug.Log("HALSJDKASJDKASJD");
        }
    }
}
