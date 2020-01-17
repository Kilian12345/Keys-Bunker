using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    // Script totalement dégueulasse mais nique ça marche

    public ArduinoMissileController arduinoManager;

    void Start()
    {
        arduinoManager = GameObject.Find("Arduino Manager").GetComponent<ArduinoMissileController>();
    }

    void OnTriggerEnter2D(Collider2D col)
    { 
        if (col.gameObject.tag == "Missile") arduinoManager.gameManager.Score(100);

        if (col.gameObject.tag == "Plane") arduinoManager.gameManager.Score(-100);

        arduinoManager.Respawn();
    }
}
