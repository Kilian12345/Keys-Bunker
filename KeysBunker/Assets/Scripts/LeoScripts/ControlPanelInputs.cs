using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPanelInputs : MonoBehaviour
{
    string key1;
    string key2;
    public bool bLocked;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {

        }
    }
    void OnGUI()
    {
        if (Event.current.isKey && Event.current.type == EventType.KeyDown)
        {
            key1 = Event.current.keyCode.ToString();

            if (Event.current.isKey && Event.current.type == EventType.KeyDown && bLocked)
            {
                key2 = Event.current.keyCode.ToString();
                Debug.Log("Target is " + key1 + key2);
            }
        }
    }
}
