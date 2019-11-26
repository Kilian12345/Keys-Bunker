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

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftAlt))
        {
            Vector3 dir = Quaternion.AngleAxis(transform.eulerAngles.z + 90, Vector3.forward) * Vector3.right;
            rb.AddForce(dir * thrust);
        }

        /*if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.forward * steer);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(-Vector3.forward * steer);
        }*/

        transform.Rotate(Vector3.forward * -steer * (Input.GetAxis("Horizontal")));

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject explosive = Instantiate(particles, transform.position, Quaternion.identity);
            Destroy(explosive, 2f);
            rb.velocity = Vector3.zero;
        }
    }
}
