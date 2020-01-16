using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CounterMissileSpawner : MonoBehaviour
{
    public GameObject counterMissilePrefab;

    public int baseHealth;
    private int health;

    void Start()
    {
        health = baseHealth;
    }

    void Update()
    {
        if (CustomGridGenerator.fireMissile)
        {
            GameObject counterMissile = Instantiate(counterMissilePrefab, transform.position, Quaternion.identity); CustomGridGenerator.fireMissile = false;
        }

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
        /*
        if (!col.GetComponent<ExplosionUFO>().hasHit)
        {
            Hit();
            Debug.Log("hit !" + health);
            Debug.Log(col.transform.gameObject);
            col.GetComponent<ExplosionUFO>().hasHit = true;
        }*/
    }
}
