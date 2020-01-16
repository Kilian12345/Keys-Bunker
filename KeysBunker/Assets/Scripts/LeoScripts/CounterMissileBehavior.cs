using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class CounterMissileBehavior : MonoBehaviour
{
    public float speed;
    [SerializeField] Vector3 target;
    [SerializeField] CustomGridGenerator gridScript;

    // Start is called before the first frame update
    void Start()
    {
        gridScript = FindObjectOfType<CustomGridGenerator>();
        //target = gridScript.targetTilePosition;
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, step);
    }
}
