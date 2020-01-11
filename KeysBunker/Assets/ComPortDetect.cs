using UnityEngine;
using System.Collections;
using System.IO.Ports;

public class ComPortDetect : MonoBehaviour
{

    string[] ports = SerialPort.GetPortNames();

    void Start()
    {
        Debug.Log("The following serial ports were found:");

        foreach (string port in ports)
        {
            Debug.Log(port);
        }
    }
}