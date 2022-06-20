using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement2 : MonoBehaviour
{
    public UnityEvent<RackData> headBang;

    public float Speed = 200f;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        var vertical = Input.GetAxis("Vertical");
        var horizontal = Input.GetAxis("Horizontal");
        var velocity = Vector3.zero;
        velocity += transform.forward * vertical; //Move forward
        velocity += transform.right * horizontal; //Strafe
        velocity *= Speed * Time.fixedDeltaTime; //Framerate and speed adjustment
        velocity.y = rb.velocity.y;
        rb.velocity = velocity;
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Rack"))
        {
            var scriptOther = other.gameObject.GetComponent<Rack>();
            // Event pushen
            headBang.Invoke(new RackData
                { number = scriptOther.number, color = scriptOther.color, letter = scriptOther.letter });
        }
    }
}