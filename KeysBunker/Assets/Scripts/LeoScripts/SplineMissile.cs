using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using System;

public class SplineMissile : MonoBehaviour
{
    /* THIS CLASS IS INSTANTIATED BY THE BEZIER SPLINE CLASS. IT FOLLOWS
     * A SET OF WAYPOINTS AND IS DESTROYED ON COLLISION? ALONG WITH THE SPLINE
     */

    //TWEEN VALUES
    [SerializeField] float time;
    [SerializeField] Vector3 change;
    [SerializeField] Vector3 startPosition;
    [SerializeField] Vector3 targetPosition;
    [SerializeField] float duration;

    [ShowInInspector] Queue<GameObject> receivedNodeQueue;

    public float xCoord;
    public float yCoord;
    public float xFrequency;
    public float yFrequency;

    Vector2 prevMaxInterval = new Vector2(2,1);
    Vector2 prevMinInterval = new Vector2(-2,-1);

    Vector2 nextMaxInterval = new Vector2(1.75f, .5f);
    Vector2 nextMinInterval = new Vector2(-1.75f, -.5f);
    
    // Start is called before the first frame update
    void Awake()
    {

    }

    void Update()
    {
        MissileMovement();
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(Mathf.PerlinNoise(xCoord * xFrequency * Time.time, yCoord * yFrequency * Time.deltaTime));
        }
    }

    private void MissileMovement()
    {
        change = targetPosition - startPosition;

        if (time <= duration)
        {
            time += Time.deltaTime;
            transform.position = new Vector2(TweenManager.LinearTween(time, startPosition.x, change.x, duration), TweenManager.LinearTween(time, startPosition.y, change.y, duration));
        }

        if (time >= duration)
        {
            receivedNodeQueue.Dequeue();
            targetPosition = receivedNodeQueue.Peek().transform.position;
            startPosition = transform.position;
            time = 0f;
        }
    }

    void ReceiveNodeQueue(Queue<GameObject> queue)
    {
        receivedNodeQueue = queue;
        startPosition = receivedNodeQueue.Peek().transform.position;
        targetPosition = receivedNodeQueue.Peek().transform.position;
    }
}
