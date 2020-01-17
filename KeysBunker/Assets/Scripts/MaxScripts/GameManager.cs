using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    bool destroy;

    public int baseHealth;
    private int health;

    int score = 0;

    public GameObject scoreUI;
    public GameObject healthUI;

    public GameObject menuUI;

    public bool gameOver { get; private set; } = false;

    void Start()
    {
        health = baseHealth;
    }

    void Update()
    { 
        healthUI.GetComponent<Text>().text = (health).ToString() + " : Health";
        scoreUI.GetComponent<Text>().text = "Score : " + (score).ToString();

        print("score :" + score);

        if (health <= 0)
        {
            gameOver = true;
            menuUI.SetActive(true);
        }

        if (score <= -500)
        {
            gameOver = true;
            menuUI.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Space) && gameOver)
        {
            Restart();
        }
    }

    void Hit()
    {
        health--;
    }

    public void Score(int value)
    {
        score += value;
    }

    void MessageReceiver()
    {
        print("I good");
        destroy = true;
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (!col.GetComponent<SplineMissile>().hasHit && destroy)
        {
            Hit();
            Debug.Log("hit !" + health);
            col.GetComponent<SplineMissile>().hasHit = true;
            destroy = false;
        }
    }

    public void Restart()
    {
        gameOver = false;
        menuUI.SetActive(false);

        string currentScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentScene);
    }
}
