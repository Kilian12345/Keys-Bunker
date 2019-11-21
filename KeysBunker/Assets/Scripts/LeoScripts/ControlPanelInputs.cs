using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPanelInputs : MonoBehaviour
{
    public static ControlPanelInputs instance;
    public Keybindings keybindings;

    private void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(this);
        DontDestroyOnLoad(this);
    }

    public bool Key(string key)
    {
        if (Input.GetKey(keybindings.CheckKey(key))) return true;
        else return false;
    }

    public bool KeyDown(string key)
    {
        if (Input.GetKeyDown(keybindings.CheckKey(key))) return true;
        else return false;
    }
}
