using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] Waypoint startPoint, endPoint; // for deciding start and end point
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>(); //dont add same coordinates
    Queue<Waypoint> queue = new Queue<Waypoint>();//trying queue
    bool isRunning = true;
    Waypoint searchCenter;
    List<Waypoint> path = new List<Waypoint>();

    Vector2Int[] directions = { //the search path algorithm
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };

    public List<Waypoint> GetPath()
    {
        LoadBlocks();
        ColorStartAndPoint();
        BreadthFirstSearch();
        CreatePath();
        return path;
    }

    private void CreatePath()
    {
        path.Add(endPoint);

        Waypoint previous = endPoint.exploredFrom;
        while (previous != startPoint)
        {
            path.Add(previous);
            previous = previous.exploredFrom;
        }

        path.Add(startPoint);//adding current start point
        path.Reverse(); //reverse the path
    }

    private void BreadthFirstSearch()
    {
        queue.Enqueue(startPoint); //queue start
        while ( queue.Count > 0 && isRunning)
        {
            searchCenter = queue.Dequeue();//end queue
            HaltIfEndpoint();//halt when the end is found
            ExploringNeighbours();
            searchCenter.isExplored = true; //coordinate is explored
        }
    }

    private void HaltIfEndpoint()
    {
        if (searchCenter == endPoint)
        {
            isRunning = false;
        }
    }

    private void ExploringNeighbours()
    {
        if (!isRunning) { return; }
        //if running run code bellow
        //run all direction
        foreach (Vector2Int direction in directions)
        {
            Vector2Int neighboburCoordinate = searchCenter.GetGridPos() + direction;//when start, this would act as increment next step or coordinates
            if(grid.ContainsKey(neighboburCoordinate))
            {
                QueueNewNeighbours(neighboburCoordinate);
            }
        }
    }

    private void QueueNewNeighbours(Vector2Int neighbourCoordinate)
    {
        Waypoint neighbour = grid[neighbourCoordinate];
        if (neighbour.isExplored || queue.Contains(neighbour))
        {
            //do nothing
        }
        else 
        {
            queue.Enqueue(neighbour);
            neighbour.exploredFrom = searchCenter;
        }
        
    }

    private void ColorStartAndPoint()
    {
        startPoint.SetTopColor(Color.green);
        endPoint.SetTopColor(Color.red);
    }

    private void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<Waypoint>();
        foreach (Waypoint waypoint in waypoints)
        {
            var gridPos = waypoint.GetGridPos();
            if (grid.ContainsKey(gridPos))
            {
                Debug.LogWarning("Skipping Overlapping Block" + waypoint);
            }
            else 
            {
                grid.Add(gridPos, waypoint);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
