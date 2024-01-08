using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Stats : MonoBehaviour
{
    public int health;
    public int attack;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void TakeDamage(int damage)
    {
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
