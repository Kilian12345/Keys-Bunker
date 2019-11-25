using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterMissileSpawner : MonoBehaviour
{
    public GameObject counterMissilePrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CustomGridGenerator.fireMissile)
        { GameObject counterMissile = Instantiate(counterMissilePrefab, transform.position, Quaternion.identity); CustomGridGenerator.fireMissile = false; }
    }
}
