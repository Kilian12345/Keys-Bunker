using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using System;

//[ExecuteInEditMode, RequireComponent(typeof(LineRenderer))]
public class Bezier_Spline : MonoBehaviour
{
    /* THIS CLASS GENERATES A PROCEDURAL BEZIER SPLINE, SPAWNS A NEW MISSILE AT
     * A BASE POSITION AND SENDS IT A QUEUE OF WAYPOINTS TO MOVE TOWARDS
     */

    [SerializeField] Color color = Color.white;
    [SerializeField] float width = 0.2f;
    [SerializeField] int numberOfPoints = 20;
    LineRenderer lineRenderer;

    [SerializeField] int pathComplexityMin;
    [SerializeField] int pathComplexityMax;

    [SerializeField] GameObject controlPointAnchor;
    [SerializeField] GameObject controlPointVisual;
    [SerializeField] GameObject playerBase;
    [SerializeField] GameObject ufoPrefab;
    [SerializeField] Vector3[] splinePositions;
    [SerializeField] Vector3 startingPosition;

    [SerializeField] List<GameObject> controlPointsList = new List<GameObject>();
    [ShowInInspector] Queue<GameObject> nodeQueue = new Queue<GameObject>();
    
    float minimumNodeAmount;

    void Awake()
    {

        controlPointsList.Clear();
        nodeQueue.Clear();

        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.useWorldSpace = true;
        lineRenderer.material = new Material(Shader.Find("Legacy Shaders/Particles/Additive"));

        splinePositions = new Vector3[lineRenderer.positionCount];
        lineRenderer.GetPositions(splinePositions);

        MissileSpawn();
        SpawnNodes();
        GenerateSpline();
        GeneratePathQueue();
        minimumNodeAmount = nodeQueue.Count - (nodeQueue.Count-2);
    }

    void Update()
    {
        GenerateSpline();
        CheckMissileStatus();
    }

    private void MissileSpawn()
    {
        /*ufoPrefab.gameObject.tag = gameObject.tag;
        Debug.Log(gameObject.tag);
        ufoPrefab.gameObject.name = gameObject.tag;*/

        Vector2 determinator = new Vector2(UnityEngine.Random.Range(0, 2), UnityEngine.Random.Range(0, 2));
        int coinFlip = UnityEngine.Random.Range(0, 2);

        if (determinator == new Vector2(0, 0))
        {
            if (coinFlip == 0) { startingPosition = new Vector2(UnityEngine.Random.Range(-32, 0), -22); }
            else { startingPosition = new Vector2(-32, UnityEngine.Random.Range(-22, 0)); }
        }

        else if (determinator == new Vector2(0, 1))
        {
            if (coinFlip == 0) { startingPosition = new Vector2(UnityEngine.Random.Range(-32, 0), 22); }
            else { startingPosition = new Vector2(-32, UnityEngine.Random.Range(0, 22)); }
        }

        else if (determinator == new Vector2(1, 1))
        {
            if (coinFlip == 0) { startingPosition = new Vector2(UnityEngine.Random.Range(32, 0), 22); }
            else { startingPosition = new Vector2(32, UnityEngine.Random.Range(0, 22)); }
        }

        else if (determinator == new Vector2(1, 0))
        {
            if (coinFlip == 0) { startingPosition = new Vector2(UnityEngine.Random.Range(0, 32), -22);}
            else { startingPosition = new Vector2(32, UnityEngine.Random.Range(-22, 0)); }
        }

        ufoPrefab = Instantiate(ufoPrefab, startingPosition, Quaternion.identity);
    }

    private void SpawnNodes()
    {
        //set start controlPoint values
        GameObject startPoint = Instantiate(controlPointAnchor, gameObject.transform);
        startPoint.name = "Start_ControlPoint";
        startPoint.transform.position = startingPosition;

        controlPointsList.Add(startPoint);
        controlPointsList.Add(startPoint);

        for (int i = 0; i < UnityEngine.Random.Range(pathComplexityMin, pathComplexityMax); i++)
        {
            GameObject pathPoint = Instantiate(controlPointAnchor, gameObject.transform);
            pathPoint.name = "Path_ControlPoint";
            controlPointsList.Add(pathPoint);
            controlPointAnchor.transform.position = new Vector2(UnityEngine.Random.Range(-32, 32), UnityEngine.Random.Range(-22, 22));
        }

        //set end controlPoint values
        GameObject endPoint = Instantiate(controlPointAnchor, gameObject.transform);
        endPoint.name = "End_ControlPoint";
        endPoint.transform.position = playerBase.transform.position;
        controlPointsList.Add(endPoint);
        controlPointsList.Add(endPoint);
    }

    private void GeneratePathQueue()
    {
        for (int i = 0; i < lineRenderer.positionCount; i++)
        {
            GameObject node = Instantiate(controlPointVisual, lineRenderer.GetPosition(i), Quaternion.identity);
            nodeQueue.Enqueue(node);
            node.transform.parent = gameObject.transform;
        }

        ufoPrefab.gameObject.SendMessage("ReceiveNodeQueue", nodeQueue);
    }

    void GenerateSpline()
    {
        if (null == lineRenderer || controlPointsList == null || controlPointsList.Count < 3)
        {
            return; // not enough points specified
        }
        // update line renderer
        lineRenderer.startColor = color;
        lineRenderer.endColor = color;
        lineRenderer.startWidth = width;
        lineRenderer.endWidth = width;

        if (numberOfPoints < 2)
        {
            numberOfPoints = 2;
        }
        lineRenderer.positionCount = numberOfPoints * (controlPointsList.Count - 2);

        Vector3 p0, p1, p2;
        for (int j = 0; j < controlPointsList.Count - 2; j++)
        {
            // check control points
            if (controlPointsList[j] == null || controlPointsList[j + 1] == null
            || controlPointsList[j + 2] == null)
            {
                return;
            }
            // determine control points of segment
            p0 = 0.5f * (controlPointsList[j].transform.position
            + controlPointsList[j + 1].transform.position);
            p1 = controlPointsList[j + 1].transform.position;
            p2 = 0.5f * (controlPointsList[j + 1].transform.position
            + controlPointsList[j + 2].transform.position);

            // set points of quadratic Bezier curve
            Vector3 position;
            float t;
            float pointStep = 1.0f / numberOfPoints;
            if (j == controlPointsList.Count - 3)
            {
                pointStep = 1.0f / (numberOfPoints - 1.0f);
                // last point of last segment should reach p2
            }
            for (int i = 0; i < numberOfPoints; i++)
            {
                t = i * pointStep;
                position = (1.0f - t) * (1.0f - t) * p0
                + 2.0f * (1.0f - t) * t * p1 + t * t * p2;
                lineRenderer.SetPosition(i + j * numberOfPoints, position);
            }
        }
    }

    private void CheckMissileStatus()
    {
        if (ufoPrefab == null)
        {
            Destroy(gameObject);
        }

        if (nodeQueue.Count < minimumNodeAmount)
        {
            Debug.Log("Sent Message");
            ufoPrefab.gameObject.SendMessage("Integrity");
        }
    }
}