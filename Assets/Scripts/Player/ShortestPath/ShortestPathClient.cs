using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// [Shortest Path Algorithm]
/// The Client that calls to {Traveler} to perform 
/// the algorithm and moves the Character when there is 
/// mouse click
/// </summary>
public class ShortestPathClient : MonoBehaviour
{
    //reference to Traveler to call
    Traveler traveler;
    //Graph of Points
    Graph<Waypoint> graph;

    // Start is called before the first frame update
    void Start()
    {
        traveler = GetComponent<Traveler>();
        graph = GraphBuilder.Graph;
    }

    // Update is called once per frame
    void Update()
    {
        //Get Right Mouse click
        if (Input.GetMouseButtonDown(1))
        {
            //Find mouse position
            Vector3 mousePosition = Input.mousePosition;
            //Convert mouse position to World position
            mousePosition.z = -Camera.main.transform.position.z;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

            //Find Start and End Waypoint Position:

            //Start Position: position of this character
            Waypoint startWaypoint = findClosestWaypoint(transform.position);
            //End Position: position of the Mouse
            Waypoint endWaypoint = findClosestWaypoint(mousePosition);

            //reset all Waypoint's tag before assigning it again
            resetTagWaypoint();

            //Check: if 2 waypoints is the same => no need for movement => end Algorithm
            if (startWaypoint.Id == endWaypoint.Id)
            {
                return;
            }

            //Assign Tag for Start Waypoint and End Waypoint for Algorithm to perform
            startWaypoint.gameObject.tag = "Start";
            endWaypoint.gameObject.tag = "End";

            //call to Traveler to perform Algorithm
            traveler.findPath();
        }
    }

    // Reset tag for all Waypoints
    private void resetTagWaypoint()
    {
        foreach (GraphNode<Waypoint> node in graph.Nodes)
        {
            node.Value.gameObject.tag = "Waypoint";
        }
    }

    // Find the Closest Waypoint of a Position on Map
    // by comparing distance to every waypoint on Map
    private Waypoint findClosestWaypoint(Vector3 position)
    {
        float shortestDistance = float.MaxValue;
        Waypoint closestWaypoint = null;
        foreach (GraphNode<Waypoint> node in graph.Nodes)
        {
            float distanceToNode = Vector3.Distance(position, node.Value.Position);
            if (distanceToNode < shortestDistance)
            {
                shortestDistance = distanceToNode;
                closestWaypoint = node.Value;
            }
        }

        return closestWaypoint;
    }
}
