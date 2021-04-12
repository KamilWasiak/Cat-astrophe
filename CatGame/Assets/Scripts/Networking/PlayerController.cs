using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private void FixedUpdate()
    {
        SendInputToServer();
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0) || Input.GetKeyUp(KeyCode.E))
        {
            PlayerPickup();
            Debug.Log("Player action");
        }
    }


    /// <summary>Sends player input to the server.</summary>
    private void SendInputToServer()
    {
        bool[] _inputs = new bool[]
        {
            Input.GetKey(KeyCode.W),
            Input.GetKey(KeyCode.S),
            Input.GetKey(KeyCode.A),
            Input.GetKey(KeyCode.D),
            Input.GetKey(KeyCode.Space)
        };

        ClientSend.PlayerMovement(_inputs);
    }
    public void PlayerPickup()
    {
        ClientSend.PlayerPickup();
    }
}
