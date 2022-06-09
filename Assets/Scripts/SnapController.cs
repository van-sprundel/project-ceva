using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SnapController : MonoBehaviour
{
    public int width = 8, height = 8;
    public List<Vector2> snapPoints;
    public List<DragObject> draggableObjects;
    public float maxDistance = 0.9f;
    public static float spacing = 0.65f;
    public static float widthOffset = -7.5f;
    public static float heightOffset = -1.2f;
    private bool[,] grid;


    private void Start()
    {
        grid = new bool[height, width];
        foreach (var draggable in draggableObjects)
        {
            draggable.dragEndedCallback = OnDragEnded;
        }

        for (var i = 0; i < height; i++)
        {
            for (var j = 0; j < width; j++)
            {
                snapPoints.Add(new Vector2(spacing * (i + widthOffset), spacing * (j + heightOffset)));
            }
        }
    }

    private void OnDragEnded(DragObject dragObject)
    {
        float distance = -1;
        Vector2? closestSnap = null;

        var i = 0;
        var (currX, currY) = (-1, -1);
        foreach (var snapPoint in snapPoints)
        {
            var currDistance = Vector2.Distance(dragObject.transform.localPosition, snapPoint);
            if (closestSnap == null || currDistance < distance)
            {
                closestSnap = snapPoint;
                distance = currDistance;
                currX = i % width;
                currY = i / height;
            }

            i++;
        }

        // grid too far or no spots left
        if (closestSnap == null || distance > maxDistance)
        {
            return;
        }

        var temp = grid;

        foreach (var dot in BlockObject.Dots)
        {
            var posX = (int)(currY + dot.x);
            var posY = (int)(currX + dot.y);
            // Debug.Log($"Block is on {posX} {posY}");

            if (posY >= height || posX >= height || temp[posX,posY])
            {
                return;
            }

            temp[posX, posY] = true;
        }

        // Block fits
        Debug.Log($"Snapping on {currX} {currY}");
        
        grid = temp;
        dragObject.transform.localPosition = (Vector3)closestSnap;
        dragObject.isSnapped = true;
    }
}