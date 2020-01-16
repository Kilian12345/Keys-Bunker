using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBehavior : MonoBehaviour
{
    float timePassed;
    float cooldown = 1f;
    SpriteRenderer sR;
    Sprite sprite;
    static float t = 0.0f;
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
            //gameObject.tag = "Tile";
            sR.color = new Color(1f, 1f, 1f, Mathf.Lerp(0f, 255f, t)); //Mathf.SmoothStep(0f, 255f, 1f));
            t += 0.5f * Time.deltaTime;

            // .. and increase the t interpolater
            //timePassed = 0f;
        }
    }
}
