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

    public float ratio;

    private bool started;

    private float timer;
    private float currentTime;

    private int rpm;

    public float thrust; //temporary value

    ///\

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

                Thrust(value);

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

    void OnTriggerEnter2D()
    {
        // Collision check

        // Score call
        gameManager.Score(100);

        Respawn();
    }

    public void Respawn()
    {
        GameObject explosion = Instantiate(particles, transform.position, Quaternion.identity);
        Destroy(explosion, 2f);
        rb.velocity = Vector3.zero;

        Instantiate(missile, new Vector3(0, 0, 0), Quaternion.identity);
        Destroy(missile);
    }
}
