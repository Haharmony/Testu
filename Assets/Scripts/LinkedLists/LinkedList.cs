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

    // Method to delete a node no matter the position in the linked list.
    public void DeleteNode(Node nodeToDelete)
    {
        // If the node reference or head is null, returns.
        if (head == null || nodeToDelete == null)
        {
            return;
        }

        // If the node reference is the first node, moves the head to the next node and makes the first node null.
        if (nodeToDelete == head)
        {
            head = head.next;
            head.prev = null;
            return;
        }

        // If the node reference is the last node, takes the next of the prev node and makes it null.
        if (nodeToDelete.next == null)
        {
            nodeToDelete.prev.next = null;
            return;
        }

        nodeToDelete.prev.next = nodeToDelete.next;
        nodeToDelete.next.prev = nodeToDelete.prev;
    }

    // Method to find a node by the value of the node data, returns a node.
    public Node FindNode(int value)
    {
        Node nodeToFind = head;
        while (nodeToFind != null)
        {
            if (value == nodeToFind.data)
            {
                return nodeToFind;
            }

            nodeToFind = nodeToFind.next;
        }
        return null;
    }

    // Method to get the value of the node referenced by an index (position in the list), returns a node.
    public Node GetNodeValue(int index)
    {
        Node nodeValue = head;
        int currentIndex = 0;
        while (nodeValue != null && currentIndex < index)
        {
            nodeValue = nodeValue.next;
            currentIndex++;
        }

        return nodeValue;
    }
}

public class LoopList
{
    public Node head;

    // Initialize the list.
    public LoopList()
    {
        head = null;
    }

    // Method to add the first node of the list.
    public void AddFirstNode(int data)
    {
        Node firstNode = new Node(data);
        if (head == null)
        {
            head = firstNode;
        }

        firstNode.next = head;
        head.prev = firstNode;
        head = firstNode;
        head.prev = head;
        head.next = head;
    }

    // Method to add a new node in between two existing nodes in the list.
    public void AddInBetween(int data, int index)
    {
        Node newNode = new Node(data);

        if (head == null)
        {
            AddFirstNode(data);
            return;
        }

        // Run through the list to find the node at the specified index.
        Node currentNode = head;
        int currentIndex = 0;
        while (currentIndex < index)
        {
            currentNode = currentNode.next;
            currentIndex++;
        }

        newNode.prev = currentNode.prev;
        newNode.next = currentNode;
        currentNode.prev.next = newNode;
        currentNode.prev = newNode;
        head = newNode;
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

    // Method to delete a node no matter the position in the linked list.
    public void DeleteNode(Node nodeToDelete)
    {
        // If the node reference or head is null, returns.
        if (head == null || nodeToDelete == null)
        {
            return;
        }

        // If the list has only one node, delete it.
        if (head == head.next)
        {
            head = null;
            return;
        }

        // If we need to delete the head node, update head references.
        if (nodeToDelete == head)
        {
            head = head.next;
            head.prev = head;
            return;
        }
        else
        {
            Node current = head;
            while (current.next != nodeToDelete)
            {
                current = current.next;
                if (current == head) // If we looped back to the head and didn't find the node, it's not in the list.
                {
                    return;
                }
            }
        }

        nodeToDelete.prev.next = nodeToDelete.next;
        nodeToDelete.next.prev = nodeToDelete.prev;
    }

    // Method to find a node by the value of the node data, returns a node.
    public Node FindNode(int value)
    {
        Node nodeToFind = head;
        while (nodeToFind != null)
        {
            if (value == nodeToFind.data)
            {
                return nodeToFind;
            }
            nodeToFind = nodeToFind.next;
        }
        return null;
    }

    // Method to get the value of the node referenced by an index (position in the list), returns a node.
    public Node GetNodeValue(int index)
    {
        Node nodeValue = head;
        int currentIndex = 0;
        while (nodeValue != null && currentIndex < index)
        {
            nodeValue = nodeValue.next;
            currentIndex++;
        }

        return nodeValue;
    }
}
