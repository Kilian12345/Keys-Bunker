using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailerMissilesSpawner : MonoBehaviour
{
    public List<GameObject> missiles;
    public List<GameObject> paths;

    private List<int> index =  new List<int>();

    private int currentIndex = 0;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (index != null)
            {
                foreach (int ind in index)
                {
                    if (ind == currentIndex)
                    {
                        if (ind >= 3) return;
                        else currentIndex++;
                    }
                }
            }

            GameObject currentPath = Instantiate(paths[currentIndex], gameObject.transform.position, Quaternion.identity);

            GameObject currentMissile = Instantiate(missiles[Random.Range(0, missiles.Count)], currentPath.GetComponentInChildren<PathFollow>().transform.position, Quaternion.identity);

            currentPath.GetComponentInChildren<PathFollow>().missile = currentMissile.transform;

            index.Add(currentIndex);
        }
    }
}