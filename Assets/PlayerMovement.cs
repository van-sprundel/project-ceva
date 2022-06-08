using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody body;
    public UnityEvent leftDoorTouched;
    public UnityEvent rightDoorTouched;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // let player walk on x axis with rigidbody
        float x = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(x, 0.0f, 0.0f);
        body.velocity = movement * speed;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("LeftDoor")) {
            leftDoorTouched.Invoke();
        } else if (other.gameObject.CompareTag("RightDoor")) {
            rightDoorTouched.Invoke();
        }
    }
}
