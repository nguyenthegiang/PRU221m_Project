using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// [Shortest Path Algorithm]
/// [Sorted Linked List]
/// A sorted linked list
/// </summary>
public class SortedLinkedList<T> : LinkedList<T> where T : IComparable
{
    #region Constructor

    public SortedLinkedList() : base()
    {
    }

    #endregion

    #region Methods

    /// <summary>
    /// Adds the given item to the list
    /// </summary>
    /// <param name="item">item to add to list</param>
    public void Add(T item)
    {
        // adding to empty list
        if (First == null)
        {
            AddFirst(item);
        }
        else if (First.Value.CompareTo(item) >= 0)
        {
            // adding before head
            AddFirst(item);
        }
        else
        {
            // find place to add new node
            LinkedListNode<T> previousNode = null;
            LinkedListNode<T> currentNode = First;
            while (currentNode != null &&
                currentNode.Value.CompareTo(item) < 0)
            {
                previousNode = currentNode;
                currentNode = currentNode.Next;
            }

            // link in new node between previous node and current node
            AddAfter(previousNode, item);
        }
    }

    /// <summary>
    /// Repositions the given item in the list by moving it
    /// forward in the list until it's in the correct
    /// position. This is necessary to keep the list sorted
    /// when the value of the item changes
    /// </summary>
    public void Reposition(T item)
    {
        LinkedListNode<T> movingNode = Find(item);
        if (movingNode == null) return;
        if (movingNode.Value.Equals(First))
        {
        }
        else
        {
            Remove(movingNode);

            LinkedListNode<T> currentNode = First;
            LinkedListNode<T> prevNode = null;
            while (currentNode != null && currentNode.Value.CompareTo(item) < 0)
            {
                prevNode = currentNode;
                currentNode = currentNode.Next;
            }
            if (prevNode == null)
            {
                AddFirst(item);
            }
            else if (currentNode == null)
            {
                AddLast(item);
            }
            else
            {
                AddAfter(prevNode, new LinkedListNode<T>(item));
            }
        }
    }

    #endregion
}
