using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// [Shortest Path Algorithm]
/// A waypoint
/// </summary>
public class Waypoint : MonoBehaviour
{
    [SerializeField]
    int id;

    /// <summary>
    /// Gets the position of the waypoint
    /// </summary>
    /// <value>position</value>
    public Vector2 Position
    {
        get { return transform.position; }
    }

    /// <summary>
    /// Gets the unique id for the waypoint
    /// </summary>
    /// <value>unique id</value>
    public int Id
    {
        get { return id; }
    }
}
