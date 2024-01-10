using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Stats : MonoBehaviour
{
    public int health;
    public int attack;
    // Update is called once per frame
    public void TakeDamage(int damage)
    {
        if (gameObject.name == "Player")
        {
            Movement movementScript = GetComponent<Movement>();
            if (movementScript.dashing == false)
                health -= damage;
        } else 
        health -= damage;
        if(health <= 0)
        {
            if (gameObject.CompareTag("Player"))
            {
                SceneManager.LoadScene("LoseScreen");
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
