using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignController : MonoBehaviour
{
    private int height = 1;//max height of Box's movement
    private float yCenter = 5f;
 
    void Start () {

    }
 
    void Update () {
        transform.position = new Vector3(transform.position.x, yCenter + Mathf.PingPong(Time.time * 0.6f, height) - height/2f, transform.position.z);//move on y axis only
    //Box is moving with Mathf.PingPong (http://docs.unity3d.com/Documentation/ScriptReference/Mathf.PingPong.html)
    }
}
