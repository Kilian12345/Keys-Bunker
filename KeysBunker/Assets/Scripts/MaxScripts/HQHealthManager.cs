using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HQHealthManager : MonoBehaviour
{
    public int baseHealth;
    private int health;

    void Start()
    {
        health = baseHealth;
    }

    void Update()
    { 
        if (health <= 0)
        {
            string currentScene = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentScene);
        }
    }

    void Hit()
    {
        health--;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.GetComponent<ExplosionUFO>().hasHit)
        {
            Hit();
            Debug.Log("hit !" + health);
            Debug.Log(col.transform.gameObject);
            col.GetComponent<ExplosionUFO>().hasHit = true;
        }
    }
}
