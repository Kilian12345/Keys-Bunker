using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class TestArduinoV2 : MonoBehaviour
{
    public static bool targeted;

    public float speed;
    private float movingSpeed;

    SerialPort sp = new SerialPort("COM3", 9600); // put the correct Port name (indicated at bottom right of the arduino editor window)

    private int wheel1CurNum = 0;
    private int wheel2CurNum = 0;

    private Vector2 direction;
    private Rigidbody2D rb;
    public float rbSpeed;

    public float timer;
    private float time = 0f;

    public GameManager gameManager;

    void Start()
    {
        sp.Open();
        sp.ReadTimeout = 1;

        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movingSpeed = speed * Time.deltaTime;

        if (sp.IsOpen && !gameManager.gameOver)
        {
            try
            {
                int num = sp.ReadByte();
                print(num);

                numCheck(num);

                Movement();
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }

    void numCheck(int n)
    {
        if (n == 6)
        {
            targeted = true;
        }

        // Wheel 1 Input

        if (n == 1 || n == 2)
        {
            if (n != wheel1CurNum)
            {
                SetDir(n);
                wheel1CurNum = n;
                time = 0f;
            }
        }

        else if (n == 0)
        {
            wheel1CurNum = 0;
        }

        // Wheel 2 Input

        if (n == 3 || n == 4)
        {
            if (n != wheel2CurNum)
            {
                SetDir(n);
                wheel2CurNum = n;
                time = 0f;
            }
        }

        else if (n == 5)
        {
            wheel2CurNum = 0;
        } 
    }

    void Movement()
    {
        //transform.Translate(direction * movingSpeed, Space.World);
        rb.AddForce(direction * rbSpeed);

        if (time >= timer)
        {
            time = 0f;
            direction = new Vector2(0, 0);
        }

        else
        {
            time += Time.deltaTime;
        }
    }

    void SetDir(int dir)
    {
        if (dir == 1) direction.x = 1;

        if (dir == 2) direction.x = -1;

        if (dir == 3) direction.y = 1;

        if (dir == 4) direction.y = -1;
    }
}
