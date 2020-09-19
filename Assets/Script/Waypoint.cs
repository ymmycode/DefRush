﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    //[SerializeField] Color exploredColor;
    public bool isExplored = false;
    public Waypoint exploredFrom;
    public bool isPlaceable = true;
    Vector2Int gridPos;
    const int gridSize = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetGridSize()
    {
        return gridSize;
    }

    public Vector2Int GetGridPos()
    {
        return new Vector2Int(
            Mathf.RoundToInt(transform.position.x / gridSize),
            Mathf.RoundToInt(transform.position.z / gridSize)
        );
    }

    private void OnMouseOver() 
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(isPlaceable)
            {
                FindObjectOfType<TowerFactory>().AddTower(this);
            }
            else
            {print("NOT PLACEABLE");}
            
        }
    }
} 
