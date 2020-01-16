using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class CustomGridGenerator : MonoBehaviour
{
    float x_Start, y_Start;
    [SerializeField] int columnLength, rowLength;
    [SerializeField] float x_Space, y_Space;
    [SerializeField] GameObject tilePrefab;

    // Start is called before the first frame update
    void Awake()
    {
        x_Start = transform.position.x;
        y_Start = transform.position.y;
        GenerateGrid();
    }

    void GenerateGrid()
    {
        for (int i = 0; i < columnLength; i++)
        {
            for (int j = 0; j < rowLength; j++)
            {
                GameObject grid_object = Instantiate(tilePrefab, gameObject.transform);
                grid_object.transform.position = new Vector2(x_Start + (x_Space * (i % columnLength)), y_Start - (y_Space * (j % rowLength)));
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
