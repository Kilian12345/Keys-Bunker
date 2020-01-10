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
    [SerializeField] GameObject controlPoint;
    [SerializeField] GameObject missilePrefab;
    [SerializeField] Vector3[] splinePositions;
    [SerializeField] List<GameObject> controlPoints = new List<GameObject>();
    [ShowInInspector] Queue<GameObject> nodeQueue = new Queue<GameObject>();
    GameObject CommanderScreen;
    [SerializeField] RectTransform screenSize;

    void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.useWorldSpace = true;
        lineRenderer.material = new Material(Shader.Find("Legacy Shaders/Particles/Additive"));

        splinePositions = new Vector3[lineRenderer.positionCount];
        lineRenderer.GetPositions(splinePositions);

        //CommanderScreen = GameObject.FindGameObjectWithTag("Respawn");

        missilePrefab = Instantiate(missilePrefab, new Vector2(UnityEngine.Random.Range(-Camera.main.pixelWidth, Camera.main.pixelWidth), 
                                                               UnityEngine.Random.Range(-Camera.main.pixelHeight, Camera.main.pixelHeight)), Quaternion.identity);

        for (int i = 0; i < lineRenderer.positionCount; i++)
        {
            GameObject node = Instantiate(controlPoint, lineRenderer.GetPosition(i), Quaternion.identity);
            nodeQueue.Enqueue(node);
            node.transform.parent = gameObject.transform;
        }

        missilePrefab.gameObject.SendMessage("ReceiveNodeQueue", nodeQueue);
    }


    void Update()
    {
        GenerateSpline();

        CheckMissileStatus();
    }

    private void CheckMissileStatus()
    {
        if(missilePrefab == null)
        {
            Destroy(gameObject);
        }
    }

    void GenerateSpline()
    {
        if (null == lineRenderer || controlPoints == null || controlPoints.Count < 3)
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
        lineRenderer.positionCount = numberOfPoints * (controlPoints.Count - 2);

        Vector3 p0, p1, p2;
        for (int j = 0; j < controlPoints.Count - 2; j++)
        {
            // check control points
            if (controlPoints[j] == null || controlPoints[j + 1] == null
            || controlPoints[j + 2] == null)
            {
                return;
            }
            // determine control points of segment
            p0 = 0.5f * (controlPoints[j].transform.position
            + controlPoints[j + 1].transform.position);
            p1 = controlPoints[j + 1].transform.position;
            p2 = 0.5f * (controlPoints[j + 1].transform.position
            + controlPoints[j + 2].transform.position);

            // set points of quadratic Bezier curve
            Vector3 position;
            float t;
            float pointStep = 1.0f / numberOfPoints;
            if (j == controlPoints.Count - 3)
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
}