using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float growth = 0.005f;
    float growthWithTime = 0;
    Material mat;

    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<Material>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.localScale.x <= 45.0)
        {
           Vector3 trans = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
           trans.x += growth ;
           trans.y += growth ;
           transform.localScale = trans;
           
		}
        else if(transform.localScale.x >= 45.0)
        {
            growthWithTime += growth;
            mat.SetFloat("_Value", growthWithTime);  
		}

        if(mat.GetFloat("_Value") >= 1.0  )
        {
            Destroy(gameObject);  
		}

    }
}
