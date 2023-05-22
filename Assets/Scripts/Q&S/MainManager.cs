using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    public Button[] buttons;
    public Button[,] uiBoard = new Button[10, 10];
    MapGenerator map = new MapGenerator();
    void Start()
    {
        map.Generator();
        map.BombsCounterTile();
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                uiBoard[i, j] = buttons[100];
            }
        }
    }

    public void GenerateMap()
    {

        //map.PrintBoard();
    }

    public void DiscoverTileButton()
    {

    }
}
