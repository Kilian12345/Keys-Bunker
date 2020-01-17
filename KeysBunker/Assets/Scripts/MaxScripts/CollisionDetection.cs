using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    // Script totalement dégueulasse mais nique ça marche

    public ArduinoMissileController arduinoManager;

    int value = 100;
    int value2 = -100;

    void Start()
    {
        arduinoManager = GameObject.Find("Arduino Manager").GetComponent<ArduinoMissileController>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.transform.parent.tag == "Missile") arduinoManager.gameManager.Score(value);

        if (col.gameObject.transform.parent.tag == "Plane") arduinoManager.gameManager.Score(value2);

        arduinoManager.Respawn();
    }
}
