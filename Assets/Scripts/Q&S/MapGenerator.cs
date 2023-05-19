using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator
{
    const int rows = 10;
    const int cols = 10;
    public Tile[,] board = new Tile[rows, cols];
    public int bombsNumber = 20;
    public string printSTR;
    
    public void Generator()
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                board[i, j] = new Tile(false);
            }
        }

        
        int placedBombs = 0;
        while (placedBombs < bombsNumber)
        {
            int randRows = Random.Range(0, rows);
            int randCols = Random.Range(0, cols);

            if (board[randRows, randCols].isBomb == true)
            {
                continue;
            }

            board[randRows, randCols] = new Tile(true);
            placedBombs++;
        }
    }

    public void PrintBoard()
    {
        int rows = board.GetLength(0);
        int cols = board.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            for(int j = 0; j < cols; j++)
            {
                if (board[i, j].isBomb == true)
                {
                    printSTR += 'B';
                }
                else
                {
                    printSTR += '0';
                }
                printSTR += ',';
            }
            printSTR += '\n';
        }
        Debug.Log(printSTR);
    }
}
