using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class BlitCRT : MonoBehaviour
{
    [Header("CRT")]
    public Material CRTMaterial;
    public float smoothRefresh;
    public float smoothDistort;
    public float interval;
    private float refreshP;
    private float distortion;
    private float sD;

    [Space(30)]
    [Header("Ripple")]
    public float MaxAmount = 50f;

    [Range(0, 1)]
    public float Friction = .9f;
    public float Radius = 0f;

    private float Amount = 0f;


    void Start()
    {
        refreshP = 1080.0f;
        sD = smoothDistort;
        StartCoroutine(distort());
    }
    void OnRenderImage(RenderTexture src, RenderTexture dst)
    {
        CRTMaterial.SetFloat("_ScanPoint", refreshP);
        CRTMaterial.SetFloat("_Distort", distortion);


        if (CRTMaterial != null)
            Graphics.Blit(src, dst, CRTMaterial);

    }

    void FixedUpdate()
    {
        refreshP = Mathf.MoveTowards(refreshP, -200.0f, smoothRefresh);
        if (refreshP <= -200.0f)
        {
            refreshP = 2000.0f;
        }
    }

    void Update()
    {
        /*if (Input.GetMouseButton(0))
        {
            this.Amount = this.MaxAmount;
            Vector3 pos = Input.mousePosition;
            this.CRTMaterial.SetFloat("_CenterX", pos.x);
            this.CRTMaterial.SetFloat("_CenterY", pos.y);
        }*/

        this.CRTMaterial.SetFloat("_Radius", this.Radius);
        this.CRTMaterial.SetFloat("_Amount", this.Amount);
        this.Amount *= this.Friction;
    }

    IEnumerator distort()
    {
        float current = 0.0f;
        float target = normalRandom(-interval, interval);
        distortion = current;
        while (true)
        {
            current = Mathf.MoveTowards(current, target, sD * Time.deltaTime);
            distortion = current;
            if (current == target)
            {
                yield return new WaitForSeconds(Random.Range(0.0f, 0.1f));
                target = normalRandom(-interval, interval);
            }
            yield return null;
        }
    }

    float normalRandom(float min, float max)
    {
        sD = smoothDistort * Random.Range(0.2f, 1.0f);
        return Random.Range(min, max);
    }
}