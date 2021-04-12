using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling : MonoBehaviour
{
    [HideInInspector] new public Rigidbody rigidbody;

    public bool useGravity = true;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        //fixes the gravity in game so it takes into account mass 
        rigidbody.useGravity = false;
        if (useGravity) rigidbody.AddForce(Physics.gravity * (rigidbody.mass * rigidbody.mass));
    }
}
