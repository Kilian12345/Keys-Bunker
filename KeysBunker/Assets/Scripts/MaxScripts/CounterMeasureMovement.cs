using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterMeasureMovement : MonoBehaviour
{
    public float speed;
    private float timer;

    public Transform destination;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;

        //destination = GameObject.Find("Destination").GetComponent<Transform>();
    }

    void Update()
    {
        float time = Time.deltaTime * speed;
        timer += time;

        transform.position = Vector3.Lerp(startPosition, destination.position, timer);

        /// Là c'est le zbeul pour rotate

        Vector3 targetDir = destination.position - transform.position;

        //Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, time, 0.0f);
        transform.rotation = Quaternion.LookRotation(targetDir, Vector3.up) * Quaternion.Euler(30, 90, 0);

        //transform.LookAt(destination,Vector3.forward);

        /*
        Vector3 targetPos = new Vector3(destination.position.x, destination.position.y, transform.position.z);

        transform.LookAt(targetPos);
        */
    }
}
