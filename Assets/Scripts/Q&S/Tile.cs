using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile
{
    public bool isVisible;
    public bool isFlagged;
    public int bombsAround;
    public bool isBomb;
    public int x;
    public int y;

    public Tile(bool isBomb)
    {
        this.isBomb = isBomb;
    }

    public void BombCounterUp()
    {
        bombsAround++;
    }
}


