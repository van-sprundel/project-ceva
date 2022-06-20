using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public PlayerController player;

    public void Update()
    {
        var (x, y) = (Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        var movement = new Vector3(x, 0.0f, y);

        // Player aanroepen
        player.Move(movement * Time.deltaTime);
    }
}