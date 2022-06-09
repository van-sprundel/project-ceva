using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
public class BlockObject : MonoBehaviour
{
    public GameObject prefab;
    // dots are offsets from the root block
    public static List<Vector2> Dots = new()
    {
        new Vector2(0,0),
        new Vector2(0,1)
    };

    private void Start()
    {
        foreach (var dot in Dots)
        {
            if (dot == Vector2.zero) {
                continue;
            }
           var block = Instantiate(prefab, ((Vector3)dot*SnapController.spacing)+transform.localPosition, Quaternion.identity);
           block.transform.parent = gameObject.transform;
        }
    }
}