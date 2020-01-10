using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionUFO : MonoBehaviour
{
    SpriteRenderer mat;
    public bool IsExploding = false;

    [HideInInspector] public bool hasHit = false;

    private void Start()
    {
        mat = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (IsExploding)
        {
            float value = mat.material.GetFloat("_Cutoff");
            mat.material.SetFloat("_Cutoff", value - 0.1f);

            if (value <= 0)
            {
                IsExploding = false;
                //mat.material.SetFloat("_Cutoff", 1);
                Destroy(gameObject);
            }
        }
    }

    void OnTriggerEnter2D()
    {
        IsExploding = true;
    }
}
