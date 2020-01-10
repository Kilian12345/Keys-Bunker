using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using System;

public class SplineMissile : MonoBehaviour
{
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
    void Start()
    {
        Vector2 RandomSelectedCoords = new Vector2(UnityEngine.Random.Range(UnityEngine.Random.Range(prevMaxInterval.x, nextMaxInterval.x), 
                                                                            UnityEngine.Random.Range(prevMaxInterval.y, nextMaxInterval.y)), 
                                                    UnityEngine.Random.Range(UnityEngine.Random.Range(prevMinInterval.x, nextMinInterval.x), 
                                                                             UnityEngine.Random.Range(prevMinInterval.y, nextMinInterval.y)));

        Debug.Log(RandomSelectedCoords);
        
        Vector2 determinator = new Vector2(UnityEngine.Random.Range(0, 1), UnityEngine.Random.Range(0, 1));

        if(determinator == new Vector2 (0, 0))
        {

        }
        else if(determinator == new Vector2(0, 1))
        {

        }

        else if(determinator == new Vector2(1, 0))
        {

        }
        else if (determinator == new Vector2(1, 1))
        {

        }
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
        Debug.Log("Message Received");
        startPosition = transform.position;
        targetPosition = receivedNodeQueue.Peek().transform.position;
    }
}
