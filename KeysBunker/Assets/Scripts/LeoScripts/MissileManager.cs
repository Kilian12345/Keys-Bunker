using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class MissileManager : MonoBehaviour
{
    /* THIS CLASS HANDLES THE INSTANTIATION OF BEZIER SPLINES
     */

    [SerializeField] GameObject bezierCurve;

    //UFO Variables
    [SerializeField] float maxUFOS;
    [ShowInInspector] public static float currentUFOS;
    [Range(0, 100)] [SerializeField] float proportionOfUFOS;

    //Missile Variables
    [SerializeField] float maxMissiles;
    [ShowInInspector] public static float currentMissiles;
    [Range (0, 100)][SerializeField] float proportionOfMissiles;
    [SerializeField] float missileSpawnChance;

    [SerializeField] List<string> ufoType = new List<string>();
    
    //Spawn Variables
    [SerializeField] float timeToSpawn;
    [SerializeField] float timePassed;
    [SerializeField] public float yeet;

    // Start is called before the first frame update
    void Awake()
    {
        ufoType.Add("Plane");
        ufoType.Add("Missile");
        SpawnMissile();
        SpawnMissile();
        SpawnMissile();
    }

    // Update is called once per frame
    void Update()
    {
        MissileSpawnCheck();

        if(Input.GetKeyDown(KeyCode.A)) SpawnMissile();
    }

    void MissileSpawnCheck()
    {
        yeet = Mathf.Abs(maxUFOS - currentMissiles);
        proportionOfMissiles = currentMissiles / yeet * 100;
        proportionOfUFOS = currentUFOS / maxUFOS * 100;

        missileSpawnChance = 100 - proportionOfMissiles;

        if (timePassed >= timeToSpawn)
        {
            SpawnMissile();
        }
        else if(currentUFOS < maxUFOS) timePassed += Time.deltaTime;
    }

    void SpawnMissile()
    {               
        int randomPick = UnityEngine.Random.Range(0, 100);

        if(currentUFOS < maxUFOS)
        {
            if (randomPick <= missileSpawnChance && currentMissiles < maxMissiles)
            {
                timePassed = 0f;
                GameObject bezier = Instantiate(bezierCurve);
                bezier.SetActive(true);
                bezier.gameObject.tag = "Missile";
                bezier.gameObject.name = "Missile Path";
                currentMissiles++;
            }

            else
            {
                timePassed = 0f;
                GameObject bezier = Instantiate(bezierCurve);
                bezier.SetActive(true);
                bezier.gameObject.tag = "Plane";
                bezier.gameObject.name = "Plane Path";
            }
            currentUFOS++;
        }
    }
}
