using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SceneryStock
{
    public List<GameObject> missiles;
    public List<GameObject> paths;
}

public class TrailerMissilesScenery : MonoBehaviour
{
    public List<SceneryStock> sceneryStocks;

    public List<GameObject> mohawks;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            LaunchMissile(0);
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            LaunchMissile(1);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            LaunchMissile(2);
        }

        /// \\\

        if (Input.GetButtonDown("Fire1"))
        {
            CounterMeasure(0);
        }

        if (Input.GetButtonDown("Fire2"))
        {
            CounterMeasure(1);
        }
    }

    void LaunchMissile(int currentScenery)
    {
        foreach (GameObject path in sceneryStocks[currentScenery].paths)
        {
            GameObject currentPath = Instantiate(path, gameObject.transform.position, Quaternion.identity);

            GameObject currentMissile = Instantiate(
                sceneryStocks[currentScenery].missiles[UnityEngine.Random.Range(0, sceneryStocks[currentScenery].missiles.Count)],
                currentPath.GetComponentInChildren<PathFollow>().transform.position,
                Quaternion.identity
                );

            currentPath.GetComponentInChildren<PathFollow>().missile = currentMissile.transform;
        }
    }

    void CounterMeasure(int index)
    {
        GameObject currentMohawk = Instantiate(
            mohawks[index],
            gameObject.transform.position,
            Quaternion.identity
            );
    }

    //Quaternion.LookRotation(mohawks[index].GetComponent<CounterMeasureMovement>().destination.position - mohawks[index].transform.position)
}
