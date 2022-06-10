using System.Collections.Generic;
using UnityEngine;

public class BlockObject : MonoBehaviour
{
    public Shape ShapeSelector;
    public GameObject prefab;

    // dots are offsets from the root block
    public static List<Vector2> Dots;

    private void Start()
    {
        Dots = GetDots();
        foreach (var dot in Dots)
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
        }

        return new List<Vector2>();
    }

    public enum Shape
    {
        Corner,
        Plus
    }
}