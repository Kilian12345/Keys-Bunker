using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class TestArduino : MonoBehaviour
{
    public float speed;
    private float movingSpeed;

    SerialPort sp = new SerialPort("COM3", 9600); // put the correct Port name (indicated at bottom right of the arduino editor window)

    private int input = 0;

    private int currentInput = 0;

    public float timer;
    private float time;

    void Start()
    {
        sp.Open();
        sp.ReadTimeout = 1;
    } 

    void Update()
    {
        movingSpeed = speed * Time.deltaTime;

        if (sp.IsOpen)
        {
            try
            {
                int value = sp.ReadByte();

                print(value);
                InputCheck(value);

                MoveObject(input);
            }
            catch (System.Exception)
            {
                throw;
            }
        } 
    }

    void InputCheck(int inp)
    {
        if (inp > 0)
        {
            if (inp != currentInput)
            {
                time = 0f;
                input = inp;

                currentInput = inp;
            } 
        }
        else if (inp == 0)
        { 
            currentInput = inp;

            if (time >= timer)
            {
                time = 0f;
                input = inp;
            }
            else
            {
                time += Time.deltaTime;
            }
        } 
    }

    void MoveObject(int dir)
    {
        if (dir == 1) transform.Translate(Vector2.right * movingSpeed, Space.World);

        else if (dir == 2) transform.Translate(Vector2.left * movingSpeed, Space.World);

        if (dir == 3) transform.Translate(Vector2.up * movingSpeed, Space.World);

        else if (dir == 4) transform.Translate(Vector2.down * movingSpeed, Space.World);
    }

    //{ Vector2 currentPos = transform.position; transform.position = Vector2.Lerp(currentPos, currentPos + new Vector2(amountToMove, 0), Time.deltaTime); }
}
