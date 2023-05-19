using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    MapGenerator map = new MapGenerator();
    void Start()
    {
        map.Generator();
        map.PrintBoard();
    }

    void Update()
    {
        
    }
}
