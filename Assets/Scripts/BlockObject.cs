using System.Collections.Generic;
using UnityEngine;

public class BlockObject : MonoBehaviour
{
    public Shape ShapeSelector;
    public GameObject prefab;

    // dots are offsets from the root block
    public static List<Vector2> _dots;

    private void Start()
    {
        _dots = GetDots();
        foreach (var dot in _dots)
        {
            if (dot == Vector2.zero)
            {
                continue;
            }

            var position = (Vector3)dot * SnapController.spacing + transform.localPosition;
            
            var block = Instantiate(
                prefab,
                position,
                Quaternion.identity);

            block.transform.parent = gameObject.transform;

        }
    }

    public List<Vector2> GetDots()
    {
        switch (ShapeSelector)
        {
            case Shape.Corner:
                return new List<Vector2>()
                {
                    new(0, 0),
                    new(0, 1),
                    new(1, 0)
                };
            case Shape.Plus:
                return new List<Vector2>()
                {
                    new(0, 0),
                    new(0, 1),
                    new(1, 0),
                    new(-1, 0),
                    new(0, -1),
                };
            case Shape.Square:
                return new List<Vector2>()
                {
                    new(0, 0),
                    new(0, 1),
                    new(1, 0),
                    new(1, 1),
                };
            case Shape.Z:
                return new List<Vector2>()
                {
                    new(0, 0),
                    new(1, 0),
                    new(1, -1),
                    new(2, -1),
                };
            case Shape.L:
                return new List<Vector2>()
                {
                    new(0, 0),
                    new(1, 0),
                    new(0, 1),
                    new(0, 2),
                };
        }

        return new List<Vector2>();
    }

    public enum Shape
    {
        Corner,
        Plus,
        Square,
        Z,
        L
    }
}