using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile
{
    public bool isVisible;
    public bool isFlagged;
    public int bombsAround;
    public bool isBomb;

    public Tile(bool isBomb)
    {
        this.isBomb = isBomb;
    }

    public void BombCounterUp()
    {
        bombsAround++;
    }
}


