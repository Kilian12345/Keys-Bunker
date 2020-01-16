using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBehavior : MonoBehaviour
{
    [Range(0, 1)] public float value;
    float timePassed;
    float cooldown = 1f;
    SpriteRenderer sR;
    Sprite sprite;
    // Start is called before the first frame update
    void Start()
    {
        sR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag == "TARGETED") Timer();
    }

    void Timer()
    {
        timePassed += Time.deltaTime;
        if(timePassed >= cooldown)
        {
            gameObject.tag = "Tile";
            sR.enabled = false;
            timePassed = 0f;
        }
    }
}
