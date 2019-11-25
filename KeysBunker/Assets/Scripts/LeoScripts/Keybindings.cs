using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Keybindings", menuName ="Keybindings")]
public class Keybindings : ScriptableObject
{
    public KeyCode A0, A1, A2, A3, A4;
    public KeyCode B0, B1, B2, B3, B4;
    public KeyCode C0, C1, C2, C3, C4;
    public KeyCode D0, D1, D2, D3, D4;
    public KeyCode E0, E1, E2, E3, E4;
    public KeyCode F0, F1, F2, F3, F4;

    public KeyCode CheckKey(string key)
    {
        switch (key)
        {
            case "A0":
                return A0;
            case "A1":
                return A1;
            case "A2":
                return A2;
            case "A3":
                return A3;
            case "A4":
                return A4;

            case "B0":
                return B0;
            case "B1":
                return B1;
            case "B2":
                return B2;
            case "B3":
                return B3;
            case "B4":
                return B4;

            case "C0":
                return C0;
            case "C1":
                return C1;
            case "C2":
                return C2;
            case "C3":
                return C3;
            case "C4":
                return C4;

            case "D0":
                return D0;
            case "D1":
                return D1;
            case "D2":
                return D2;
            case "D3":
                return D3;
            case "D4":
                return D4;

            case "E0":
                return E0;
            case "E1":
                return E1;
            case "E2":
                return E2;
            case "E3":
                return E3;
            case "E4":
                return E4;

            default:
                return KeyCode.None;
        }
    }
}
