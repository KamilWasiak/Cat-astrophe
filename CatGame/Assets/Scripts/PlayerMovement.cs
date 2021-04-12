using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update


    public Rigidbody rb;
    public Transform cam;

    public float movementSpeed = 6.0f;      //speed the player moves at
    public float jumpHeight = 200.0f;       //height of the jump
    public float timeBetweenJumps = 1.0f;   //delay between each jump so the player can't jump again before reaching the ground
    private float timestamp;

    public Vector3 movement;
 
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }


    void Update()
    {
      
        movement = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0) * new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        Vector3 camRotation = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0) * new Vector3(Camera.main.transform.eulerAngles.z, 0, Camera.main.transform.eulerAngles.x);
        //transform.LookAt(transform.position + new Vector3(movement.x, 0f, movement.z));         // makes the player always face in the direction of movement
        transform.LookAt(transform.position + camRotation);   
          

        if (Time.time >= timestamp && (Input.GetKeyDown("space")))
        {
            GetComponent<Rigidbody>().velocity = Vector3.up * jumpHeight;                       // multiplies the players Y position by the jumpHeight variable which causes the player to jump in-game
            timestamp = Time.time + timeBetweenJumps;

        }

    }
    

    void FixedUpdate()
    {
        moveCharacter(movement);    

    }

    void moveCharacter(Vector3 direction)
    {
        rb.MovePosition(transform.position + (direction * movementSpeed * Time.deltaTime));     //moves the rigidbody (player) 
        
    }
}