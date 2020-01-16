using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMovement : MonoBehaviour
{
    public float speed;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(new Vector3(Input.GetAxis("Horizontal2") * speed, Input.GetAxis("Vertical2") * speed, 0));
    }
}
