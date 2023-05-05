using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public int data;
    public Node next;
    public Node prev;

    // Constructor 1: Initialize node with data only
    public Node(int data)
    {
        this.data = data;
        this.next = null;
        this.prev = null;
    }

    // Constructor 2: Initialize node with data, next node, and previous node
    public Node(int data, Node next, Node prev)
    {
        this.data = data;
        this.next = next;
        this.prev = prev;
    }

    // Constructor 3: Initialize empty node
    public Node()
    {
        this.data = 0;
        this.next = null;
        this.prev = null;
    }
}

