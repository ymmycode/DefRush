using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] Waypoint startPoint, endPoint; // for deciding start and end point
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>(); //dont add same coordinates
    Vector2Int[] directions = { 
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };

    // Start is called before the first frame update
    void Start()
    {
        LoadBlocks();
        ColorStartAndPoint();
        ExploringNeighbours();
    }

    private void ExploringNeighbours()
    {
        foreach (Vector2Int direction in directions)
        {
            Vector2Int explorationCoordinates = startPoint.GetGridPos() + direction;
            try
            {
                grid[explorationCoordinates].SetTopColor(Color.blue);
            }
            catch 
            {
                //prevent dictionary key not avalaible
                print("Empty Block"); //it's okay without this print output
            }
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
            print("Loaded "+ grid.Count +" Blocks");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
