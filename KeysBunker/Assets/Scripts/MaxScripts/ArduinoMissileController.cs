using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class ArduinoMissileController : MonoBehaviour
{
    public GameObject missile;
    public GameObject particles;

    public GameManager gameManager;

    Rigidbody2D rb;

    ///\
    [Header("Thrusting")]
    public float ratio;

    private bool started;
    private bool passed;

    private float timer;
    private float currentTime;

    private int rpm;

    public float thrust; //temporary value

    ///test\
    [Header("Testing")]
    public float powerAmount;
    private float power;
    public float timeReduce;

    private bool ok = true;

    ///\
    [Header("Steering")]
    public float steer;

    private int offset;

    SerialPort sp = new SerialPort("COM4", 9600); // put the correct Port name (indicated at bottom right of the arduino editor window)

    void Start()
    { 
        sp.Open();
        sp.ReadTimeout = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (missile == null)
        {
            missile = GameObject.FindGameObjectWithTag("Counter Measure");
            rb = missile.GetComponent<Rigidbody2D>();
        }

        if (sp.IsOpen && missile != null && !gameManager.gameOver)
        {
            try
            {
                int value = sp.ReadByte();

                print(value);

                //missile controls

                Thruster(value);

                Steer(value);

                if (Input.GetKeyDown(KeyCode.T))
                {
                    Respawn();
                }

                if (Input.GetKey(KeyCode.LeftShift))
                {
                    Vector3 dir = Quaternion.AngleAxis(missile.transform.eulerAngles.z + 90, Vector3.forward) * Vector3.right;
                    rb.AddForce(dir * thrust);
                }

                missile.transform.Rotate(Vector3.forward * (-steer * 2f) * (Input.GetAxis("Horizontal")));
            }
            catch (System.Exception)
            {
                throw;
            }
        } 
    }

    void Thruster(int val)
    {
        Vector3 dir = Quaternion.AngleAxis(missile.transform.eulerAngles.z + 90, Vector3.forward) * Vector3.right;
        rb.AddForce(dir * power);

        if (power > 0)
        {
            power -= Time.deltaTime * timeReduce;
            //Debug.Log(Time.deltaTime * timeReduce);
        }

        if (val == 1 && ok)
        {
            power += powerAmount;
            ok = false;
        }

        else if (val == 0)
        {
            ok = true;
        }
    }

    void Thrust(int val)
    {
        if (val == 1)
        {
            if (passed == false)
            {
                if (started)
                {
                    currentTime = timer;

                    rpm = Mathf.RoundToInt(currentTime * 60f);
                }

                timer = 0;
                started = true;
                passed = true;
            }

            Vector3 dir = Quaternion.AngleAxis(missile.transform.eulerAngles.z + 90, Vector3.forward) * Vector3.right;
            rb.AddForce(dir * (thrust + (rpm / ratio)));
        }

        else if (val == 0)
        {
            passed = false;
        }

        timer += timer * Time.deltaTime;
    }

    void Steer(int val)
    { 
        if (val < 11 && val >= 2)
        {
            //positif droite

            offset = 11 - (val - 1);
        }

        else if (val > 12)
        {
            //négatif gauche

            offset = -((val + 1) - 12);
        }

        else if (val == 11 || val == 12)
        {
            offset = 0;
        }

        missile.transform.Rotate(Vector3.forward * steer * (-offset));
    }

    public void Respawn()
    {
        GameObject explosion = Instantiate(particles, missile.transform.position, Quaternion.identity);
        Destroy(explosion, 2f);
        rb.velocity = Vector3.zero;

        Instantiate(missile, new Vector3(0, 0, 0), Quaternion.identity);
        Destroy(missile);
    }
}
