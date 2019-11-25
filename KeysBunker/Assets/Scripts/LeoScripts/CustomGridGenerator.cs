using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class CustomGridGenerator : MonoBehaviour
{
    int x_Start, y_Start;
    public int columnLength, rowLength;
    public float x_Space, y_Space;
    public GameObject prefab;
    public GameObject prefab2;
    [SerializeField] List<GameObject> TileList = new List<GameObject>();
    public int listPosition = 0;
    [ShowInInspector] public Vector3 targetTilePosition;
    public static bool fireMissile = false;

    // Start is called before the first frame update
    void Start()
    {
        GenerateGrid();
    }

    // Update is called once per frame
    void Update()
    {
        //CheckInputs();
        MoveOnGrid();

        if (Input.GetKeyDown(KeyCode.Space)) TargetTilePosition();
    }

    void CheckInputs()
    {
        //////////////////////////////////////////////////////////////////
        if (ControlPanelInputs.instance.KeyDown("A0"))
            foreach (GameObject item in TileList)
                if (item.name == "A0")
                { targetTilePosition = item.transform.position; fireMissile = true; }

        if (ControlPanelInputs.instance.KeyDown("A1"))
            foreach (GameObject item in TileList)
                if (item.name == "A1")
                { targetTilePosition = item.transform.position; fireMissile = true; }

        if (ControlPanelInputs.instance.KeyDown("A2"))
            foreach (GameObject item in TileList)
                if (item.name == "A2")
                { targetTilePosition = item.transform.position; fireMissile = true; }

        if (ControlPanelInputs.instance.KeyDown("A3"))
            foreach (GameObject item in TileList)
                if (item.name == "A3")
                { targetTilePosition = item.transform.position; fireMissile = true; }

        if (ControlPanelInputs.instance.KeyDown("A4"))
            foreach (GameObject item in TileList)
                if (item.name == "A4")
                { targetTilePosition = item.transform.position; fireMissile = true; }

        //////////////////////////////////////////////////////////////////
        if (ControlPanelInputs.instance.KeyDown("B0"))
            foreach (GameObject item in TileList)
                if (item.name == "B0")
                { targetTilePosition = item.transform.position; fireMissile = true; }

        if (ControlPanelInputs.instance.KeyDown("B1"))
            foreach (GameObject item in TileList)
                if (item.name == "B1")
                { targetTilePosition = item.transform.position; fireMissile = true; }

        if (ControlPanelInputs.instance.KeyDown("B2"))
            foreach (GameObject item in TileList)
                if (item.name == "B2")
                { targetTilePosition = item.transform.position; fireMissile = true; }

        if (ControlPanelInputs.instance.KeyDown("B3"))
            foreach (GameObject item in TileList)
                if (item.name == "B3")
                { targetTilePosition = item.transform.position; fireMissile = true; }

        if (ControlPanelInputs.instance.KeyDown("B4"))
            foreach (GameObject item in TileList)
                if (item.name == "B4")
                { targetTilePosition = item.transform.position; fireMissile = true; }

        //////////////////////////////////////////////////////////////////
        if (ControlPanelInputs.instance.KeyDown("C0"))
            foreach (GameObject item in TileList)
                if (item.name == "C0")
                { targetTilePosition = item.transform.position; fireMissile = true; }

        if (ControlPanelInputs.instance.KeyDown("C1"))
            foreach (GameObject item in TileList)
                if (item.name == "C1")
                { targetTilePosition = item.transform.position; fireMissile = true; }

        if (ControlPanelInputs.instance.KeyDown("C2"))
            foreach (GameObject item in TileList)
                if (item.name == "C2")
                { targetTilePosition = item.transform.position; fireMissile = true; }

        if (ControlPanelInputs.instance.KeyDown("C3"))
            foreach (GameObject item in TileList)
                if (item.name == "C3")
                { targetTilePosition = item.transform.position; fireMissile = true; }

        if (ControlPanelInputs.instance.KeyDown("C4"))
            foreach (GameObject item in TileList)
                if (item.name == "C4")
                { targetTilePosition = item.transform.position; fireMissile = true; }

        //////////////////////////////////////////////////////////////////
        if (ControlPanelInputs.instance.KeyDown("D0"))
            foreach (GameObject item in TileList)
                if (item.name == "D0")
                { targetTilePosition = item.transform.position; fireMissile = true; }

        if (ControlPanelInputs.instance.KeyDown("D1"))
            foreach (GameObject item in TileList)
                if (item.name == "D1")
                { targetTilePosition = item.transform.position; fireMissile = true; }

        if (ControlPanelInputs.instance.KeyDown("D2"))
            foreach (GameObject item in TileList)
                if (item.name == "D2")
                { targetTilePosition = item.transform.position; fireMissile = true; }

        if (ControlPanelInputs.instance.KeyDown("D3"))
            foreach (GameObject item in TileList)
                if (item.name == "D3")
                { targetTilePosition = item.transform.position; fireMissile = true; }

        if (ControlPanelInputs.instance.KeyDown("D4"))
            foreach (GameObject item in TileList)
                if (item.name == "D4")
                { targetTilePosition = item.transform.position; fireMissile = true; }

        //////////////////////////////////////////////////////////////////
        if (ControlPanelInputs.instance.KeyDown("E0"))
            foreach (GameObject item in TileList)
                if (item.name == "E0")
                { targetTilePosition = item.transform.position; fireMissile = true; }

        if (ControlPanelInputs.instance.KeyDown("E1"))
            foreach (GameObject item in TileList)
                if (item.name == "E1")
                { targetTilePosition = item.transform.position; fireMissile = true; }

        if (ControlPanelInputs.instance.KeyDown("E2"))
            foreach (GameObject item in TileList)
                if (item.name == "E2")
                { targetTilePosition = item.transform.position; fireMissile = true; }

        if (ControlPanelInputs.instance.KeyDown("E3"))
            foreach (GameObject item in TileList)
                if (item.name == "E3")
                { targetTilePosition = item.transform.position; fireMissile = true; }

        if (ControlPanelInputs.instance.KeyDown("E4"))
            foreach (GameObject item in TileList)
                if (item.name == "E4")
                { targetTilePosition = item.transform.position; fireMissile = true; }
    }
    
    void MoveOnGrid()
    {
        if (Input.GetKeyDown(KeyCode.Q)) listPosition -= columnLength;
        if (Input.GetKeyDown(KeyCode.D)) listPosition += columnLength;
        if (Input.GetKeyDown(KeyCode.Z)) listPosition -= 1;
        if (Input.GetKeyDown(KeyCode.S)) listPosition +=1;
    }

    void TargetTilePosition()
    {
        Instantiate(prefab2, TileList[listPosition].transform.position, Quaternion.identity);
    }

    void GenerateGrid()
    {
        for (int i = 0; i < columnLength; i++)
        {
            for (int j = 0; j < rowLength; j++)
            {
                GameObject grid_object = Instantiate(prefab);
                grid_object.transform.position = new Vector2(x_Start + (x_Space * (i % columnLength)), y_Start - (y_Space * (j % rowLength)));
                TileList.Add(grid_object);
                switch (i)
                {
                    case 0:
                        grid_object.name = "A" + j;
                        break;
                    case 1:
                        grid_object.name = "B" + j;
                        break;
                    case 2:
                        grid_object.name = "C" + j;
                        break;
                    case 3:
                        grid_object.name = "D" + j;
                        break;
                    case 4:
                        grid_object.name = "E" + j;
                        break;
                    case 5:
                        grid_object.name = "F" + j;
                        break;
                    case 6:
                        grid_object.name = "G" + j;
                        break;
                    case 7:
                        grid_object.name = "H" + j;
                        break;
                    case 8:
                        grid_object.name = "J" + j;
                        break;
                    case 9:
                        grid_object.name = "K" + j;
                        break;
                    case 10:
                        grid_object.name = "L" + j;
                        break;
                }
            }
        }
    }
}
