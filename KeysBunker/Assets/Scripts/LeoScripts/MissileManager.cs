using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileManager : MonoBehaviour
{
    /* THIS CLASS HANDLES THE INSTANTIATION OF BEZIER SPLINES
     */

    [SerializeField] GameObject bezierGenerator;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bezier = Instantiate(bezierGenerator, transform.position, Quaternion.identity);
            bezier.SetActive(true);
        }
    }
}
