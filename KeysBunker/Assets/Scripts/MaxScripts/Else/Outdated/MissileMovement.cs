using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileMovement : MonoBehaviour
{
    public float steer;
    public float thrust;
    public GameObject particles;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Vector3 dir = Quaternion.AngleAxis(transform.eulerAngles.z + 90, Vector3.forward) * Vector3.right;
            rb.AddForce(dir * thrust);
        }

        transform.Rotate(Vector3.forward * -steer * (Input.GetAxis("Horizontal")));

        if (Input.GetKeyDown(KeyCode.T))
        {
            DestroyRespawn();
        }
        
        /*if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.forward * steer);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(-Vector3.forward * steer);
        }*/
    }

    void OnTriggerEnter2D()
    {
        DestroyRespawn();
    }

    void DestroyRespawn()
    {
        GameObject explosive = Instantiate(particles, transform.position, Quaternion.identity);
        Destroy(explosive, 2f);
        rb.velocity = Vector3.zero;

        Instantiate(gameObject, new Vector3(0, 0, 0), Quaternion.identity);
        Destroy(this.gameObject);
    }
}
