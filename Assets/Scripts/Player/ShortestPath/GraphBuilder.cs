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
        // Directed Graph => which every 2 Points of Graph, have to add 2 Edges
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

        graph.Nodes[1].AddNeighbor(graph.Nodes[0], 1);
        graph.Nodes[2].AddNeighbor(graph.Nodes[0], 1);
        graph.Nodes[3].AddNeighbor(graph.Nodes[1], 1);
        graph.Nodes[4].AddNeighbor(graph.Nodes[1], 1);
        graph.Nodes[3].AddNeighbor(graph.Nodes[2], 1);
        graph.Nodes[6].AddNeighbor(graph.Nodes[2], 1);
        graph.Nodes[5].AddNeighbor(graph.Nodes[3], 1);
        graph.Nodes[7].AddNeighbor(graph.Nodes[3], 1);
        graph.Nodes[5].AddNeighbor(graph.Nodes[4], 1);
        graph.Nodes[8].AddNeighbor(graph.Nodes[5], 1);
        graph.Nodes[7].AddNeighbor(graph.Nodes[6], 1);
        graph.Nodes[8].AddNeighbor(graph.Nodes[7], 1);

        //Huyen add
        graph.Nodes[9].AddNeighbor(graph.Nodes[10], 1);
        graph.Nodes[10].AddNeighbor(graph.Nodes[9], 1);

        graph.Nodes[29].AddNeighbor(graph.Nodes[15], 1); 
        graph.Nodes[15].AddNeighbor(graph.Nodes[29], 1);

        graph.Nodes[26].AddNeighbor(graph.Nodes[27], 1);
        graph.Nodes[27].AddNeighbor(graph.Nodes[26], 1);

        graph.Nodes[23].AddNeighbor(graph.Nodes[22], 1);
        graph.Nodes[22].AddNeighbor(graph.Nodes[23], 1);

        graph.Nodes[10].AddNeighbor(graph.Nodes[11], 1);
        graph.Nodes[11].AddNeighbor(graph.Nodes[10], 1);
        graph.Nodes[10].AddNeighbor(graph.Nodes[15], 1);
        graph.Nodes[15].AddNeighbor(graph.Nodes[10], 1);

        graph.Nodes[15].AddNeighbor(graph.Nodes[16], 1);
        graph.Nodes[16].AddNeighbor(graph.Nodes[15], 1);
        graph.Nodes[15].AddNeighbor(graph.Nodes[27], 1);
        graph.Nodes[27].AddNeighbor(graph.Nodes[15], 1);

        graph.Nodes[27].AddNeighbor(graph.Nodes[28], 1);
        graph.Nodes[28].AddNeighbor(graph.Nodes[27], 1);
        graph.Nodes[27].AddNeighbor(graph.Nodes[22], 1);
        graph.Nodes[22].AddNeighbor(graph.Nodes[27], 1);

        graph.Nodes[22].AddNeighbor(graph.Nodes[21], 1);
        graph.Nodes[21].AddNeighbor(graph.Nodes[22], 1);
        graph.Nodes[22].AddNeighbor(graph.Nodes[30], 1);
        graph.Nodes[30].AddNeighbor(graph.Nodes[22], 1);

        graph.Nodes[11].AddNeighbor(graph.Nodes[12], 1);
        graph.Nodes[12].AddNeighbor(graph.Nodes[11], 1);
        graph.Nodes[11].AddNeighbor(graph.Nodes[16], 1);
        graph.Nodes[16].AddNeighbor(graph.Nodes[11], 1);

        graph.Nodes[16].AddNeighbor(graph.Nodes[17], 1);
        graph.Nodes[17].AddNeighbor(graph.Nodes[16], 1);
        graph.Nodes[16].AddNeighbor(graph.Nodes[28], 1);
        graph.Nodes[28].AddNeighbor(graph.Nodes[16], 1);

        graph.Nodes[28].AddNeighbor(graph.Nodes[21], 1);
        graph.Nodes[21].AddNeighbor(graph.Nodes[28], 1);
        graph.Nodes[28].AddNeighbor(graph.Nodes[25], 1);
        graph.Nodes[25].AddNeighbor(graph.Nodes[28], 1);

        graph.Nodes[21].AddNeighbor(graph.Nodes[20], 1);
        graph.Nodes[20].AddNeighbor(graph.Nodes[21], 1);
        graph.Nodes[21].AddNeighbor(graph.Nodes[31], 1);
        graph.Nodes[31].AddNeighbor(graph.Nodes[21], 1);

        graph.Nodes[12].AddNeighbor(graph.Nodes[13], 1);
        graph.Nodes[13].AddNeighbor(graph.Nodes[12], 1);
        graph.Nodes[12].AddNeighbor(graph.Nodes[17], 1);
        graph.Nodes[17].AddNeighbor(graph.Nodes[12], 1);

        graph.Nodes[17].AddNeighbor(graph.Nodes[14], 1);
        graph.Nodes[14].AddNeighbor(graph.Nodes[17], 1);
        graph.Nodes[17].AddNeighbor(graph.Nodes[25], 1);
        graph.Nodes[25].AddNeighbor(graph.Nodes[17], 1);

        graph.Nodes[25].AddNeighbor(graph.Nodes[24], 1);
        graph.Nodes[24].AddNeighbor(graph.Nodes[25], 1);
        graph.Nodes[25].AddNeighbor(graph.Nodes[20], 1);
        graph.Nodes[20].AddNeighbor(graph.Nodes[25], 1);

        graph.Nodes[20].AddNeighbor(graph.Nodes[32], 1);
        graph.Nodes[32].AddNeighbor(graph.Nodes[20], 1);
        graph.Nodes[20].AddNeighbor(graph.Nodes[18], 1);
        graph.Nodes[18].AddNeighbor(graph.Nodes[20], 1);

        graph.Nodes[13].AddNeighbor(graph.Nodes[4], 1);
        graph.Nodes[4].AddNeighbor(graph.Nodes[13], 1);
        graph.Nodes[13].AddNeighbor(graph.Nodes[14], 1);
        graph.Nodes[14].AddNeighbor(graph.Nodes[13], 1);

        graph.Nodes[14].AddNeighbor(graph.Nodes[5], 1);
        graph.Nodes[5].AddNeighbor(graph.Nodes[14], 1);
        graph.Nodes[14].AddNeighbor(graph.Nodes[24], 1);
        graph.Nodes[24].AddNeighbor(graph.Nodes[14], 1);

        graph.Nodes[8].AddNeighbor(graph.Nodes[24], 1);
        graph.Nodes[24].AddNeighbor(graph.Nodes[8], 1);
        graph.Nodes[24].AddNeighbor(graph.Nodes[18], 1);
        graph.Nodes[18].AddNeighbor(graph.Nodes[24], 1);

        graph.Nodes[18].AddNeighbor(graph.Nodes[19], 1);
        graph.Nodes[19].AddNeighbor(graph.Nodes[18], 1);
        graph.Nodes[18].AddNeighbor(graph.Nodes[33], 1);
        graph.Nodes[33].AddNeighbor(graph.Nodes[18], 1);

        graph.Nodes[6].AddNeighbor(graph.Nodes[37], 1);
        graph.Nodes[37].AddNeighbor(graph.Nodes[6], 1);
        graph.Nodes[37].AddNeighbor(graph.Nodes[36], 1);
        graph.Nodes[36].AddNeighbor(graph.Nodes[37], 1);

        graph.Nodes[18].AddNeighbor(graph.Nodes[33], 1);
        graph.Nodes[33].AddNeighbor(graph.Nodes[18], 1);
        graph.Nodes[19].AddNeighbor(graph.Nodes[34], 1);
        graph.Nodes[34].AddNeighbor(graph.Nodes[19], 1);

        graph.Nodes[38].AddNeighbor(graph.Nodes[35], 1);
        graph.Nodes[35].AddNeighbor(graph.Nodes[38], 1);
        graph.Nodes[38].AddNeighbor(graph.Nodes[37], 1);
        graph.Nodes[37].AddNeighbor(graph.Nodes[38], 1);
        graph.Nodes[38].AddNeighbor(graph.Nodes[19], 1);
        graph.Nodes[19].AddNeighbor(graph.Nodes[38], 1);

        graph.Nodes[19].AddNeighbor(graph.Nodes[8], 1);
        graph.Nodes[8].AddNeighbor(graph.Nodes[19], 1);
        graph.Nodes[7].AddNeighbor(graph.Nodes[38], 1);
        graph.Nodes[38].AddNeighbor(graph.Nodes[7], 1);

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
