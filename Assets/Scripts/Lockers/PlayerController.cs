using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public struct RackData
{
    public int number;
    public Color color;
    public Letter letter;
    
    public override string ToString()
    {
        return $"{letter}{number + 1}";
    }

    public override bool Equals(object obj)
    {
        return obj.GetHashCode() == GetHashCode();
    }

    public override int GetHashCode()
    {
        return number^(int)color^(int)letter;
    }
}

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rb;
    public float speed = 200f;
    public UnityEvent<RackData> headBang;

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
            // Event pushen
            headBang.Invoke(new RackData { number = scriptOther.number, color = scriptOther.color, letter = scriptOther.letter });
            
        }
    }

    

    

}
