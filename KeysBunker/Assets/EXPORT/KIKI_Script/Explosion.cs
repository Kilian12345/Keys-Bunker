using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float growth = 0.005f;
    float value;
    float growthWithTime = 0;
    public Material mat;

    public Material camMat; // CRT
    Camera cam;

    BlitCRT blit;

    bool doneOnce = false;
    bool doneOnce2 = false;

    // Start is called before the first frame update
    void Start()
    {
        //mat = GetComponent<Material>();
        blit = FindObjectOfType<BlitCRT>();
        //camMat = FindObjectOfType<Camera>().GetComponent<Material>();

        Vector3 trans = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
        trans.x = 0;
        trans.y = 0;
        trans.z = 0;
        transform.localScale = trans;

        growthWithTime = 0;
        value = 0;
        mat.SetFloat("_Value", value);
    }

    // Update is called once per frame
    void Update()
    {
        value = mat.GetFloat("_Value");

        if (doneOnce2 == false)
        { 
            blit.isActive = true;
            blit.pos = new Vector2(transform.localScale.x, transform.localScale.y);
            doneOnce2 = true; 
        }

        if (transform.localScale.x <= 45.0)
        {
           Vector3 trans = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
           trans.x += growth ;
           trans.y += growth ;
           transform.localScale = trans;
           
		}
        else if(transform.localScale.x >= 45.0)
        {
            growthWithTime += 0.05f;
            mat.SetFloat("_Value", growthWithTime);

            if (doneOnce == false)
            {
                StartCoroutine(Wait());
                doneOnce = true;
            }
		}


        IEnumerator Wait()
        {
            yield return new WaitForSeconds(1);
            Destroy(gameObject);
        }

    }
}
