using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{
    public float Speed = 200f;
    Rigidbody rb;
    void Start () {
        rb = GetComponent<Rigidbody>();
    }
    void Update () {
        var vertical = Input.GetAxis("Vertical");
        var horizontal = Input.GetAxis("Horizontal");
        Vector3 velocity = Vector3.zero;
        velocity += (transform.forward * vertical); //Move forward
        velocity += (transform.right * horizontal); //Strafe
        velocity *= Speed * Time.fixedDeltaTime; //Framerate and speed adjustment
        velocity.y = rb.velocity.y;
        rb.velocity = velocity;
    }
}
