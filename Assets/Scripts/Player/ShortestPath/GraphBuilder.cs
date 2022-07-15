using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// [Shortest Path Algorithm]
/// Builds the graph
/// </summary>
public class GraphBuilder : MonoBehaviour
{
    static Graph<Waypoint> graph;

    /// <summary>
    /// Awake is called before Start
    /// </summary>
    public void Awake()
    {
        graph = new Graph<Waypoint>();

        // add nodes (all waypoints) to graph
        GameObject startObject = GameObject.FindGameObjectWithTag("Start");
        Waypoint startWaypoint = startObject.GetComponent<Waypoint>();
        graph.AddNode(startWaypoint);

        GameObject[] waypointObjects = GameObject.FindGameObjectsWithTag("Waypoint");
        foreach (GameObject waypointObject in waypointObjects)
        {
            Waypoint waypoint = waypointObject.GetComponent<Waypoint>();
            graph.AddNode(waypoint);
        }

        GameObject endObject = GameObject.FindGameObjectWithTag("End");
        Waypoint endWaypoint = endObject.GetComponent<Waypoint>();
        graph.AddNode(endWaypoint);

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
