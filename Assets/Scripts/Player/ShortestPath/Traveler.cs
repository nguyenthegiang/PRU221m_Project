using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// [Shortest Path Algorithm]
/// Controller of Shortest Path Algorithm: 
/// Perform the algorithm when get called to
/// </summary>
public class Traveler : MonoBehaviour
{
    #region Fields

    // needed for the PathLength property
    float pathLength = 0;

    //needed for moving
    List<Vector2> pathToMove = new List<Vector2>();
    int current = 0;

    #endregion

    #region Properties

    /// <summary>
    /// Gets the length of the final path
    /// </summary>
    public float PathLength
    {
        get { return pathLength; }
    }

    #endregion

    #region Unity methods

    private void Update()
    {
        //follow path if there is one
        if (pathToMove.Count > 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, pathToMove[current], Time.deltaTime * 3f);
            if (current >= pathToMove.Count - 1)
            {
                return;
            }
            else
            {
            }
            if (Vector3.Distance(pathToMove[current], transform.position) < 1)
            {
                current++;
            }
        }
    }

    #endregion

    #region Public methods

    /// <summary>
    /// Use Shortest Path Algorithm to find the path
    /// (for Client to call to start Algorithm)
    /// </summary>
    public void findPath()
    {
        //clear path
        pathToMove = new List<Vector2>();
        current = 0;

        //path to start position
        pathToMove.Add(GameObject.FindGameObjectWithTag("Start").transform.position);

        //find path
        Waypoint start = GameObject.FindGameObjectWithTag("Start").GetComponent<Waypoint>();
        Waypoint end = GameObject.FindGameObjectWithTag("End").GetComponent<Waypoint>();
        Graph<Waypoint> graph = GraphBuilder.Graph;
        //Use Algorithm
        LinkedList<Waypoint> path = Search(start, end, graph);

        //make path
        foreach (Waypoint waypoint in path)
        {
            pathToMove.Add(waypoint.Position);

            waypoint.gameObject.GetComponent<SpriteRenderer>().color = Color.green;
        }
    }

    /// <summary>
    /// Perfom Shortest Path Algorithm
    /// Does a search for a path from start to end on
    /// graph
    /// </summary>
    /// <param name="start">start value</param>
    /// <param name="finish">finish value</param>
    /// <param name="graph">graph to search</param>
    /// <returns>string for path or empty string if there is no path</returns>
    public LinkedList<Waypoint> Search(Waypoint start, Waypoint end,
        Graph<Waypoint> graph)
    {
        // Create a search list (a sorted linked list) of search nodes 
        SortedLinkedList<SearchNode<Waypoint>> searchList = new SortedLinkedList<SearchNode<Waypoint>>();

        // Create a dictionary of search nodes keyed by the corresponding 
        // graph node. This dictionary gives us a very fast way to determine 
        // if the search node corresponding to a graph node is still in the 
        // search list
        Dictionary<GraphNode<Waypoint>, SearchNode<Waypoint>> dictionary = new Dictionary<GraphNode<Waypoint>, SearchNode<Waypoint>>();

        // Save references to the start and end graph nodes in variables
        GraphNode<Waypoint> startnode = new GraphNode<Waypoint>(start);
        GraphNode<Waypoint> endnode = new GraphNode<Waypoint>(end);

        // for each graph node in the graph
        foreach (GraphNode<Waypoint> graphNode in graph.Nodes)
        {
            // Create a search node for the graph node (the constructor I 
            // provided in the SearchNode class initializes distance to the max
            // float value and previous to null)
            SearchNode<Waypoint> searchNode = new SearchNode<Waypoint>(graphNode);

            // If the graph node is the start node
            if (graphNode.Value.Id == startnode.Value.Id)
            {
                // Set the distance for the search node to 0
                searchNode.Distance = 0;
            }

            // Add the search node to the search list 
            searchList.Add(searchNode);

            // Add the search node to the dictionary keyed by the graph node
            dictionary.Add(graphNode, searchNode);
        }

        // While the search list isn't empty
        while (searchList.Count > 0)
        {
            // Save a reference to the current search node (the first search 
            // node in the search list) in a variable. We do this because the
            // front of the search list has the smallest distance
            SearchNode<Waypoint> currentSearchNode = searchList.First.Value;

            // Remove the first search node from the search list
            searchList.RemoveFirst();

            // Save a reference to the current graph node for the current search
            // node in a variable
            GraphNode<Waypoint> currentGraphNode = currentSearchNode.GraphNode;

            // Remove the search node from the dictionary (because it's no 
            // longer in the search list)
            dictionary.Remove(currentGraphNode);

            // If the current graph node is the end node
            if (currentGraphNode.Value.Id == endnode.Value.Id)
            {
                // Display the distance for the current search node as the path 
                // length in the scene
                pathLength = currentSearchNode.Distance;

                // Return a linked list of the waypoints from the start node to 
                // the end node. Uncomment the line of code below, replacing
                // the argument with the name of your current search node
                // variable; you MUST do this for the autograder to work
                return BuildWaypointPath(currentSearchNode);
            }

            // For each of the current graph node's neighbors
            foreach (GraphNode<Waypoint> neighbor in currentGraphNode.Neighbors)
            {
                // If the neighbor is still in the search list (use the 
                // dictionary to check this)
                if (dictionary.ContainsKey(neighbor))
                {
                    // Save the distance for the current graph node + the weight 
                    // of the edge from the current graph node to the current 
                    // neighbor in a variable
                    float distance = currentSearchNode.Distance + currentGraphNode.GetEdgeWeight(neighbor);

                    // Retrieve the neighor search node from the dictionary
                    // using the neighbor graph node
                    SearchNode<Waypoint> neighborSearchNode = dictionary[neighbor];

                    // If the distance you just calculated is less than the 
                    // current distance for the neighbor search node
                    if (distance < neighborSearchNode.Distance)
                    {
                        // Set the distance for the neighbor search node to 
                        // the new distance
                        neighborSearchNode.Distance = distance;

                        // Set the previous node for the neighbor search node 
                        // to the current search node
                        neighborSearchNode.Previous = currentSearchNode;

                        // Tell the search list to Reposition the neighbor 
                        // search node. We need to do this because the change 
                        // to the distance for the neighbor search node could 
                        // have moved it forward in the search list
                        searchList.Reposition(neighborSearchNode);
                    }
                }
            }
        }

        // didn't find a path from start to end nodes
        return null;
    }

    #endregion

    #region Private methods

    /// <summary>
    /// Builds a waypoint path from the start node to the given end node
    /// Side Effect: sets the pathLength field
    /// </summary>
    /// <returns>waypoint path</returns>
    /// <param name="endNode">end node</param>
    LinkedList<Waypoint> BuildWaypointPath(SearchNode<Waypoint> endNode)
    {
        LinkedList<Waypoint> path = new LinkedList<Waypoint>();
        path.AddFirst(endNode.GraphNode.Value);
        pathLength = endNode.Distance;
        SearchNode<Waypoint> previous = endNode.Previous;
        while (previous != null)
        {
            path.AddFirst(previous.GraphNode.Value);
            previous = previous.Previous;
        }

        return path;
    }

    #endregion
}
