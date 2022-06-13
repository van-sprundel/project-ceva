using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    float horizontalMove = 0f;
    public float runSpeed = 60f;
    bool jump = false;

    void Update() {
       horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

         // jump with space
        if (Input.GetButtonDown("Jump")) {
            jump = true;
        }
    }

    void FixedUpdate() {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
