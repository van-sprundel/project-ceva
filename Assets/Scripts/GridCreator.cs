using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GridCreator : MonoBehaviour
{
    public int length = 8, width = 8;
    public GameObject prefab;

    void Start()
    {
        for (var i = 0; i < length; i++)
        {
            for (var j = 0; j < width; j++)
            {
                var position = new Vector3(SnapController.spacing * (i + SnapController.widthOffset),
                    SnapController.spacing * (j + SnapController.heightOffset), 1.0f);
             Instantiate(prefab, position, Quaternion.identity);
            }
        }
    }
}