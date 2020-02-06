﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Waypoint))]
public class CubeEditor : MonoBehaviour
{
    Waypoint waypoint;

    void Awake()
    {
        waypoint = GetComponent<Waypoint>();
    }

    void Update()
    {
        SnapToGrid();
        UpdateLabel();
    }

    private void SnapToGrid()
    {
        //grid snapping system
        int gridSize = waypoint.GetGridSize();
        transform.position = new Vector3(
            waypoint.GetGridPos().x, 
            0f, 
            waypoint.GetGridPos().y
            );
    }

    private void UpdateLabel()
    {
        //labeling the cube
        TextMesh textMesh = GetComponentInChildren<TextMesh>();
        int gridSize = waypoint.GetGridSize();

        string labelText = 
            (waypoint.GetGridPos().x / gridSize) 
            + ", " + 
            (waypoint.GetGridPos().y / gridSize);

        textMesh.text = labelText;
        gameObject.name = "Cube at " + "( " + labelText + " )";
    }
}
