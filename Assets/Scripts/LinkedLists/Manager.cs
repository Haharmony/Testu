using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    LinkedList list = new LinkedList();

    public void AddDataAtLast()
    {
        list.AddLast(3);
    }

    public void AddDataAtBeginning()
    {
        list.AddBeginning(10);
    }

    public void AddDataAtBetween()
    {
        list.AddInBetween(50, 3);
    }

    public void ShowData()
    {
        list.PrintList();
    }
}
