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
    public static float spacing = 0.84f;
    public static float widthOffset = -8.6f;
    public static float heightOffset = -1.2f;


    private void Start()
    {
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

        if (closestSnap != null && distance <= maxDistance)
        {
            dragObject.transform.localPosition = (Vector3)closestSnap;
            Debug.Log($"Snapping on {currX} {currY}");
        }
    }
}