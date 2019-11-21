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
        /*for (int x = 0; x < columnLength * rowLength; x++)
        {
            GameObject yeet = Instantiate(prefab, new Vector3(x_Start + (x_Space * (x%columnLength)), y_Start - (y_Space * (x/columnLength))), Quaternion.identity);
            TileList.Add(yeet);
            Debug.Log(x/columnLength);
        }*/

        GenerateGrid();
    }

    // Update is called once per frame
    void Update()
    {
        
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
