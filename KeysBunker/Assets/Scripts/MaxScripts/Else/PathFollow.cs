using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollow : MonoBehaviour
{
    private Transform[] nodes;
    public Transform missile;
    private Vector3 targetedPosition;
    private Vector3 startPosition;
    public float movingSpeed;
    private int currentNode;
    private float timer;

    void Start()
    {
        nodes = GetComponentsInChildren<Transform>();

        Check();
    }

    void Update()
    {
        if (missile != null) Follow();

        else Destroy(transform.parent.gameObject);
    }

    void Follow()
    {
        timer += Time.deltaTime * movingSpeed;

        if (missile.transform.position != targetedPosition)
        {
            missile.transform.position = Vector3.Lerp(startPosition, targetedPosition, timer);
        }

        else
        {
            if (currentNode < nodes.Length - 1)
            {
                currentNode++;
                Check();
            }
        }
    }

    void Check()
    {
        timer = 0;
        targetedPosition = nodes[currentNode].transform.position;
        startPosition = missile.transform.position;
    }
}
