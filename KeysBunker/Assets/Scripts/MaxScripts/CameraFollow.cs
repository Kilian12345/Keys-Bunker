using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject targetedObject;
    public float offset;

    void Update()
    {
        gameObject.transform.position = new Vector3(targetedObject.transform.position.x, targetedObject.transform.position.y, offset);
    }
}
