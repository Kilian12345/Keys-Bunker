using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class TestPotentiometerArduino : MonoBehaviour
{
    public GameObject missile;

    Rigidbody2D rb;

    public float ratio;

    private bool started;

    private float timer;
    private float currentTime;

    private int rpm;

    ///\

    public float steer;

    private int offset;

    SerialPort sp = new SerialPort("COM4", 9600); // put the correct Port name (indicated at bottom right of the arduino editor window)

    void Start()
    {
        //rb = missile.GetComponent<Rigidbody2D>();

        sp.Open();
        sp.ReadTimeout = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (missile == null)
        {
            missile = GameObject.FindGameObjectWithTag("Missile");
            rb = missile.GetComponent<Rigidbody2D>();
        }

        if (sp.IsOpen && missile != null)
        {
            try
            {
                int value = sp.ReadByte();

                print(value);

                //missile controls

                Thrust(value);

                Steer(value);
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }

    void Thrust(int val)
    {
        if (val == 1)
        {
            if (started)
            {
                currentTime = timer;

                rpm = Mathf.RoundToInt(currentTime * 60f);

                Vector3 dir = Quaternion.AngleAxis(transform.eulerAngles.z + 90, Vector3.forward) * Vector3.right;
                rb.AddForce(dir * (rpm / ratio));
            }

            timer = 0;
            started = true;
        }

        timer += timer * Time.deltaTime;
    }

    void Steer(int val)
    {
        if (val >= 22) return; //useless

        if (val <= 11)
        {
            //positif droite

            offset = 11 - (val - 1);
        }

        else if (val >= 12)
        {
            //négatif gauche

            offset = -((val + 1) - 12);
        }

        missile.transform.Rotate(Vector3.forward * steer * offset);
    }
}
