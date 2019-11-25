using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLife : MonoBehaviour
{
    public int timeBeforeDestroy;
    float timeElapsed = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Timer();
    }

    void Timer()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed >= timeBeforeDestroy) Destroy(gameObject);
    }
}
