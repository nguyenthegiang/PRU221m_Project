using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// [Shortest Path Algorithm]
/// Builds the graph
/// </summary>
public class GraphBuilder : MonoBehaviour
{
    static Graph<Waypoint> graph;

    /// <summary>
    /// Build the Graph
    /// </summary>
    public void Awake()
    {
        graph = new Graph<Waypoint>();

        // add nodes (all waypoints) to graph
        GameObject[] waypointObjects = GameObject.FindGameObjectsWithTag("Waypoint");

        //create array of waypoints from array waypointObjects
        Waypoint[] waypoints = new Waypoint[waypointObjects.Length];
        for (int i = 0; i < waypointObjects.Length; i++)
        {
            waypoints[i] = waypointObjects[i].GetComponent<Waypoint>();
        }

        //sort by Id (to help make correct Edges)
        Waypoint[] sortedWaypoints = waypoints.OrderBy(w => w.Id).ToArray();

        //add to graph
        foreach(Waypoint waypoint in sortedWaypoints)
        {
            graph.AddNode(waypoint);
        }

        // add neighbors for each node in graph (create edges for Graph)
        graph.Nodes[0].AddNeighbor(graph.Nodes[1], 1);
        graph.Nodes[0].AddNeighbor(graph.Nodes[2], 1);
        graph.Nodes[1].AddNeighbor(graph.Nodes[3], 1);
        graph.Nodes[1].AddNeighbor(graph.Nodes[4], 1);
        graph.Nodes[2].AddNeighbor(graph.Nodes[3], 1);
        graph.Nodes[2].AddNeighbor(graph.Nodes[6], 1);
        graph.Nodes[3].AddNeighbor(graph.Nodes[5], 1);
        graph.Nodes[3].AddNeighbor(graph.Nodes[7], 1);
        graph.Nodes[4].AddNeighbor(graph.Nodes[5], 1);
        graph.Nodes[5].AddNeighbor(graph.Nodes[8], 1);
        graph.Nodes[6].AddNeighbor(graph.Nodes[7], 1);
        graph.Nodes[7].AddNeighbor(graph.Nodes[8], 1);
    }

    /// <summary>
    /// Gets and sets the graph
    /// </summary>
    /// <value>graph</value>
    public static Graph<Waypoint> Graph
    {
        get { return graph; }
        set { graph = value; }
    }
}
