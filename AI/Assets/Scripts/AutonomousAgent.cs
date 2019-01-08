using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutonomousAgent : MonoBehaviour
{
    public Vector3 acceleration { get; set; } = Vector3.zero;
    public Vector3 velocity { get; set; } = Vector3.zero;

    void Start()
    {
     
    }
    
    void Update()
    {
        acceleration = Vector3.zero;
        Vector3 force = Vector3.forward;
        ApplyForce(force);

        velocity += acceleration * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;

        Debug.Log(velocity);
        Debug.DrawLine(transform.position, transform.position + velocity, Color.red);
    }

    void ApplyForce(Vector3 force)
    {
        acceleration = acceleration + force;
    }
}
