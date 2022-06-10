using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rb;
    public float speed = 200f;

    public void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }
    public void Move(Vector3 movement)
    {
        _rb.velocity = movement * speed;
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Rack"))
        {
            var scriptOther = other.gameObject.GetComponent<Rack>();
            Debug.Log($"{scriptOther.number}, {scriptOther.letter}, {scriptOther.color}: Collided");
        }
    }

    

    

}
