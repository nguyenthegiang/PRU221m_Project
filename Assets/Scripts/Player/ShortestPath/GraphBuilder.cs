using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Builds the graph
/// </summary>
public class GraphBuilder : MonoBehaviour
{
    static Graph<Waypoint> graph;

    #region Constructor

    // Uncomment the code below after copying this class into the console
    // app for the automated grader. DON'T uncomment it now; it won't
    // compile in a Unity project

    /// <summary>
    /// Constructor
    /// 
    /// Note: The GraphBuilder class in the Unity solution doesn't 
    /// use a constructor; this constructor is to support automated grading
    /// </summary>
    /// <param name="gameObject">the game object the script is attached to</param>
    //public GraphBuilder(GameObject gameObject) :
    //    base(gameObject)
    //{
    //}

    #endregion

    /// <summary>
    /// Awake is called before Start
    ///
    /// Note: Leave this method public to support automated grading
    /// </summary>
    public void Awake()
    {
        graph = new Graph<Waypoint>();

        // add nodes (all waypoints, including start and end) to graph
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

        // add neighbors for each node in graph
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

        //foreach (GraphNode<Waypoint> node in graph.Nodes)
        //{
        //    //each node: check with every other nodes to see if it is neighbor
        //    foreach (GraphNode<Waypoint> otherNode in graph.Nodes)
        //    {
        //        ////if is neighbor -> position need to be near AND not the same node
        //        if (Mathf.Abs(node.Value.Position.x - otherNode.Value.Position.x) < 3.5
        //            && Mathf.Abs(node.Value.Position.y - otherNode.Value.Position.y) < 3
        //            && node.Value.Id != otherNode.Value.Id)
        //        {
        //            //add neighbor with distance between 2 nodes
        //            node.AddNeighbor(otherNode, Vector2.Distance(node.Value.Position, otherNode.Value.Position));
        //        }
        //    }
        //}
    }

    /// <summary>
    /// Gets and sets the graph
    /// 
    /// CAUTION: Set should only be used by the autograder
    /// </summary>
    /// <value>graph</value>
    public static Graph<Waypoint> Graph
    {
        get { return graph; }
        set { graph = value; }
    }
}
