using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileManager : MonoBehaviour
{
    /* THIS CLASS HANDLES THE INSTANTIATION OF BEZIER SPLINES
     */

    [SerializeField] GameObject bezierGenerator;
    List<string> ufoType = new List<string>();


    // Start is called before the first frame update
    void Awake()
    {
        ufoType.Add("Plane");
        ufoType.Add("Birbs");
        ufoType.Add("Missile");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bezier = Instantiate(bezierGenerator, transform.position, Quaternion.identity);
            int whichTag = UnityEngine.Random.Range(0, 3);
            bezier.gameObject.tag = ufoType[whichTag];
            bezier.gameObject.name = ufoType[whichTag] + " path";
            bezier.SetActive(true);
        }
    }
}
