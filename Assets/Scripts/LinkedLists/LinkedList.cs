using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkedList : MonoBehaviour
{
    public Node head;

    // Initialize the empty list.
    public LinkedList()
    {
        head = null;
    }

    // Method to add the first node of the list.
    public void AddFirstNode(int data)
    {
        Node firstNode = new Node(data);
        if (head == null ) 
        {
            head = firstNode;
        }

        firstNode.next = head;
        head.prev = firstNode;
        head = firstNode;

    }
    // Method to add a new node to the beginning of the list.
    public void AddBeginning(int data)
    {
        Node newNode = new Node(data);

        if (head == null)
        {
            // If the list is empty, make the new node the head.
            head = newNode;
        }
        else
        {
            // Set the new node's next pointer to the current head.
            newNode.next = head;

            // Set the current head's prev pointer to the new node.
            head.prev = newNode;

            // Make the new node the new head of the list.
            head = newNode;
        }
    }

    // Method to add a new node to the end of the list.
    public void AddLast(int data)
    {
        Node newNode = new Node(data);

        if (head == null)
        {
            head = newNode;
        }
        else
        {
            // Run through the list to find the last node.
            Node lastNode = head;
            while (lastNode.next != null)
            {
                lastNode = lastNode.next;
            }

            // Add the new node to the end of the list.
            lastNode.next = newNode;
            newNode.prev = lastNode;
        }
    }



    // Method to add a new node in between two existing nodes in the list.
    public void AddInBetween(int data, int index)
    {
        Node newNode = new Node(data);

        if (head == null)
        {
            // If the list is empty, make the new node the head.
            head = newNode;
        }
        else
        {
            // Run through the list to find the node at the specified index.
            Node currentNode = head;
            int currentIndex = 0;
            while (currentNode != null && currentIndex < index)
            {
                currentNode = currentNode.next;
                currentIndex++;
            }

            if (currentNode == null)
            {
                // If the specified index is out of range, add the new node to the end of the list.
                Node lastNode = head;
                while (lastNode.next != null)
                {
                    lastNode = lastNode.next;
                }

                lastNode.next = newNode;
                newNode.prev = lastNode;
            }
            else
            {
                newNode.prev = currentNode.prev;
                newNode.next = currentNode;
                currentNode.prev.next = newNode;
                currentNode.prev = newNode;
            }
        }
    }

    // Method to print the list stored data.
    public void PrintList()
    {
        Node current = head;
        while (current != null)
        {
            Debug.Log(current.data + " ");
            current = current.next;
        }
    }
}
