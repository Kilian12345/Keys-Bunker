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
    public GameObject targetSight;
    public GameObject targetTile;
    private GameObject currentTargetTile;
    GameObject yeet;
    [SerializeField] List<GameObject> TileList = new List<GameObject>();
    public int listPosition = 0;
    [ShowInInspector] public Vector3 targetTilePosition;
    public static bool fireMissile = false;

    // Start is called before the first frame update
    void Start()
    {
        x_Start = (int)transform.position.x;
        y_Start = (int)transform.position.y;
        GenerateGrid();
        yeet = Instantiate(targetSight, TileList[listPosition].transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        //CheckInputs();
        MoveOnGrid();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (currentTargetTile == null) TargetTilePosition();

            else Destroy(currentTargetTile);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            foreach (GameObject item in TileList)
            {
                Destroy(item);
            };
            TileList.Clear();
            GenerateGrid();
        }
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
        Destroy(yeet);

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (listPosition == 0) listPosition = 20;
            else if (listPosition == 1) listPosition = 21;
            else if (listPosition == 2) listPosition = 22;
            else if (listPosition == 3) listPosition = 23;
            else if (listPosition == 4) listPosition = 24;
            else listPosition -= columnLength;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            if(listPosition == 20) listPosition = 0;
            else if(listPosition == 21) listPosition = 1;
            else if(listPosition == 22) listPosition = 2;
            else if (listPosition == 23) listPosition = 3;
            else if(listPosition == 24) listPosition = 4;
            else listPosition += columnLength;

        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (listPosition == 0) listPosition = 4;
            else if (listPosition == 5) listPosition = 9;
            else if (listPosition == 10) listPosition = 14;
            else if (listPosition == 15) listPosition = 19;
            else if (listPosition == 20) listPosition = 24;
            else listPosition -= 1;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            if (listPosition == 4) listPosition = 0;
            else if (listPosition == 9) listPosition = 5;
            else if (listPosition == 14) listPosition = 10;
            else if (listPosition == 19) listPosition = 15;
            else if (listPosition == 24) listPosition = 20;
            else listPosition += 1;
        }

        if (listPosition > TileList.Count) listPosition = 0;
        if (listPosition < 0) listPosition = TileList.Count - 1;
        yeet = Instantiate(targetSight, TileList[listPosition].transform.position, Quaternion.identity);
    }

    void TargetTilePosition()
    {
        currentTargetTile = Instantiate(targetTile, TileList[listPosition].transform.position, Quaternion.identity);
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
