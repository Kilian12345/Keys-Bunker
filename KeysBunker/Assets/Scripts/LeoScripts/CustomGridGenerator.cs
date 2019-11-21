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
    [SerializeField] List<GameObject> TileList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        GenerateGrid();
    }

    // Update is called once per frame
    void Update()
    {
        CheckInputs();
    }

    void CheckInputs()
    {
        //////////////////////////////////////////////////////////////////
        if (ControlPanelInputs.instance.KeyDown("A0"))
            foreach (GameObject item in TileList)
                if (item.name == "A0")
                    Debug.Log("found 'im at " + item.transform.position);

        if (ControlPanelInputs.instance.KeyDown("A1"))
            foreach (GameObject item in TileList)
                if (item.name == "A1")
                    Debug.Log("found 'im at " + item.transform.position);

        if (ControlPanelInputs.instance.KeyDown("A2"))
            foreach (GameObject item in TileList)
                if (item.name == "A2")
                    Debug.Log("found 'im at " + item.transform.position);

        if (ControlPanelInputs.instance.KeyDown("A3"))
            foreach (GameObject item in TileList)
                if (item.name == "A3")
                    Debug.Log("found 'im at " + item.transform.position);

        if (ControlPanelInputs.instance.KeyDown("A4"))
            foreach (GameObject item in TileList)
                if (item.name == "A4")
                    Debug.Log("found 'im at " + item.transform.position);

        //////////////////////////////////////////////////////////////////
        if (ControlPanelInputs.instance.KeyDown("B0"))
            foreach (GameObject item in TileList)
                if (item.name == "B0")
                    Debug.Log("found 'im at " + item.transform.position);

        if (ControlPanelInputs.instance.KeyDown("B1"))
            foreach (GameObject item in TileList)
                if (item.name == "B1")
                    Debug.Log("found 'im at " + item.transform.position);

        if (ControlPanelInputs.instance.KeyDown("B2"))
            foreach (GameObject item in TileList)
                if (item.name == "B2")
                    Debug.Log("found 'im at " + item.transform.position);

        if (ControlPanelInputs.instance.KeyDown("B3"))
            foreach (GameObject item in TileList)
                if (item.name == "B3")
                    Debug.Log("found 'im at " + item.transform.position);

        if (ControlPanelInputs.instance.KeyDown("B4"))
            foreach (GameObject item in TileList)
                if (item.name == "B4")
                    Debug.Log("found 'im at " + item.transform.position);

        //////////////////////////////////////////////////////////////////
        if (ControlPanelInputs.instance.KeyDown("C0"))
            foreach (GameObject item in TileList)
                if (item.name == "C0")
                    Debug.Log("found 'im at " + item.transform.position);

        if (ControlPanelInputs.instance.KeyDown("C1"))
            foreach (GameObject item in TileList)
                if (item.name == "C1")
                    Debug.Log("found 'im at " + item.transform.position);

        if (ControlPanelInputs.instance.KeyDown("C2"))
            foreach (GameObject item in TileList)
                if (item.name == "C2")
                    Debug.Log("found 'im at " + item.transform.position);

        if (ControlPanelInputs.instance.KeyDown("C3"))
            foreach (GameObject item in TileList)
                if (item.name == "C3")
                    Debug.Log("found 'im at " + item.transform.position);

        if (ControlPanelInputs.instance.KeyDown("C4"))
            foreach (GameObject item in TileList)
                if (item.name == "C4")
                    Debug.Log("found 'im at " + item.transform.position);

        //////////////////////////////////////////////////////////////////
        if (ControlPanelInputs.instance.KeyDown("D0"))
            foreach (GameObject item in TileList)
                if (item.name == "D0")
                    Debug.Log("found 'im at " + item.transform.position);

        if (ControlPanelInputs.instance.KeyDown("D1"))
            foreach (GameObject item in TileList)
                if (item.name == "D1")
                    Debug.Log("found 'im at " + item.transform.position);

        if (ControlPanelInputs.instance.KeyDown("D2"))
            foreach (GameObject item in TileList)
                if (item.name == "D2")
                    Debug.Log("found 'im at " + item.transform.position);

        if (ControlPanelInputs.instance.KeyDown("D3"))
            foreach (GameObject item in TileList)
                if (item.name == "D3")
                    Debug.Log("found 'im at " + item.transform.position);

        if (ControlPanelInputs.instance.KeyDown("D4"))
            foreach (GameObject item in TileList)
                if (item.name == "D4")
                    Debug.Log("found 'im at " + item.transform.position);

        //////////////////////////////////////////////////////////////////
        if (ControlPanelInputs.instance.KeyDown("E0"))
            foreach (GameObject item in TileList)
                if (item.name == "E0")
                    Debug.Log("found 'im at " + item.transform.position);

        if (ControlPanelInputs.instance.KeyDown("E1"))
            foreach (GameObject item in TileList)
                if (item.name == "E1")
                    Debug.Log("found 'im at " + item.transform.position);

        if (ControlPanelInputs.instance.KeyDown("E2"))
            foreach (GameObject item in TileList)
                if (item.name == "E2")
                    Debug.Log("found 'im at " + item.transform.position);

        if (ControlPanelInputs.instance.KeyDown("E3"))
            foreach (GameObject item in TileList)
                if (item.name == "E3")
                    Debug.Log("found 'im at " + item.transform.position);

        if (ControlPanelInputs.instance.KeyDown("E4"))
            foreach (GameObject item in TileList)
                if (item.name == "E4")
                    Debug.Log("found 'im at " + item.transform.position);
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
