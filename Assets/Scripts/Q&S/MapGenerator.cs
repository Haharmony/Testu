using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapGenerator
{
    const int rows = 10;
    const int cols = 10;
    public Tile[,] board = new Tile[rows, cols];
    public int bombsNumber = 20;
    public int bombsAround = 0;
    public string printSTR;
    Stack<Tile> m_Stack = new Stack<Tile>();
    
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

    public void BombsCounterTile()
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (board[i, j].isBomb != true)
                {
                    continue;
                }
                AddSurroundingNodes(i, j);

                while(m_Stack.Count>0)
                {
                    m_Stack.Pop().BombCounterUp();
                }
            }
        }
    }

    public void AddSurroundingNodes(int x, int y)
    {
        for(int i = x-1; i <= x+1; i++)
        {
            for(int j = y-1; j <= y+1; j++)
            {
                if (i < 0) continue;
                if (i >= rows) continue;
                if (j < 0) continue;
                if (j >= cols) continue;
                if (board[i, j].isBomb == true) continue;

                m_Stack.Push(board[i, j]);
            }
        }
    }
    public void PrintBoard()
    {
        int rows = board.GetLength(0);
        int cols = board.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (board[i, j].isBomb == true)
                {
                    printSTR += 'B';
                }
                else
                {
                    printSTR += board[i, j].bombsAround;
                }
                printSTR += ',';
            }
            printSTR += '\n';
        }
        Debug.Log(printSTR);
    }
}

