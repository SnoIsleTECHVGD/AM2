using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Stats : MonoBehaviour
{
    public int health;
    public HealthBar healthBar;
    public GameObject grave;
    public void TakeDamage(int damage)
    {
        if (gameObject.name == "Player")
        {
            Movement movementScript = GetComponent<Movement>();
            if (movementScript.dashing == false)
                health -= damage;
                healthBar.SetHealth(health);
        } else 
        health -= damage;
        if(health <= 0)
        {
            if (gameObject.CompareTag("Player"))
            {
                SceneManager.LoadScene("LoseScreen");
            } 
            else if(gameObject.name == "Sheriff")
            {
                SceneManager.LoadScene("WinScreen");
            }
            else
            {
                Instantiate(grave, transform.position + new Vector3(0,1,0), Quaternion.Euler(0, 0, 0));
                Destroy(gameObject);
            }
        }
    }
}
