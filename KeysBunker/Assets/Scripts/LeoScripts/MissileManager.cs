using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileManager : MonoBehaviour
{
    /* THIS CLASS HANDLES THE INSTANTIATION OF BEZIER SPLINES
     */

    [SerializeField] GameObject bezierCurve;

    //Missile Variables
    [SerializeField] int maxNumberOfUFOS;
    [SerializeField] int currTotalUFOS;
    [SerializeField] int numberOfMissiles;
    [SerializeField] int numberOfOthers;
    [SerializeField][Range(0, 100)] float baseProportionOfMissiles;
    [SerializeField][Range(0, 100)] float baseProportionOfOthers;

    [SerializeField] List<string> ufoType = new List<string>();
    
    //Spawn Variables
    [SerializeField] float timeToSpawn;
    [SerializeField] float timePassed;

    // Start is called before the first frame update
    void Awake()
    {
        ufoType.Add("Plane");
        ufoType.Add("Birbs");
        ufoType.Add("Missile");
        SpawnMissile();
        SpawnMissile();
        SpawnMissile();
    }

    // Update is called once per frame
    void Update()
    {
     //   GameObject primitive = Instantiate(GameObject.CreatePrimitive(PrimitiveType.Capsule), Vector3.zero, Quaternion.identity);
        //MissileSpawnUpdate();

        if(Input.GetKeyDown(KeyCode.A)) SpawnMissile();

    }

    private void MissileSpawnUpdate()
    {
        numberOfOthers = currTotalUFOS - numberOfMissiles;
        baseProportionOfMissiles = numberOfMissiles / currTotalUFOS * 100;
        baseProportionOfOthers = numberOfOthers / currTotalUFOS * 100;
        timePassed += Time.deltaTime;

        if (timePassed >= timeToSpawn)
        {
            timePassed = 0f;
            SpawnMissile();
        }
    }

    void SpawnMissile()
    {
        GameObject bezier = Instantiate(bezierCurve);
        int whichTag = UnityEngine.Random.Range(0, 3);
        bezier.gameObject.tag = "Missile"; //ufoType[whichTag];
        bezier.gameObject.name = "MISSILE PATH";  //ufoType[whichTag] + " path";
        bezier.SetActive(true);
    }
}
