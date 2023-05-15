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
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                board[i, j] = new Tile(false);
            }
        }

        
        int placedBombs = 0;
        int randCols = Random.Range(0, cols);
        int randRows = Random.Range(0, rows);
        while (placedBombs < bombsNumber)
        {
            int row = randRows;
            int col = randCols;

            if (board[row, col].isBomb == true)
            {
                continue;
            }

            board[row, col] = new Tile(true);
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
                if (board[rows, cols].isBomb == true)
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
