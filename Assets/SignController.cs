using UnityEngine;

public class SignController : MonoBehaviour
{
    private readonly int height = 1; //max height of Box's movement
    private readonly float yCenter = 5f;

    private void Start()
    {
    }

    private void Update()
    {
        transform.position = new Vector3(transform.position.x,
            yCenter + Mathf.PingPong(Time.time * 0.6f, height) - height / 2f,
            transform.position.z); //move on y axis only
        //Box is moving with Mathf.PingPong (http://docs.unity3d.com/Documentation/ScriptReference/Mathf.PingPong.html)
    }
}