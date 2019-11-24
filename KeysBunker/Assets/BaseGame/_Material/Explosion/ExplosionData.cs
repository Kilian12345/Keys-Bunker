using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionData : MonoBehaviour
{
    [Range(-0.1f,1)] public float Cutoff;
    public Color Color = Color.white;

    private Renderer _renderer;
    private MaterialPropertyBlock _propBlock;

    public float timeGlitch;
    public bool IsExplosion;

    void Awake()
    {
        _propBlock = new MaterialPropertyBlock();
        _renderer = GetComponent<Renderer>();
    }

    void Update()
    {
        // Get the current value of the material properties in the renderer.
        _renderer.GetPropertyBlock(_propBlock);
        // Assign our new value.
        _propBlock.SetFloat("_Cutoff", Cutoff);
        _propBlock.SetColor("_Color", Color);
        // Apply the edited values to the renderer.
        _renderer.SetPropertyBlock(_propBlock);

        if(IsExplosion == true)
        {
            Cutoff = 1;
        }

        if(Cutoff > -0.1f)
        {
            Cutoff -= timeGlitch;
            IsExplosion = false;
        }


    }


    
}
